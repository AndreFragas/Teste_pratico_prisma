using System.Net;
using Newtonsoft.Json;

namespace ProjetoPrisma5
{
    public class Post
    {
        public class Mesorregiao
        {
            public string nome { get; set; }
            public UF UF { get; set; }
        }

        public class Microrregiao
        {
            public Mesorregiao mesorregiao { get; set; }
        }

        public class Regiao
        {
            public string nome { get; set; }
        }

        public class RegiaoImediata
        {
            [JsonProperty("regiao-intermediaria")]
            public RegiaoIntermediaria RegiaoIntermediaria { get; set; }
        }

        public class RegiaoIntermediaria
        {
            public int id { get; set; }
            public string nome { get; set; }
            public UF UF { get; set; }
        }

        public class Cidade
        {
            public string id { get; set; }
            public string nome { get; set; }
            public Microrregiao microrregiao { get; set; }

            [JsonProperty("regiao-imediata")]
            public RegiaoImediata RegiaoImediata { get; set; }
        }

        public class UF
        {
            public string sigla { get; set; }
            public Regiao regiao { get; set; }
        }
    }

    public class ManipularJson
    {
        public List<Modelo> ShowData(string estado)
        {
            List<Modelo> modelos = new List<Modelo>();
            var json = GetJSON(estado);
            var data = JsonConvert.DeserializeObject<List<Post.Cidade>>(json);
            foreach (Post.Cidade temp in data)
            {
                Modelo modelo = new Modelo();
                modelo.NomeCidade = temp.nome;
                modelo.RegiaoNome = temp.microrregiao.mesorregiao.UF.regiao.nome;
                modelo.SiglaEstado = temp.microrregiao.mesorregiao.UF.sigla;
                modelo.NomeMesoregiao = temp.microrregiao.mesorregiao.nome;
                modelo.NomeFormatado = temp.nome + "/" + temp.microrregiao.mesorregiao.UF.sigla;
                modelos.Add(modelo);
            }
            return modelos;
        }

        public string GetJSON(string estado)
        {
            var request = WebRequest.Create("https://servicodados.ibge.gov.br/api/v1/localidades/estados/" + estado + "/municipios");
            request.Method = "GET";
            var response = (HttpWebResponse)request.GetResponse();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                using (var stream = response.GetResponseStream())
                {
                    var reader = new StreamReader(stream);
                    var json = reader.ReadToEnd();
                    return json;
                }
            }
            return null;
        }
    }
}
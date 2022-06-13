using Microsoft.AspNetCore.Mvc;
using ProjetoPrisma5.Repositório;

namespace ProjetoPrisma5.Controllers
{
    [ApiController]
    [Route("api/projeto")]
    public class FormController : ControllerBase
    {
        [HttpGet]
        public void teste(string email, string estado)
        {
            ManipularJson manipulador = new ManipularJson();
            var modelito = manipulador.ShowData(estado);
            ConverterModelo criaExcel = new ConverterModelo();
            criaExcel.CriaPlanilhaExcel(modelito);
            //EnviarEmail enviarEmail = new EnviarEmail();
            //enviarEmail.EnviaMensagemComAnexos(email);
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace ProjetoPrisma5.Controllers
{
    [ApiController]
    [Route("api/projeto")]
    public class FormController : ControllerBase
    {
        [HttpPost]
        public void teste(string email, string estado)
        {
            ManipularJson manipulador = new ManipularJson();
            manipulador.ShowData(estado);
        }
    }
}

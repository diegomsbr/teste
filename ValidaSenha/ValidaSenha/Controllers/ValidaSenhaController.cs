using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ValidaSenha.Model;

namespace ValidaSenha.Controllers
{
    [ApiController]
    public class ValidaSenhaController : ControllerBase
    {
        private readonly ILogger<ValidaSenhaController> _logger;

        public ValidaSenhaController(ILogger<ValidaSenhaController> logger)
        {
            _logger = logger;
        }

        [Route("/Seguranca/v1/senhas/valida")]
        [HttpPost]
        public IActionResult Validar([FromBody] Usuario usuario)
        {
            //Retornar um objeto json como bool
            Resultado resultadoSenha = new Resultado()
            {
                IsSenhaValida = ModelState.IsValid ? true : false
            };

            return Ok(resultadoSenha);

            //Retornar um bool
            //var isSenhaValida = ModelState.IsValid ? true : false;
            //return Ok(isSenhaValida);

        }
    }
}

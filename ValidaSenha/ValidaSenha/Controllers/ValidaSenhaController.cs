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

        [Route("/Seguranca/v2/senhas/valida")]
        [HttpPost]
        public IActionResult ValidarV2([FromBody] Usuario usuario)
        {
            //Retornar um objeto json como bool
            Resultado resultadoSenha = new Resultado()
            {
                IsSenhaValida = ModelState.IsValid ? true : false
            };


            return BadRequest(resultadoSenha);

            //Retornar um bool
            //var isSenhaValida = ModelState.IsValid ? true : false;
            //return Ok(isSenhaValida);
        }


        [Route("/Seguranca/v2/senhas/valida")]
        [HttpGet]
        public IActionResult GetValidarV2([FromBody] Usuario usuario)
        {
            //Retornar um objeto json como bool
            Resultado resultadoSenha = new Resultado()
            {
                IsSenhaValida = ModelState.IsValid ? true : false
            };


            return Ok("Isto é um Get");

            //Retornar um bool
            //var isSenhaValida = ModelState.IsValid ? true : false;
            //return Ok(isSenhaValida);
        }
    }
}

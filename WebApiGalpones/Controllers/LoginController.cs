using MediatR;
using Microsoft.AspNetCore.Mvc;
using Negocios.Comandos;
using System.Security.Claims;
using System.Text;

namespace WebApiGalpones.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IConfiguration _configuration;

        public LoginController(IMediator mediator, IConfiguration configuration)
        {
            _mediator = mediator;
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginCommand command)
        {
            var resultado = await _mediator.Send(command);



            if (resultado.Equals("Ok"))
            {

        

       
                return Ok(
                    new
                    {
                        Id_Empresa = resultado.Mensaje,
                        NombreEmpresa = resultado.NombreEmpresa,
             

                    });
            }

            return BadRequest(new { Mensaje = resultado.Mensaje });
        }

     
    }
}



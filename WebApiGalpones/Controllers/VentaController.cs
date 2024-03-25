using MediatR;
using Microsoft.AspNetCore.Mvc;
using Negocios.Comandos;
using System.Security.Claims;
using System.Text;

namespace WebApiGalpones.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IConfiguration _configuration;

        public VentaController(IMediator mediator, IConfiguration configuration)
        {
            _mediator = mediator;
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] VentaCommand command)
        {
            var resultado = await _mediator.Send(command);



            if (resultado.Mensaje.Equals("Ok"))
            {




                return Ok(
                    new
                    {
                        Mensaje = resultado.Mensaje,
                     


                    });
            }

            return BadRequest(new { Mensaje = resultado.Mensaje });
        }


    }
}



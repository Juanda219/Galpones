using Abstraciones.Repositorios;
using MediatR;
using Negocios.Comandos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios.Procesos
{
    public class VentaHandler : IRequestHandler<VentaCommand, VentaCommandResponse>
    {
        private readonly IVentaRepository _venta;

        public VentaHandler(IVentaRepository venta)
        {
            _venta = venta;
        }

        public async Task<VentaCommandResponse> Handle(VentaCommand request, CancellationToken cancellationToken)
        {
            VentaCommandResponse response = new();
            var result = await _venta.Venta(request);

            if (result != null && result.Mensaje.ToString().Equals("Mal"))
            {
                response.Mensaje = result.Mensaje;
                return response;
            }

            else if (result != null && !result.Mensaje.Equals("Mal", StringComparison.OrdinalIgnoreCase))
            {

                response.Mensaje = result.Mensaje;
                return response;
            }

            return response;

        }
    }
}

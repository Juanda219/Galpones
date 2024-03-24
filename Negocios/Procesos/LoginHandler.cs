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
    public class LoginHandler : IRequestHandler<LoginCommand, LoginResponse>
    {
        private readonly IVerificateLogin _verificateLogin;

        public LoginHandler(IVerificateLogin verificateLogin)
        {
            _verificateLogin = verificateLogin;
        }

        public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            LoginResponse response = new();
            var result = await _verificateLogin.VerificateLoginUser(request);

            if (result != null && result.Mensaje.ToString().Equals("Mal"))
            {
                response.Mensaje = result.Mensaje;
                return response;
            }

            else if (result != null && !result.Mensaje.Equals("Mal", StringComparison.OrdinalIgnoreCase))
            {
  
                response.Mensaje = result.Mensaje;
                response.NombreEmpresa = result.NombreEmpresa;
                response.IdEmpresa = result.IdEmpresa;
                return response;
            }

            return response;

        }
    }
}

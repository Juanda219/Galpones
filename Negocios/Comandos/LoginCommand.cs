using Abstraciones.Repositorios.Tipos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios.Comandos
{
    public class LoginCommand: IRequest<LoginResponse>, ILogin
    {
        public string NombreUsuario { get; set; }
        public string Contrasena { get; set; }  
    }

    public class LoginResponse
    {
        public string Mensaje { get; set; }
        public string NombreEmpresa { get; set; }
        public string IdEmpresa { get; set; }
   

    }
}

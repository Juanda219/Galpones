using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraciones.Repositorios.Tipos
{
    public interface ILogin
    {
        string NombreUsuario { get; set; }
        string Contrasena { get; set; }
    }
}

using Abstraciones.Repositorios.Tipos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraciones.Repositorios
{
    public interface IVerificateLogin
    {
        Task<dynamic> VerificateLoginUser(ILogin command);
    }
}

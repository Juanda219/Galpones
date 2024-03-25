using Abstraciones.Repositorios.Tipos;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraciones.Repositorios
{
    public interface IVentaRepository
    {
           
        Task<dynamic> Venta(IVenta command);
    }
}


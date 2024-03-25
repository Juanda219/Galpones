using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraciones.Repositorios.Tipos
{
    public interface IVenta
    {
        public string NombreCliente { get; set; }
        public string Documento { get; set; }
        public string Direccion { get; set; }
        public string Categoria { get; set; }
        public int Cantidad { get; set; }
    }
}

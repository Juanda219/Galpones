﻿using Abstraciones.Repositorios.Tipos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios.Comandos
{
    public class VentaCommand : IRequest<VentaCommandResponse>, IVenta
    {
        public string NombreCliente { get; set; }
        public string Documento { get; set; }
        public string Direccion { get; set; }
        public string Categoria { get; set; }
        public int Cantidad { get; set; }



    }

    public class VentaCommandResponse
    {
        public string Mensaje { get; set; }


    }
}

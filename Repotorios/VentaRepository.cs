using Abstraciones.Repositorios;
using Abstraciones.Repositorios.Tipos;
using Dapper;
using Negocios.Comandos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Repotorios
{
    public class VentaRepository : IVentaRepository
    {
        private readonly IDatabaseConectionFactory _dbConnectionFactory;

        public VentaRepository(IDatabaseConectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory ?? throw new ArgumentNullException(nameof(dbConnectionFactory));
        }

        public async Task<dynamic> Venta(IVenta request)
        {

            using (var dbConnection = _dbConnectionFactory.CreateConnection())
            {
                try
                {
                    var result = await dbConnection.QueryFirstOrDefaultAsync<LoginResponse>(
                    "VentasP",
                    new
                    {
                        NombreCliente = request.NombreCliente,
                        Documento = request.Documento,
                        Categoria = request.Categoria,  
                        Direccion = request.Direccion,
                        Cantidad = request.Cantidad
                    },
                        commandType: CommandType.StoredProcedure
                    );

                    return result;

                }
                catch (SEHException ex)
                {
                    // Handle SQL Server exceptions here
                    // You can throw a custom exception if you prefer
                    throw new Exception("Database error: " + ex.Message, ex);
                }
            }
        }
    }
}

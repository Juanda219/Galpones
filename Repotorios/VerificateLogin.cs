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
    public class VerificateLogin: IVerificateLogin
    {
        private readonly IDatabaseConectionFactory _dbConnectionFactory;

        public VerificateLogin(IDatabaseConectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory ?? throw new ArgumentNullException(nameof(dbConnectionFactory));
        }

        public async Task<dynamic> VerificateLoginUser(ILogin request)
        {

            using (var dbConnection = _dbConnectionFactory.CreateConnection())
            {
                try
                {
                    var result = await dbConnection.QueryFirstOrDefaultAsync<LoginResponse>(
                    "Login",
                    new
                    {
                        NombreUsuario = request.NombreUsuario,
                        Contrasena = request.Contrasena,

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

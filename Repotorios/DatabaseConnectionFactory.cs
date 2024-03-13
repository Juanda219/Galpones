using Abstraciones.Repositorios;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;

using System.Data;

namespace Repotorios
{
    public class DatabaseConnectionFactory: IDatabaseConectionFactory
    {
        private readonly IDbConnection _connection;

        public DatabaseConnectionFactory(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            _connection = new SqlConnection(connectionString);
            _connection.Open();
        }

        public DatabaseConnectionFactory(string customConnectionString)
        {
            _connection = new SqlConnection(customConnectionString);
            _connection.Open();
        }

        public IDbConnection CreateConnection()
        {
            return _connection;
        }

        public IDbConnection CreateConnection(string customConnectionString)
        {
            var connection = new SqlConnection(customConnectionString);
            connection.Open();
            return connection;
        }

        public void Dispose()
        {
            if (_connection != null && _connection.State == ConnectionState.Open)
            {

                _connection.Close();
            }
        }
    }
}


using Microsoft.Data.SqlClient;
using System.Data;

namespace mvc.Database
{
    public class database
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public database(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("database");
        }

        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}

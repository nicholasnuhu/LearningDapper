using LearningDapper.Infrastructure.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace LearningDapper.Infrastructure.Commons
{
    public class SqlConnectionsFactory : ISqlConnectionsFactory
    {
        private readonly IConfiguration _config;

        public SqlConnectionsFactory(IConfiguration config)
        {
            _config = config;
        }

        public SqlConnection CreateConnection() =>
            new SqlConnection(_config.GetConnectionString("Default"));
    }
}
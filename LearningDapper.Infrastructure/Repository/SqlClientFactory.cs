using Dapper;
using LearningDapper.Core.Interfaces;
using LearningDapper.Infrastructure.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace LearningDapper.Infrastructure.Repository
{
    public class SqlClientFactory : ISqlClientFactory
    {
        private readonly ISqlConnectionsFactory _config;

        public SqlClientFactory(ISqlConnectionsFactory config)
        {
            _config = config;
        }

        public async Task<IEnumerable<T>> LoadData<T, U>(string storedProcedure, U parameters)
        {
            using IDbConnection connection = _config.CreateConnection();
            return await connection.QueryAsync<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task SaveData<T>(string storedProcedure, T parameter)
        {
            using IDbConnection connection = _config.CreateConnection();
            await connection.ExecuteReaderAsync(storedProcedure, parameter, commandType: CommandType.StoredProcedure);
        }
    }
}
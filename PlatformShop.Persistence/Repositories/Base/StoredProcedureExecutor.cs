using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformShop.Persistence.Repositories.Base
{
    public class StoredProcedureExecutor : IStoredProcedureExecutor
    {
        private readonly string _connectionString;
        private readonly ILogger<StoredProcedureExecutor> _logger;
        public StoredProcedureExecutor(IConfiguration connectionString, ILogger<StoredProcedureExecutor> logger)
        {
            _connectionString = connectionString[""];
            _logger = logger;
        }
        public async Task<int> ExecuteAsync(string storedProcedureName, Dictionary<string, object> parameters, SqlParameter? outputParam = null)
        {
            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand(storedProcedureName, connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };

            foreach (var param in parameters)
            {
                command.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
            }
            if (outputParam != null)
            {
                command.Parameters.Add(outputParam);
            }
            await connection.OpenAsync();
            var result = await command.ExecuteNonQueryAsync();

            _logger.LogInformation("Stored procedure {StoredProcedure} executed with result {Result}", storedProcedureName, result);
            return result;

        }

        public async Task<List<T>> QueryAsync<T>(string storedProcedureName, Func<SqlDataReader, T> map, Dictionary<string, object>? parameters = null)
        {
            var results = new List<T>();

            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand(storedProcedureName, connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };
            if (parameters != null)
            {
                foreach (var param in parameters)
                {
                    command.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                }
            }

            await connection.OpenAsync();
            using var reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                results.Add(map(reader));
            }


            return results;
        }
    }
}

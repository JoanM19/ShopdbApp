using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformShop.Persistence.Repositories.Base
{
    public interface IStoredProcedureExecutor
    {
        Task<int> ExecuteAsync(string storedProcedureName,Dictionary<string,object>parameters , SqlParameter? outputParam = null);
        Task<List<T>> QueryAsync<T>(string storedProcedureName,Func<SqlDataReader, T> map, Dictionary<string, object>? parameters = null);
    }
}

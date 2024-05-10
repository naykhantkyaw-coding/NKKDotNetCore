using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace NKKDotNetCore.Shared
{
    public class DapperService
    {
        public List<T> GetData<T>(string? query)
        {
            using IDbConnection connection = new SqlConnection();
            List<T> data = new List<T>();
            if (query is not null)
            {
                data = connection.Query<T>(query).ToList();
            }
            return data;
        }
    }
}

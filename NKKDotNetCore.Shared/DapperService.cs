using Dapper;
using NKKDotNetCore.Shared.ConnectionService;
using System.Data;
using System.Data.SqlClient;

namespace NKKDotNetCore.Shared
{
    public class DapperService
    {
        public List<T> GetDatas<T>(string query, object? parameters = null)
        {
            using IDbConnection connection = new SqlConnection(ConnectionStrings.connectionString.ConnectionString);
            var data = connection.Query<T>(query, parameters).ToList();
            return data;
        }

        public T? GetDataFirstOrDefault<T>(string query, object? parameters = null)
        {
            using IDbConnection connection = new SqlConnection(ConnectionStrings.connectionString.ConnectionString);
            var item = connection.Query<T>(query, parameters).FirstOrDefault();
            return item;
        }
    }
}

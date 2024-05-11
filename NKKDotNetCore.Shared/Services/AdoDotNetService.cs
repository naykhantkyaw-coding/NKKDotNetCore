using Newtonsoft.Json;
using NKKDotNetCore.Shared.ConnectionService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NKKDotNetCore.Shared.Services
{
    public class AdoDotNetService
    {
        public List<T>? Query<T>(string query, params AdoDotNetParamters[] parameters)
        {
            SqlConnection connection = new SqlConnection(ConnectionStrings.connectionString.ConnectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddRange(parameters.Select(x =>
            new SqlParameter
            {
                ParameterName = x.Name,
                Value = x.Value
            }).ToArray());

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            connection.Close();
            string json = JsonConvert.SerializeObject(dt);
            List<T>? data = JsonConvert.DeserializeObject<List<T>>(json);
            return data;
        }

        public T? QueryFirstOrDefault<T>(string query, params AdoDotNetParamters[] parameters)
        {
            SqlConnection connection = new SqlConnection(ConnectionStrings.connectionString.ConnectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddRange(parameters.Select(x =>
            new SqlParameter
            {
                ParameterName = x.Name,
                Value = x.Value
            }).ToArray());

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            connection.Close();
            string json = JsonConvert.SerializeObject(dt);
            T? data = JsonConvert.DeserializeObject<T>(json);
            return (data);
        }

        public int Execute(string query, params AdoDotNetParamters[] parameters)
        {
            SqlConnection connection = new SqlConnection(ConnectionStrings.connectionString.ConnectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddRange(parameters.Select(x =>
            new SqlParameter
            {
                ParameterName = x.Name,
                Value = x.Value
            }).ToArray());
            var result = cmd.ExecuteNonQuery();
            connection.Close();
            return result;
        }
    }

    public class AdoDotNetParamters
    {
        public AdoDotNetParamters() { }
        public AdoDotNetParamters(string name, object value)
        {
            Name = name;
            Value = value;
        }
        public string Name { get; set; }
        public object Value { get; set; }
    }
}

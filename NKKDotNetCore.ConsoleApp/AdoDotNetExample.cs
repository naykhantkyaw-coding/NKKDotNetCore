using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NKKDotNetCore.ConsoleApp
{
    public class AdoDotNetExample
    {
        public readonly SqlConnectionStringBuilder _stringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = ".", // server name
            InitialCatalog = "DotNetCoreTrainingBatch4", // Db name
            UserID = "sa",
            Password = "sasa@123"
        };
        public void Read()
        {
            SqlConnection connection = new SqlConnection(_stringBuilder.ConnectionString);

            connection.Open();
            Console.WriteLine("Connection.Open");

            string query = "select * from BlogTable";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            connection.Close();
            Console.WriteLine("Connection.Close");

            foreach (DataRow dr in dt.Rows)
            {
                Console.WriteLine($"Id => {dr["BlogId"]}");
                Console.WriteLine($"Title => {dr["BlogTitle"]}");
                Console.WriteLine($"Author => {dr["BlogAuthor"]}");
                Console.WriteLine($"Content => {dr["BlogContent"]}");
                Console.WriteLine("------------------------");
            }
        }

    }
}

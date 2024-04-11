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

        public void Create(string title, string author, string content)
        {
            SqlConnection connection = new SqlConnection(_stringBuilder.ConnectionString);
            connection.Open();

            string query = @"INSERT INTO [dbo].[BlogTable]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     VALUES
           (@BlogTitle
           ,@BlogAuthor
           ,@BlogContent)";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogTitle", title);
            cmd.Parameters.AddWithValue("@BlogAuthor", title);
            cmd.Parameters.AddWithValue("@BlogContent", title);
            int result = cmd.ExecuteNonQuery();

            connection.Close();

            string message = result > 0 ? "Saving Successful" : "Saving Fail";
            Console.WriteLine(message);
        }

        public void Update(int id, string title, string author, string content)
        {
            SqlConnection connection = new SqlConnection(_stringBuilder.ConnectionString);
            connection.Open();

            string query = @"UPDATE [dbo].[BlogTable]
            SET [BlogTitle] = @BlogTitle
              ,[BlogAuthor] = @BlogAuthor
              ,[BlogContent] = @BlogContent
             WHERE BlogId = @BlogId";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@BlogId", id);
            command.Parameters.AddWithValue("@BlogTitle", title);
            command.Parameters.AddWithValue("@BlogAuthor", author);
            command.Parameters.AddWithValue("@BlogContent", content);
            var result = command.ExecuteNonQuery();

            connection.Close();

            string message = result > 0 ? "Update Successful" : "Update Fail";
            Console.WriteLine(message);

        }

        public void Delete(int id)
        {
            SqlConnection connection = new SqlConnection(_stringBuilder.ConnectionString);
            connection.Open();

            string query = @"DELETE FROM [dbo].[BlogTable]
                            WHERE BlogId = @BlogId";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogId", id);
            var result = cmd.ExecuteNonQuery();

            connection.Close();

            string message = result > 0 ? "Delete Success" : "Delect fail";
            Console.WriteLine(message);
        }



    }
}

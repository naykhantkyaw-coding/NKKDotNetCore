using Dapper;
using NKKDotNetCore.ConsoleApp.Connection;
using NKKDotNetCore.ConsoleApp.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NKKDotNetCore.ConsoleApp
{
    internal class DapperExample
    {
        public void Run()
        {
            Create("TestingDapper", "TestingDP", "TestingDp");
        }

        private void Create(string blogTitle, string blogAuthor, string blogContent)
        {
            var item = new BlogModel
            {
                BlogTitle = blogTitle,
                BlogAuthor = blogAuthor,
                BlogContent = blogContent
            };
            using IDbConnection db = new SqlConnection(ConnectionStrings.connectionString.ConnectionString);
            db.Open();
            string query = @"INSERT INTO [dbo].[BlogTable]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     VALUES
           (@BlogTitle
           ,@BlogAuthor
           ,@BlogContent)";
            var result = db.Execute(query, item);
            string message = result > 0 ? "Create successful" : "Create fail.";
            Console.WriteLine(message);
        }

    }
}

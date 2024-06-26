﻿using Dapper;
using NKKDotNetCore.ConsoleApp.Services;
using NKKDotNetCore.ConsoleApp.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NKKDotNetCore.ConsoleApp.DapperExamples
{
    internal class DapperExample
    {
        public void Run()
        {
            //Read();
            //Create("TestingDapper", "TestingDP", "TestingDp");
            //Edit(1);
            //Edit(3000);
            Update(1, "UpdateDap", "UpdateDap", "UpdateDap");
            Delete(1);
        }

        private void Read()
        {
            using IDbConnection db = new SqlConnection(ConnectionStrings.connectionString.ConnectionString);
            db.Open();
            List<BlogModel> model = db.Query<BlogModel>("select * from BlogTable").ToList();
            foreach (BlogModel item in model)
            {
                Console.WriteLine($"BlogID : {item.BlogId}");
                Console.WriteLine($"BlogTitle : {item.BlogTitle}");
                Console.WriteLine($"BlogAuthor : {item.BlogAuthor}");
                Console.WriteLine($"BlogContent : {item.BlogContent}");
                Console.WriteLine("-------------------------------");
            }
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

        private void Edit(int id)
        {
            IDbConnection db = new SqlConnection(ConnectionStrings.connectionString.ConnectionString);
            string message = string.Empty;
            db.Open();
            //BlogModel? model = db.Query<BlogModel>("select * from BlogTable where BlogId=@BlogId ", id).FirstOrDefault(); // error scalar variable declear
            BlogModel? model = db.Query<BlogModel>("select * from BlogTable where BlogId=@BlogId ", new BlogModel { BlogId = id })
                .FirstOrDefault();
            if (model == null)
            {
                message = "No Data Found.";
            }

            Console.WriteLine($"BlogID : {model.BlogId}");
            Console.WriteLine($"BlogTitle : {model.BlogTitle}");
            Console.WriteLine($"BlogAuthor : {model.BlogAuthor}");
            Console.WriteLine($"BlogContent : {model.BlogContent}");
            Console.WriteLine("-------------------------------");
        }

        private void Update(int id, string blogTitle, string blogAuthor, string blogContent)
        {
            var item = new BlogModel
            {
                BlogId = id,
                BlogTitle = blogTitle,
                BlogAuthor = blogAuthor,
                BlogContent = blogContent
            };
            using IDbConnection db = new SqlConnection(ConnectionStrings.connectionString.ConnectionString);
            db.Open();
            string query = @"UPDATE [dbo].[BlogTable]
            SET [BlogTitle] = @BlogTitle
              ,[BlogAuthor] = @BlogAuthor
              ,[BlogContent] = @BlogContent
             WHERE BlogId = @BlogId";
            var result = db.Execute(query, item);
            string message = result > 0 ? "Update successful" : "Update fail.";
            Console.WriteLine(message);
        }

        private void Delete(int id)
        {
            using IDbConnection db = new SqlConnection(ConnectionStrings.connectionString.ConnectionString);
            db.Open();
            string query = @"DELETE FROM [dbo].[BlogTable]
                            WHERE BlogId = @BlogId";
            var result = db.Execute(query, new BlogModel { BlogId = id });
            string message = result > 0 ? "Delete successful" : "Delete fail.";
            Console.WriteLine(message);

        }

    }
}

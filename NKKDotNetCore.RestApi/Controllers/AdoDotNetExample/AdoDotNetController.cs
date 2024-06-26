﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.IdentityModel.Tokens;
using NKKDotNetCore.RestApi.Model;
using NKKDotNetCore.RestApi.Services;
using System.Data;
using System.Data.SqlClient;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace NKKDotNetCore.RestApi.Controllers.AdoDotNetExample
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdoDotNetController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetBlog()
        {
            string query = "select * from BlogTable";
            var connection = new SqlConnection(ConnectionStrings.connectionString.ConnectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            connection.Close();
            List<BlogModel> lstBlog = new List<BlogModel>();
            //foreach (DataRow row in dt.Rows)
            //{
            //    BlogModel model = new BlogModel();
            //    model.BlogId = Convert.ToInt32(row["BlogId"]);
            //    model.BlogTitle = Convert.ToString(row["BlogId"]);
            //    model.BlogAuthor = Convert.ToString(row["BlogId"]);
            //    model.BlogContent = Convert.ToString(row["BlogId"]);
            //}
            lstBlog = dt.AsEnumerable().Select(dr => new BlogModel
            {
                BlogId = Convert.ToInt32(dr["BlogId"]),
                BlogTitle = Convert.ToString(dr["BlogTitle"]),
                BlogAuthor = Convert.ToString(dr["BlogAuthor"]),
                BlogContent = Convert.ToString(dr["BlogContent"]),

            }).ToList();
            return Ok(lstBlog);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            string query = "select * from BlogTable where BlogId = @BlogId";
            var connection = new SqlConnection(ConnectionStrings.connectionString.ConnectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogId", id);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            connection.Close();
            if (dt.Rows.Count == 0)
            {
                return NotFound("No data found");
            }
            var dr = dt.Rows[0];
            var item = new BlogModel
            {
                BlogId = Convert.ToInt32(dr["BlogID"]),
                BlogTitle = Convert.ToString(dr["BlogTitle"]),
                BlogAuthor = Convert.ToString(dr["BlogAuthor"]),
                BlogContent = Convert.ToString(dr["BlogContent"]),
            };
            return Ok(item);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBlog(int id, BlogModel reqModel)
        {
            string query = @"UPDATE [dbo].[BlogTable]
            SET [BlogTitle] = @BlogTitle
              ,[BlogAuthor] = @BlogAuthor
              ,[BlogContent] = @BlogContent
             WHERE BlogId = @BlogId";
            var connection = new SqlConnection(ConnectionStrings.connectionString.ConnectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogId", id);
            cmd.Parameters.AddWithValue("@BlogTitle", reqModel.BlogTitle);
            cmd.Parameters.AddWithValue("@BlogAuthor", reqModel.BlogAuthor);
            cmd.Parameters.AddWithValue("@BlogContent", reqModel.BlogContent);
            var result = cmd.ExecuteNonQuery();
            connection.Close();
            return Ok(result > 0 ? "Update success" : "Update fail.");

        }

        [HttpPatch("{id}")]
        public IActionResult PatchUpdate(int id, BlogModel reqModel)
        {
            string condition = string.Empty;
            if (!reqModel.BlogTitle.IsNullOrEmpty())
            {
                condition += " [BlogTitle] = @BlogTitle, ";
            }
            if (!reqModel.BlogAuthor.IsNullOrEmpty())
            {
                condition += " [BlogAuthor] = @BlogAuthor, ";
            }
            if (!reqModel.BlogContent.IsNullOrEmpty())
            {
                condition += " [BlogContent] = @BlogContent, ";
            }
            if (condition.Length == 0)
            {
                return NotFound("No data found.");
            }
            condition = condition.Substring(0, condition.Length - 2);
            string query = $@"UPDATE [dbo].[BlogTable]
            SET {condition}
             WHERE BlogId = @BlogId";
            var connection = new SqlConnection(ConnectionStrings.connectionString.ConnectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogId", id);
            if (!reqModel.BlogTitle.IsNullOrEmpty())
            {
                cmd.Parameters.AddWithValue("@BlogTitle", reqModel.BlogTitle);
            }
            if (!reqModel.BlogAuthor.IsNullOrEmpty())
            {
                cmd.Parameters.AddWithValue("@BlogAuthor", reqModel.BlogAuthor);
            }
            if (!reqModel.BlogContent.IsNullOrEmpty())
            {
                cmd.Parameters.AddWithValue("@BlogContent", reqModel.BlogContent);
            }
            var result = cmd.ExecuteNonQuery();

            connection.Close();
            return Ok(result > 0 ? "Patch Update success" : "Patch Update fail.");
        }

        [HttpPost]
        public IActionResult CreateBlog(BlogModel reqModel)
        {
            string query = @"INSERT INTO [dbo].[BlogTable]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     VALUES
           (@BlogTitle
           ,@BlogAuthor
           ,@BlogContent)";
            var connection = new SqlConnection(ConnectionStrings.connectionString.ConnectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogTitle", reqModel.BlogTitle);
            cmd.Parameters.AddWithValue("@BlogAuthor", reqModel.BlogAuthor);
            cmd.Parameters.AddWithValue("@BlogContent", reqModel.BlogContent);
            var result = cmd.ExecuteNonQuery();
            connection.Close();
            return Ok(result > 0 ? "Create success" : "Create fail.");


        }

        [HttpDelete("{id}")]
        public IActionResult BlogDelete(int id)
        {
            string query = @"DELETE FROM [dbo].[BlogTable]
                            WHERE BlogId = @BlogId";
            var connection = new SqlConnection(ConnectionStrings.connectionString.ConnectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogId", id);
            var result = cmd.ExecuteNonQuery();
            connection.Close();
            return Ok(result > 0 ? "Delete success" : "Delete fail.");
        }
    }
}

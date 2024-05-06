using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using NKKDotNetCore.RestApi.Model;
using NKKDotNetCore.RestApi.Services;
using System.Data;
using System.Data.SqlClient;

namespace NKKDotNetCore.RestApi.Controllers.DapperExample
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogDapperController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetBlog()
        {
            string query = "select * from BlogTable";
            using IDbConnection db = new SqlConnection(ConnectionStrings.connectionString.ConnectionString);
            List<BlogModel> lst = db.Query<BlogModel>(query).ToList();
            return Ok(lst);
        }

        [HttpGet("{id}")]
        public IActionResult GetBlogByID(int id)
        {
            string query = "select * from BlogTable where BlogId=@BlogId";
            using IDbConnection db = new SqlConnection(ConnectionStrings.connectionString.ConnectionString);
            var item = db.Query<BlogModel>(query, new BlogModel { BlogId = id }).FirstOrDefault();
            if (item is null)
            {
                return NotFound("No Data Found.");
            }
            return Ok(item);
        }

        [HttpPost]
        public IActionResult CreateBlog(BlogModel blog)
        {
            string query = @"INSERT INTO [dbo].[BlogTable]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     VALUES
           (@BlogTitle
           ,@BlogAuthor
           ,@BlogContent)";
            using IDbConnection db = new SqlConnection(ConnectionStrings.connectionString.ConnectionString);
            var result = db.Execute(query, blog);
            string message = result > 0 ? "Create successful" : "Create fail.";
            return Ok(message);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBlog(int id, BlogModel blog)
        {
            var item = FindById(id);
            if (item is null)
            {
                return NotFound("No Data Found.");
            }
            string query = @"UPDATE [dbo].[BlogTable]
            SET [BlogTitle] = @BlogTitle
              ,[BlogAuthor] = @BlogAuthor
              ,[BlogContent] = @BlogContent
             WHERE BlogId = @BlogId";
            blog.BlogId = id;
            using IDbConnection db = new SqlConnection(ConnectionStrings.connectionString.ConnectionString);
            var result = db.Execute(query, blog);
            string message = result > 0 ? "Update successful" : "Update fail.";
            return Ok(message);
        }

        [HttpPatch]
        public IActionResult PatchUpdateBlog(int id)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBlog(int id)
        {
            var item = FindById(id);
            if (item is null)
            {
                return NotFound("No Data Found.");
            }
            string query = @"DELETE FROM [dbo].[BlogTable]
                            WHERE BlogId = @BlogId";
            using IDbConnection db = new SqlConnection(ConnectionStrings.connectionString.ConnectionString);
            var result = db.Execute(query, new BlogModel { BlogId = id });
            string message = result > 0 ? "Delete successful" : "Delete fail.";
            return Ok(message);
        }

        private BlogModel? FindById(int id)
        {
            string query = "select * from BlogTable where BlogId=@BlogId";
            using IDbConnection db = new SqlConnection(ConnectionStrings.connectionString.ConnectionString);
            var item = db.Query<BlogModel>(query, new BlogModel { BlogId = id }).FirstOrDefault();

            return item;
        }
    }
}

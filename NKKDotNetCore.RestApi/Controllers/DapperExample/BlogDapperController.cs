using Dapper;
using Microsoft.AspNetCore.Http;
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
            return Ok();
        }

        [HttpPost]
        public IActionResult CreateBlog()
        {
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBlog(int id)
        {
            return Ok();
        }

        [HttpPatch]
        public IActionResult PatchUpdateBlog(int id)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBlog(int id)
        {
            return Ok();
        }
    }
}

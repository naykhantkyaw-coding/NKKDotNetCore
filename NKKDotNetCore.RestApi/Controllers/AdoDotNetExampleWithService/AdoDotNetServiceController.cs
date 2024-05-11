using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NKKDotNetCore.RestApi.Model;
using NKKDotNetCore.Shared.Services;

namespace NKKDotNetCore.RestApi.Controllers.AdoDotNetExampleWithService
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdoDotNetServiceController : ControllerBase
    {
        private readonly AdoDotNetService _service = new AdoDotNetService();

        [HttpGet]
        public IActionResult GetBlog()
        {
            string query = "select * from BlogTable";
            var result = _service.Query<BlogModel>(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetBlogById(int id)
        {
            string query = "select * from BlogTable where BlogId = @BlogId";
            var result = _service.QueryFirstOrDefault<BlogModel>(query, new AdoDotNetParamters("@BlogId", id));
            return Ok(result);
        }
    }
}

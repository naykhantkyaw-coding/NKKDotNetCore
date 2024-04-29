using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NKKDotNetCore.RestApi.Controllers.DapperExample
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogDapperController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetBlog()
        {
            return Ok();
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

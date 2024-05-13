using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NKKDotNetCore.RestApiWithNLayer.Features.Blog
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly BL_Blog _blBlog;

        public BlogController(BL_Blog blBlog)
        {
            _blBlog = blBlog;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var lst = _blBlog.GetAllBlogs();
            return Ok(lst);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var item = _blBlog.GetBlogById(id);
            return Ok(item);
        }
    }
}

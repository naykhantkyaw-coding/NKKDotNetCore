using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NKKDotNetCore.RestApi.DbContexts;

namespace NKKDotNetCore.RestApi.Controllers.EFCoreExample
{
    // domain https://localhost:7295 
    //end point ai/blog
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        public BlogController()
        {
            _appDbContext = new AppDbContext();
        }

        [HttpGet]
        public IActionResult Get()
        {
            var lst = _appDbContext.Blogs.ToList();
            return Ok(lst);
        }


    }
}

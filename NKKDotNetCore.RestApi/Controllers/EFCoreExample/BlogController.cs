using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NKKDotNetCore.RestApi.DbContexts;
using NKKDotNetCore.RestApi.Model;

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
            var lst = _appDbContext.Blogs.OrderByDescending(x => x.BlogId).ToList();
            if (lst.Count < 0)
            {
                return NotFound("No data found.");
            }
            return Ok(lst);
        }

        [HttpGet("id")]
        public IActionResult Get(int id)
        {
            var item = _appDbContext.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (item is null)
            {
                return NotFound("No data found.");
            }
            return Ok(item);
        }

        [HttpPost]
        public IActionResult Create(BlogModel reqModel)
        {
            string message = string.Empty;
            _appDbContext.Blogs.Add(reqModel);
            var result = _appDbContext.SaveChanges();
            message = result > 0 ? "Create success." : "Create fail.";
            return Ok(message);
        }


    }
}

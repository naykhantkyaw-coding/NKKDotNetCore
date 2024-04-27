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

        [HttpGet("{id}")]
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

        [HttpPut("{id}")]
        public IActionResult Update(int id, BlogModel reqModel)
        {
            string message = string.Empty;
            var item = _appDbContext.Blogs.Find(id);
            if (item is null)
            {
                return NotFound("No data found.");
            }
            item.BlogTitle = reqModel.BlogTitle;
            item.BlogAuthor = reqModel.BlogAuthor;
            item.BlogContent = reqModel.BlogContent;
            //_appDbContext.Update(item); // testing code
            var result = _appDbContext.SaveChanges();
            message = result > 0 ? "Update success." : "Update fail.";
            return Ok(message);

        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, BlogModel reqModel)
        {
            string message = string.Empty;
            var item = _appDbContext.Blogs.Find(id);
            if (item is null)
            {
                return NotFound("No data found.");
            }
            if (!string.IsNullOrEmpty(reqModel.BlogTitle))
            {
                item.BlogTitle = reqModel.BlogTitle;
            }
            if (!string.IsNullOrEmpty(reqModel.BlogAuthor))
            {
                item.BlogAuthor = reqModel.BlogAuthor;
            }
            if (!string.IsNullOrEmpty(reqModel.BlogContent))
            {
                item.BlogContent = reqModel.BlogContent;
            }
            //_appDbContext.Update(item); // testing code
            var result = _appDbContext.SaveChanges();
            message = result > 0 ? "Update success." : "Update fail.";
            return Ok(message);
        }


        [HttpDelete("id")]
        public IActionResult Delete(int id)
        {
            string message = string.Empty;
            var item = _appDbContext.Blogs.Find(id);
            if (item is null)
            {
                message = "Data not found";
            }
            _appDbContext.Remove(item!);
            var result = _appDbContext.SaveChanges();
            message = result > 0 ? "Create success." : "Create fail.";
            return Ok(message);
        }


    }
}

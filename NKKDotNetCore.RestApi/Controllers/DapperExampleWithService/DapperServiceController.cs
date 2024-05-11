using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NKKDotNetCore.RestApi.Model;
using NKKDotNetCore.Shared.Services;

namespace NKKDotNetCore.RestApi.Controllers.DapperExampleWithService
{
    [Route("api/[controller]")]
    [ApiController]
    public class DapperServiceController : ControllerBase
    {
        private readonly DapperService _dapperService = new DapperService();

        [HttpGet]
        public IActionResult GetBlogs()
        {
            string query = "select * from BlogTable";
            var lst = _dapperService.GetData<BlogModel>(query);
            return Ok(lst);
        }

        [HttpGet("{id}")]
        public IActionResult GetBlogs(int id)
        {
            string query = "select * from BlogTable where BlogId=@BlogId";
            var item = _dapperService.GetDataFirstOrDefault<BlogModel>(query, new BlogModel { BlogId = id });
            return Ok(item);
        }

        [HttpPost]
        public IActionResult Create(BlogModel model)
        {
            string query = @"INSERT INTO [dbo].[BlogTable]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     VALUES
           (@BlogTitle
           ,@BlogAuthor
           ,@BlogContent)";
            var result = _dapperService.Execute(query, model);
            string message = result > 0 ? "Create success." : "Create fail.";
            return Ok(message);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var item = FindById(id);
            if (item is null)
            {
                return NotFound("No Data Found.");
            }
            string query = @"DELETE FROM [dbo].[BlogTable]
                            WHERE BlogId = @BlogId";
            var result = _dapperService.Execute(query, new BlogModel { BlogId = id });
            string message = result > 0 ? "Delete Success." : "Delete fail.";
            return Ok(message);
        }

        private BlogModel? FindById(int id)
        {
            string query = "select * from BlogTable where BlogId=@BlogId";
            var item = _dapperService.GetDataFirstOrDefault<BlogModel>(query);
            return item;
        }
    }
}

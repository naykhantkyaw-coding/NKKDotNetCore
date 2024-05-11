using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
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

        [HttpPut("{id}")]
        public IActionResult Update(int id, BlogModel model)
        {
            var item = FindById(id);
            if (item is null)
            {
                return NotFound("No data found.");
            }
            string query = @"UPDATE [dbo].[BlogTable]
            SET [BlogTitle] = @BlogTitle
              ,[BlogAuthor] = @BlogAuthor
              ,[BlogContent] = @BlogContent
             WHERE BlogId = @BlogId";
            model.BlogId = id;
            var result = _dapperService.Execute(query, model);
            string message = result > 0 ? "Update successful" : "Update fail.";
            return Ok(message);
        }

        [HttpPatch("{id}")]
        public IActionResult PatchUpdate(int id, BlogModel model)
        {
            var item = FindById(id);
            if (item is null)
            {
                return NotFound("No data found.");
            }
            string condition = string.Empty;
            if (!model.BlogTitle.IsNullOrEmpty())
            {
                condition += " [BlogTitle] = @BlogTitle, ";
            }
            if (!model.BlogAuthor.IsNullOrEmpty())
            {
                condition += " [BlogAuthor] = @BlogAuthor, ";
            }
            if (!model.BlogContent.IsNullOrEmpty())
            {
                condition += " [BlogContent] = @BlogContent, ";
            }
            if (condition.Length == 0)
            {
                return NotFound("No data found.");
            }
            condition = condition.Substring(0, condition.Length - 2);
            model.BlogId = id;
            string query = $@"UPDATE [dbo].[BlogTable]
            SET {condition}
             WHERE BlogId = @BlogId";
            var result = _dapperService.Execute(query, model);
            string message = result > 0 ? "PatchUpdate successful" : "PatchUpdate fail.";
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

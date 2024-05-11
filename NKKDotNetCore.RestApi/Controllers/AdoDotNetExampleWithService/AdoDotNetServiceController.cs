using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
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

        [HttpPost]
        public IActionResult CreateBlog(BlogModel model)
        {
            string query = @"INSERT INTO [dbo].[BlogTable]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     VALUES
           (@BlogTitle
           ,@BlogAuthor
           ,@BlogContent)";
            var result = _service.Execute(query,
                new AdoDotNetParamters("@BlogTitle", model.BlogTitle),
                new AdoDotNetParamters("@BlogAuthor", model.BlogAuthor),
                new AdoDotNetParamters("@BlogContent", model.BlogContent));
            string message = result > 0 ? "Create Success." : "Create fail.";
            return Ok(message);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, BlogModel model)
        {
            var item = GetById(id);
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
            var result = _service.Execute(query,
                new AdoDotNetParamters("@BlogTitle", model.BlogTitle!),
                new AdoDotNetParamters("@BlogAuthor", model.BlogAuthor!),
                new AdoDotNetParamters("@BlogContent", model.BlogContent!),
                new AdoDotNetParamters("@BlogId", model.BlogId));
            string message = result > 0 ? "Update Success." : "Update fail.";
            return Ok(message);
        }

        [HttpPatch("{id}")]
        public IActionResult PatchUpdate(int id, BlogModel model)
        {
            var item = GetById(id);
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
            string query = $@"UPDATE [dbo].[BlogTable]
            SET {condition}
             WHERE BlogId = @BlogId";
            model.BlogId = id;
            int result = 0;
            if (!model.BlogTitle.IsNullOrEmpty())
            {
                result = _service.Execute(query,
                new AdoDotNetParamters("@BlogTitle", model.BlogTitle!),
                new AdoDotNetParamters("@BlogId", model.BlogId!));
            }
            if (!model.BlogAuthor.IsNullOrEmpty())
            {
                result = _service.Execute(query,
                new AdoDotNetParamters("@BlogAuthor", model.BlogAuthor!),
                new AdoDotNetParamters("@BlogId", model.BlogId!));
            }
            if (!model.BlogContent.IsNullOrEmpty())
            {
                result = _service.Execute(query,
                new AdoDotNetParamters("@BlogContent", model.BlogContent!),
                new AdoDotNetParamters("@BlogId", model.BlogId!));
            }
            string message = result > 0 ? "PatchUpdate Success." : "PatchUpdate fail.";
            return Ok(message);
        }

        [HttpDelete]
        public IActionResult DeleteBlog(int id)
        {
            var item = GetById(id);
            if (item is null)
            {
                return NotFound("No data found");
            }
            string query = @"DELETE FROM [dbo].[BlogTable]
                            WHERE BlogId = @BlogId";
            var result = _service.Execute(query, new AdoDotNetParamters("@BlogId", id));
            string message = result > 0 ? "Delete Success." : "Delete fail.";
            return Ok(message);
        }

        private BlogModel GetById(int id)
        {
            string query = "select * from BlogTable where BlogId = @BlogId";
            BlogModel? result = _service.QueryFirstOrDefault<BlogModel>(query, new AdoDotNetParamters("@BlogId", id));
            if (result is null)
            {
                return null;
            }
            return result;
        }
    }
}

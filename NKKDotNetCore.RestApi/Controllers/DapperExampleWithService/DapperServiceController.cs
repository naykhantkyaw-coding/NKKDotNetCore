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
    }
}

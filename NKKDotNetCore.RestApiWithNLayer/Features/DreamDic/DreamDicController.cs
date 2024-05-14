using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NKKDotNetCore.RestApiWithNLayer.Features.DreamDic
{
    [Route("api/[controller]")]
    [ApiController]
    public class DreamDicController : ControllerBase
    {
        private readonly BL_DreamDic _dream;

        public DreamDicController(BL_DreamDic dream)
        {
            _dream = dream;
        }

        [HttpGet]
        public async Task<IActionResult> GetBlogHeader()
        {
            var model = await _dream.GetAllDataAsync();
            return Ok(model!.BlogHeader);
        }

        [HttpGet("blogid")]
        public async Task<IActionResult> GetBlogHeader(int blogid)
        {
            var model = await _dream.GetAllDataAsync();
            return Ok(model!.BlogDetail.Where(x => x.BlogId == blogid).ToList());
        }

        [HttpGet("{searchText}")]
        public async Task<IActionResult> SearchDream(string searchText)
        {
            var model = await _dream.SearchByText(searchText);
            return Ok(model);
        }
    }
}

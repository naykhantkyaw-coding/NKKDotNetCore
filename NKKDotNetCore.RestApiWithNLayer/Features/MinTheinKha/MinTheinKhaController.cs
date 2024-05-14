using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NKKDotNetCore.RestApiWithNLayer.Features.Blog;

namespace NKKDotNetCore.RestApiWithNLayer.Features.MinTheinKha
{
    [Route("api/[controller]")]
    [ApiController]
    public class MinTheinKhaController : ControllerBase
    {
        private readonly BL_MinTheinKha _MinTheinKha;
        public MinTheinKhaController(BL_MinTheinKha minTheinKha)
        {
            _MinTheinKha = minTheinKha;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDataAsync()
        {
            var data = await _MinTheinKha.GetAllData();
            return Ok(data);
        }
    }
}

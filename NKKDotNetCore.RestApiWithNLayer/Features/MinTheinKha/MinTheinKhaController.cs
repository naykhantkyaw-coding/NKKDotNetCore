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

        #region Testing Code

        //[HttpGet]
        //public async Task<IActionResult> GetAllDataAsync()
        //{
        //    var data = await _MinTheinKha.GetAllData();
        //    return Ok(data);
        //}

        #endregion

        [HttpGet]
        public async Task<IActionResult> Questions()
        {
            var model = await _MinTheinKha.GetAllData();
            return Ok(model!.questions);
        }

        [HttpGet("GetNumberList")]
        public async Task<IActionResult> GetNumberList()
        {
            var model = await _MinTheinKha.GetAllData();
            return Ok(model!.numberList);
        }

        [HttpGet("{questionNo}/{no}")]
        public async Task<IActionResult> GetNumberList(int questionNo, int no)
        {
            var model = await _MinTheinKha.GetAllData();
            return Ok(model!.answers.FirstOrDefault(x => x.questionNo == questionNo && x.answerNo == no));
        }



    }
}

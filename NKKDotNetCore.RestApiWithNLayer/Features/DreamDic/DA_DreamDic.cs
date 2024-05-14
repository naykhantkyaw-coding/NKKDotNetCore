using Newtonsoft.Json;
using NKKDotNetCore.RestApiWithNLayer.Models;

namespace NKKDotNetCore.RestApiWithNLayer.Features.DreamDic
{
    public class DA_DreamDic
    {
        public async Task<DreamDicModel?> GetAllData()
        {
            var jsonStr = await File.ReadAllTextAsync("dream-dic.json");
            var model = JsonConvert.DeserializeObject<DreamDicModel>(jsonStr);
            return model;
        }
    }
}

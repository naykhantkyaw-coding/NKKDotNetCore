using Newtonsoft.Json;
using NKKDotNetCore.RestApiWithNLayer.Models;
using System.Text;
using System.Text.Json.Serialization;

namespace NKKDotNetCore.RestApiWithNLayer.Features.MinTheinKha
{
    public class DA_MinTheinKha
    {
        public async Task<MeinTheinKhaModel?> GetAllData()
        {
            var jsonStr = await File.ReadAllTextAsync("data.json");
            var model = JsonConvert.DeserializeObject<MeinTheinKhaModel>(jsonStr);
            return model;
        }
    }
}

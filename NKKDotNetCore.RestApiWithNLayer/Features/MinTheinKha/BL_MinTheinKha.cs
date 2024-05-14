using NKKDotNetCore.RestApiWithNLayer.Models;

namespace NKKDotNetCore.RestApiWithNLayer.Features.MinTheinKha
{
    public class BL_MinTheinKha
    {
        private readonly DA_MinTheinKha _minTheinKha;
        public BL_MinTheinKha(DA_MinTheinKha minTheinKha)
        {
            _minTheinKha = minTheinKha;
        }

        public async Task<MeinTheinKhaModel?> GetAllData()
        {
            var lst = await _minTheinKha.GetAllData();
            return lst;
        }
    }
}

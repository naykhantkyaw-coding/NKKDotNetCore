using NKKDotNetCore.RestApiWithNLayer.Models;

namespace NKKDotNetCore.RestApiWithNLayer.Features.DreamDic
{
    public class BL_DreamDic
    {
        private readonly DA_DreamDic _dream;

        public BL_DreamDic(DA_DreamDic dream)
        {
            _dream = dream;
        }

        public async Task<DreamDicModel?> GetAllDataAsync()
        {
            var model = await _dream.GetAllData();
            return model;
        }

        public async Task<List<string>> SearchByText(string searchText)
        {
            DreamDicModel? model = await _dream.GetAllData();
            var detailList = model!.BlogDetail;
            List<string> content = new();
            foreach (var item in detailList!)
            {
                if (item.BlogContent!.Contains(searchText))
                {
                    content.Add(item.BlogContent);
                }
            }
            return content;
        }
    }
}

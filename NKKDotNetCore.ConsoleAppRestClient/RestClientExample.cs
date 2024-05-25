using Dumpify;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NKKDotNetCore.ConsoleAppRestClient
{
    public class RestClientExample
    {
        private readonly RestClient _client = new RestClient(new Uri("https://localhost:7295"));
        private readonly string _endPoint = "api/blog";
        public async Task Run()
        {

        }

        private async Task ReadAsync()
        {
            //RestRequest request = new RestRequest(_endPoint);
            //var response = await _client.GetAsync(request);
            RestRequest request = new RestRequest(_endPoint, Method.Get);
            var response = await _client.ExecuteAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var jsonStr = response.Content;
                var lst = JsonConvert.DeserializeObject<List<BlogModel>>(jsonStr!);
                if (lst is not null)
                {
                    //foreach (var item in lst)
                    //{
                    //    Console.WriteLine(JsonConvert.SerializeObject(item));
                    //    Console.WriteLine($"Title => {item.BlogTitle}");
                    //    Console.WriteLine($"Author => {item.BlogAuthor}");
                    //    Console.WriteLine($"Content => {item.BlogContent}");

                    //}
                    lst.Dump();
                }

            }
        }

        private async Task EditAsync(int id)
        {
            RestRequest request = new RestRequest($"{_endPoint}/{id}", Method.Get);
            var response = await _client.ExecuteAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var jsonStr = response.Content;
                var model = JsonConvert.DeserializeObject<BlogModel>(jsonStr!);
                if (model is not null)
                {
                    //Console.WriteLine(JsonConvert.SerializeObject(model));
                    //Console.WriteLine($"Title => {model.BlogTitle}");
                    //Console.WriteLine($"Author => {model.BlogAuthor}");
                    //Console.WriteLine($"Content => {model.BlogContent}");
                    model.Dump();
                }

            }
        }

        private async Task DeleteAsync(int id)
        {
            RestRequest request = new RestRequest($"{_endPoint}/{id}", Method.Delete);
            var response = await _client.ExecuteAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var message = response.Content;
                Console.WriteLine(message);
            }
        }
    }
}

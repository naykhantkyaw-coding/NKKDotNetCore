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
            await ReadAsync();
            // await CreateAsync("rest", "rest", "rest");
            //await UpdateAsync(2, "restUp", "restUp", "restUp");
            //await GetyByIdAsync(2);
            //await DeleteAsync(2);
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

        private async Task CreateAsync(string title, string author, string content)
        {
            BlogModel model = new BlogModel
            {
                BlogContent = content,
                BlogAuthor = author,
                BlogTitle = title,
            };
            RestRequest request = new RestRequest(_endPoint, Method.Post);
            request.AddJsonBody(model);
            var response = await _client.ExecuteAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var message = response.Content;
                if (message is not null)
                {
                    Console.WriteLine(message);
                }
            }
        }

        private async Task GetByIdAsync(int id)
        {
            RestRequest request = new RestRequest($"{_endPoint}/{id}", Method.Get);
            var response = await _client.ExecuteAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var jsonStr = response.Content;
                var model = JsonConvert.DeserializeObject<BlogModel>(jsonStr!);
                if (model is not null)
                {
                    model.Dump();
                }

            }
        }

        private async Task UpdateAsync(int id, string title, string author, string content)
        {
            BlogModel model = new BlogModel
            {
                BlogContent = content,
                BlogAuthor = author,
                BlogTitle = title,
            };
            RestRequest request = new RestRequest($"{_endPoint}/{id}", Method.Put);
            request.AddJsonBody(model);
            var response = await _client.ExecuteAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var message = response.Content;
                if (message is not null)
                {
                    Console.WriteLine(message);
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

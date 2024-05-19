using Dumpify;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace NKKDotNetCore.ConsoleAppHttpClient
{
    public class HttpClintExample
    {
        private readonly HttpClient _clinet = new HttpClient() { BaseAddress = new Uri("https://localhost:7295") };
        private readonly string _endPoint = "api/blog";

        public async Task RunAsync()
        {
            //await ReadAsync();
            //Console.WriteLine();

            //Console.WriteLine("GetBy ID");
            //await GetByIdAsync(2);
            //Console.WriteLine();

            //Console.WriteLine("Create");
            //await CreateAsync("HttpClient", "AAHttp", "AAContaent");
            //Console.WriteLine();

            //Console.WriteLine("PutUpdate");
            //await UpdateAsync(2, "HttpClient", "AAHttp", "AAContaent");
            //Console.WriteLine();

            //Console.WriteLine("PutUpdate");
            //await PatchUpdateAsync(2, "TTE");
            //Console.WriteLine();

            //Console.WriteLine("Delete");
            //await DeleteAsync(10);
        }

        private async Task ReadAsync()
        {
            var response = await _clinet.GetAsync(_endPoint);
            if (response.IsSuccessStatusCode)
            {
                string jsonStr = await response.Content.ReadAsStringAsync();
                var lst = JsonConvert.DeserializeObject<List<BlogModel>>(jsonStr);
                lst.Dump();
            }
        }

        private async Task GetByIdAsync(int id)
        {
            var response = await _clinet.GetAsync($"{_endPoint}/{id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonStr = await response.Content.ReadAsStringAsync();
                var item = JsonConvert.DeserializeObject<BlogModel>(jsonStr);
                item.Dump();
            }
        }

        private async Task CreateAsync(string title, string author, string content)
        {
            BlogModel model = new BlogModel
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };
            var jsonStr = JsonConvert.SerializeObject(model);
            HttpContent httpContent = new StringContent(jsonStr, Encoding.UTF8, Application.Json);
            var response = await _clinet.PostAsync(_endPoint, httpContent);
            if (response.IsSuccessStatusCode)
            {
                string? message = await response.Content.ReadAsStringAsync();
                Console.WriteLine(message);
            }
        }

        private async Task UpdateAsync(int id, string title, string author, string content)
        {
            BlogModel model = new BlogModel
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };
            var jsonStr = JsonConvert.SerializeObject(model);
            HttpContent httpContent = new StringContent(jsonStr, Encoding.UTF8, Application.Json);
            var response = await _clinet.PutAsync($"{_endPoint}/{id}", httpContent);
            if (response.IsSuccessStatusCode)
            {
                string? message = await response.Content.ReadAsStringAsync();
                Console.WriteLine(message);
            }
        }

        private async Task PatchUpdateAsync(int id, string title = null, string author = null, string content = null)
        {
            BlogModel model = new BlogModel();
            if (!string.IsNullOrEmpty(title))
            {
                model.BlogTitle = title;
            }
            if (!string.IsNullOrEmpty(author))
            {
                model.BlogAuthor = author;
            }
            if (!string.IsNullOrEmpty(content))
            {
                model.BlogContent = content;
            }
            var jsonStr = JsonConvert.SerializeObject(model);
            HttpContent httpContent = new StringContent(jsonStr, Encoding.UTF8, Application.Json);
            var response = await _clinet.PatchAsync($"{_endPoint}/{id}", httpContent);
            if (response.IsSuccessStatusCode)
            {
                string? message = await response.Content.ReadAsStringAsync();
                Console.WriteLine(message);
            }
        }

        private async Task DeleteAsync(int id)
        {
            var response = await _clinet.DeleteAsync($"{_endPoint}/{id}");
            if (response.IsSuccessStatusCode)
            {
                string? message = await response.Content.ReadAsStringAsync();
                Console.WriteLine(message);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NKKDotNetCore.ConsoleAppHttpClient
{
    public class HttpClintExample
    {
        private readonly HttpClient _clinet = new HttpClient() { BaseAddress = new Uri("https://localhost:7295") };
        private readonly string _endPoint = "api/blog";

        public void RunAsync()
        {

        }

        private async Task ReadAsync()
        {
            var response = await _clinet.GetAsync(_endPoint);
            if (response.IsSuccessStatusCode)
            {
                string jsonStr = await response.Content.ReadAsStringAsync();
            }
        }
    }
}

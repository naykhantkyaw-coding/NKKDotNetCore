using NKKDotNetCore.ConsoleApp.EfCoreDbContext;
using NKKDotNetCore.ConsoleApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NKKDotNetCore.ConsoleApp
{
    internal class EfCoreExample
    {
        private readonly AppDbContext db = new AppDbContext();
        public void Run()
        {
            Read();
        }
        private void Read()
        {
            var result = db.Blogs.ToList();
            if (result.Count > 0)
            {
                foreach (BlogModel item in result)
                {
                    Console.WriteLine($"BlogID : {item.BlogId}");
                    Console.WriteLine($"BlogTitle : {item.BlogTitle}");
                    Console.WriteLine($"BlogAuthor : {item.BlogAuthor}");
                    Console.WriteLine($"BlogContent : {item.BlogContent}");
                    Console.WriteLine("-------------------------------");
                }
            }
        }
    }
}

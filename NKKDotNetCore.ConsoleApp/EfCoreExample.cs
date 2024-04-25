using Microsoft.EntityFrameworkCore.Update.Internal;
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
            Edit(1);
            Create("Efcore1", "Efcore1", "Efcore1");
            Update(2);
            Delete(1);
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

        private void Edit(int id)
        {
            string message = string.Empty;
            var result = db.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (result is null)
            {
                message = "No Data Found.";
                goto Result;
            }
            Console.WriteLine($"BlogID : {result.BlogId}");
            Console.WriteLine($"BlogTitle : {result.BlogTitle}");
            Console.WriteLine($"BlogAuthor : {result.BlogAuthor}");
            Console.WriteLine($"BlogContent : {result.BlogContent}");
            Console.WriteLine("-------------------------------");
        Result:
            Console.WriteLine(message);
        }

        private void Create(string blogTitle, string blogAuthor, string blogContent)
        {
            string message = string.Empty;
            var item = new BlogModel
            {
                BlogTitle = blogTitle,
                BlogAuthor = blogAuthor,
                BlogContent = blogContent
            };
            db.Blogs.Add(item);
            var rsult = db.SaveChanges();
            message = rsult > 0 ? "Create success" : "Create fail.";
            Console.WriteLine(message);
        }
    }
}

// See https://aka.ms/new-console-template for more information
using NKKDotNetCore.Nlayer.BusinessLogic.Services;

Console.WriteLine("Hello, World!");

BL_Blog blog = new BL_Blog();
var data = blog.GetAllData();

foreach (var item in data)
{
    Console.WriteLine($"Blog ID => {item.BlogId}");
    Console.WriteLine($"Blog BlogTitle => {item.BlogTitle}");
    Console.WriteLine($"Blog BlogAuthor => {item.BlogAuthor}");
    Console.WriteLine($"Blog BlogContent => {item.BlogContent}");
}

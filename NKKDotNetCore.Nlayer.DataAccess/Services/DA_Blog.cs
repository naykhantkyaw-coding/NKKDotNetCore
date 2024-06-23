using NKKDotNetCore.Nlayer.DataAccess.Db;
using NKKDotNetCore.Nlayer.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NKKDotNetCore.Nlayer.DataAccess.Services;
public class DA_Blog
{
    private readonly AppDbContext _context;
    public DA_Blog()
    {
        _context = new AppDbContext();
    }

    public List<BlogModel> GetAllData()
    {
        List<BlogModel> model = new List<BlogModel>();
        model = _context.Blogs.ToList();
        return model;
    }

    public BlogModel? GetDataById(int id)
    {
        BlogModel? model = new();
        if (id > 0)
        {
            model = _context.Blogs.FirstOrDefault(x => x.BlogId == id);
        }
        return model;
    }

    public string CreateData(BlogModel model)
    {
        int result = 0;
        if (model is not null)
        {
            _context.Blogs.Add(model);
            result = _context.SaveChanges();
        }
        return result > 0 ? "Create success." : "Create fail.";
    }

    public string UpdateData(int id, BlogModel model)
    {
        int result = 0;
        var item = GetDataById(id);
        if (item is not null)
        {
            item.BlogId = id;
            item.BlogTitle = model.BlogTitle;
            item.BlogAuthor = model.BlogAuthor;
            item.BlogContent = model.BlogContent;
        }
        _context.Update(item!);
        result = _context.SaveChanges();
        return result > 0 ? "Update success." : "Update fail.";
    }

    public string DeleteData(int id)
    {
        int result = 0;
        var model = GetDataById(id);
        if (model is not null)
        {
            _context.Remove(model);
            result = _context.SaveChanges();
        }
        return result > 0 ? "Delete success." : "Delete fail.";
    }
}

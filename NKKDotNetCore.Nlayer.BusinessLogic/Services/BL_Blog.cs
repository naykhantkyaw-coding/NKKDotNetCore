using NKKDotNetCore.Nlayer.DataAccess.Models;
using NKKDotNetCore.Nlayer.DataAccess.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NKKDotNetCore.Nlayer.BusinessLogic.Services;
public class BL_Blog
{
    private readonly DA_Blog _daBlog;

    public BL_Blog()
    {
        _daBlog = new DA_Blog();
    }

    public List<BlogModel> GetAllData()
    {
        var model = _daBlog.GetAllData();
        return model;
    }

    public BlogModel? GetDataById(int id)
    {
        var model = _daBlog.GetDataById(id);
        return model;
    }

    public string CreateData(BlogModel model)
    {
        var result = _daBlog.CreateData(model);
        return result;
    }

    public string UpdateData(int id, BlogModel model)
    {
        var result = _daBlog.UpdateData(id, model);
        return result;
    }

    public string DeleteData(int id)
    {
        var result = _daBlog.DeleteData(id);
        return result;
    }
}

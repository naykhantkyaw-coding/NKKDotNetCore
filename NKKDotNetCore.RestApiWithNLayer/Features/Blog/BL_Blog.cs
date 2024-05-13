using NKKDotNetCore.RestApiWithNLayer.EFAppDbContextModels;

namespace NKKDotNetCore.RestApiWithNLayer.Features.Blog
{
    public class BL_Blog
    {
        private readonly DA_Blog _daBlog;
        public BL_Blog(DA_Blog daBlog)
        {
            _daBlog = daBlog;
        }

        public List<BlogTable> GetAllBlogs()
        {
            var lst = _daBlog.GetAllBlog();
            return lst;
        }

        public BlogTable? GetBlogById(int id)
        {
            var item = _daBlog.GetBlogById(id);
            return item;
        }

        public string CreateBlog(BlogTable model)
        {
            var result = _daBlog.CreateBlog(model);
            return result;
        }
        public string UpdateBlog(int id, BlogTable model)
        {
            var result = _daBlog.UpdateBlog(id, model);
            return result;
        }

        public string DeleteBlog(int id)
        {
            var result = _daBlog.DeleteBlog(id);
            return result;
        }

    }
}

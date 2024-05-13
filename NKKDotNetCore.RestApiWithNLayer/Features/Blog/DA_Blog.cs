using NKKDotNetCore.RestApiWithNLayer.EFAppDbContextModels;

namespace NKKDotNetCore.RestApiWithNLayer.Features.Blog
{
    public class DA_Blog
    {
        private readonly AppDbContext _dbContext;

        public DA_Blog(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<BlogTable> GetAllBlog()
        {
            List<BlogTable> model = new();
            try
            {
                model = _dbContext.BlogTables.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return model;
        }

        public BlogTable? GetBlogById(int id)
        {
            BlogTable? model = new();
            try
            {
                if (id > 0)
                {
                    model = _dbContext.BlogTables.Find(id);
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            return model;
        }

        public string CreateBlog(BlogTable model)
        {
            _dbContext.BlogTables.Add(model);
            var result = _dbContext.SaveChanges();
            return result > 0 ? "Create success." : "Create fail.";
        }

        public string UpdateBlog(int id, BlogTable model)
        {
            int result = 0;
            try
            {
                var item = _dbContext.BlogTables.Find(id);
                if (item is null)
                {
                    result = 0;
                }
                item.BlogTitle = model.BlogTitle;
                item.BlogAuthor = model.BlogAuthor;
                item.BlogContent = model.BlogContent;
                _dbContext.Update(item);
                result = _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result > 0 ? "Update success." : "Update fail.";

        }

        public string DeleteBlog(int id)
        {
            int result = 0;
            try
            {
                BlogTable? item = _dbContext.BlogTables.Find(id);
                if (item is null)
                {
                    result = 0;
                }
                _dbContext.Remove(item!);
                result = _dbContext.SaveChanges();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return result > 0 ? "Delete success." : "Delete fail.";
        }
    }
}

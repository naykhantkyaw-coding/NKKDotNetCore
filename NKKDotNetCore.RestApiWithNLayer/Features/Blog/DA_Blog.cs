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
    }
}

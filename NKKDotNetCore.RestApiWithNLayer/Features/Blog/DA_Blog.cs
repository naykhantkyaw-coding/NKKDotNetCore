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
            var lst = _dbContext.BlogTables.ToList();
            return lst;
        }
    }
}

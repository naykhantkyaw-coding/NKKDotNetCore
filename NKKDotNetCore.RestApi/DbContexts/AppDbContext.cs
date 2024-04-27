using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NKKDotNetCore.RestApi.Services;
using NKKDotNetCore.RestApi.Model;

namespace NKKDotNetCore.RestApi.DbContexts
{
    internal class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionStrings.connectionString.ConnectionString);
        }
        public DbSet<BlogModel> Blogs { get; set; }
    }
}

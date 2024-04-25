using Microsoft.EntityFrameworkCore;
using NKKDotNetCore.ConsoleApp.Connection;
using NKKDotNetCore.ConsoleApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NKKDotNetCore.ConsoleApp.EfCoreDbContext
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

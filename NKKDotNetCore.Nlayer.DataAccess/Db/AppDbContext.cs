using Microsoft.EntityFrameworkCore;
using NKKDotNetCore.Nlayer.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NKKDotNetCore.Nlayer.DataAccess.Db
{
    internal class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder); // default 
            optionsBuilder.UseSqlServer(ConnectionString.connection.ConnectionString);
        }

        public DbSet<BlogModel> Blogs { get; set; }
    }
}

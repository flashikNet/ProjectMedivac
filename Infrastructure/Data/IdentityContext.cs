using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class IdentityContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Team> Teams { get; set; } = null!;
        public IdentityContext() {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=../DataBase/Identity.db");
        }

    }
}

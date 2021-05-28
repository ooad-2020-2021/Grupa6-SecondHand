using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SecondHand.Models;

namespace SecondHand.Data
{
    public class SecondHandContext : DbContext
    {
        //public DbSet<Product> Products{ get; set; }
        //public DbSet<Accessories> Accessories { get; set; }
        //public DbSet<Shoes> Shoes{ get; set; }
        //public DbSet<Clothing> Clothing { get; set; }

        public SecondHandContext (DbContextOptions<SecondHandContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
        }

        public DbSet<SecondHand.Models.User> User { get; set; }
    }
}

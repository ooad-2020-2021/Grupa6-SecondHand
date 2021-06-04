using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SecondHand.Models;

namespace SecondHand.Data
{
    public class SecondHandContext : IdentityDbContext
    {
        public DbSet<Product> Products{ get; set; }
        public DbSet<Accessories> Accessories { get; set; }
        public DbSet<Shoes> Shoes{ get; set; }
        public DbSet<Clothing> Clothing { get; set; }
        public DbSet<Review> Reviews{ get; set; }
        public DbSet<Transactions> Transactions { get; set; }


        public SecondHandContext (DbContextOptions<SecondHandContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<Review>().ToTable("Review");
            modelBuilder.Entity<Transactions>().ToTable("Transactions");
            modelBuilder.Entity<Cart>().ToTable("Cart");

            base.OnModelCreating(modelBuilder);

        }



        public DbSet<SecondHand.Models.Cart> Cart { get; set; }
    }
}

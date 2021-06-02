﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SecondHand.Models;

namespace SecondHand.Data
{
    public class SecondHandContext : DbContext
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
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<Review>().ToTable("Review");
            modelBuilder.Entity<Transactions>().ToTable("Transactions");
            modelBuilder.Entity<Administrator>().ToTable("Administrator");

        }

        public DbSet<SecondHand.Models.User> User { get; set; }

        public DbSet<SecondHand.Models.Administrator> Administrator { get; set; }
    }
}
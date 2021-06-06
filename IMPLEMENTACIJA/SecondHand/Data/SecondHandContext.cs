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
        public DbSet<Accessories> Accessories { get; set; }
        public DbSet<Shoes> Shoes{ get; set; }
        public DbSet<Clothing> Clothing { get; set; }
        public DbSet<Review> Reviews{ get; set; }
        public DbSet<Transactions> Transactions { get; set; }
        public DbSet<Cart> Cart { get; set; }

        public SecondHandContext (DbContextOptions<SecondHandContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                if (entity.BaseType == null)
                {
                    entity.SetTableName(entity.DisplayName());
                }
            }
            base.OnModelCreating(modelBuilder);

        }

        public DbSet<SecondHand.Models.Product> Product { get; set; }

       

    }
}

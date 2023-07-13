using Microsoft.EntityFrameworkCore;
using Store.Domain.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Data
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Characteristic> Characteristics { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options)
        {
            //Database.Migrate();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasMany(c => c.Characteristics)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}

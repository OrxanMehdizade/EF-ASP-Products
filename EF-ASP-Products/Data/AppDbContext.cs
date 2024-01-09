using EF_ASP_Products.Models;
using Microsoft.EntityFrameworkCore;

namespace EF_ASP_Products.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categorys { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasOne(p=>p.Category)
                .WithMany(p=>p.Products)
                .HasForeignKey(p=>p.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

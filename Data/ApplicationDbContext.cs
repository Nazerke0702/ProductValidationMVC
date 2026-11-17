using Microsoft.EntityFrameworkCore;
using ProductValidationMVC.Models;

namespace ProductValidationMVC.Data;

public sealed class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Product> Products => Set<Product>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Product>(entity =>
        {
            entity.Property(product => product.Name).HasMaxLength(100).IsRequired();
            entity.Property(product => product.Description).HasMaxLength(500);
            entity.Property(product => product.Price).HasPrecision(10, 2);
            entity.Property(product => product.Category).HasMaxLength(80).IsRequired();
            entity.Property(product => product.Email).HasMaxLength(254).IsRequired();
            entity.HasData(
                new Product { Id = 1, Name = "Қолдан жасалған кесе", Description = "Керамикадан жасалған, күнделікті қолдануға ыңғайлы.", Price = 4500m, Quantity = 24, Category = "Үй бұйымдары", Email = "seller@example.kz", CreatedDate = new DateTime(2026, 1, 10, 9, 0, 0, DateTimeKind.Utc) },
                new Product { Id = 2, Name = "Көк былғары дәптер", Description = "Қатты мұқабалы, 160 бет.", Price = 3200m, Quantity = 40, Category = "Кеңсе тауарлары", Email = "shop@example.kz", CreatedDate = new DateTime(2026, 2, 15, 9, 0, 0, DateTimeKind.Utc) },
                new Product { Id = 3, Name = "Жүн шарф", Description = "Жұмсақ табиғи жүннен тоқылған.", Price = 8900m, Quantity = 12, Category = "Киім", Email = "hello@example.kz", CreatedDate = new DateTime(2026, 3, 1, 9, 0, 0, DateTimeKind.Utc) });
        });
    }
}

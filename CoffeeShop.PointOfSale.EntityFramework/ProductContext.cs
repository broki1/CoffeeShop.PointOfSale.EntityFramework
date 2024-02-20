using CoffeeShop.PointOfSale.EntityFramework.Model;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.PointOfSale.EntityFramework;

internal class ProductContext : DbContext
{

    internal DbSet<Product> Products { get; set; }
    internal DbSet<Category> Categories { get; set; }
    internal DbSet<Order> Orders { get; set; }
    internal DbSet<OrderProduct> OrderProducts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS; Initial Catalog=Products; Integrated Security=true;Trusted_Connection=True;Encrypt=False");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OrderProduct>().HasKey(op => new { op.ProductId, op.OrderId });

        modelBuilder.Entity<OrderProduct>()
            .HasOne<Order>(op => op.Order)
            .WithMany(o => o.OrderProducts)
            .HasForeignKey(op => op.OrderId);

        modelBuilder.Entity<OrderProduct>()
            .HasOne<Product>(op => op.Product)
            .WithMany(p => p.OrderProducts)
            .HasForeignKey(op => op.ProductId);

        modelBuilder.Entity<Product>()
            .HasOne<Category>(p => p.Category)
            .WithMany(c => c.Products)
            .HasForeignKey(p => p.CategoryId);

        modelBuilder.Entity<Category>()
            .HasData(new List<Category>
            {
                new Category
                {
                    CategoryId = 1,
                    Name = "Coffee",
                },
                new Category
                {
                    CategoryId = 2,
                    Name = "Candy"
                }
            });

        modelBuilder.Entity<Product>()
            .HasData(new List<Product>
            {
                new Product
                {
                    ProductId = 1,
                    Name = "Cappuccino",
                    Price = 2.99m,
                    CategoryId = 1
                },
                new Product
                {
                    ProductId = 2,
                    Name = "Latte",
                    Price = 5.00m,
                    CategoryId = 1
                },
                new Product
                {
                    ProductId = 3,
                    Name = "Sour Patch Kids",
                    Price = 1.50m,
                    CategoryId = 2
                },
                new Product
                {
                    ProductId = 4,
                    Name = "Skittles",
                    Price = 1.00m,
                    CategoryId = 2
                }
            });
    }
}

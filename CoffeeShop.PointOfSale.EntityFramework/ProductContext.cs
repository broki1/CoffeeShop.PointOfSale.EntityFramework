using CoffeeShop.PointOfSale.EntityFramework.Model;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.PointOfSale.EntityFramework;

internal class ProductContext : DbContext
{

    internal DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS; Initial Catalog=Products; Integrated Security=true;Trusted_Connection=True;Encrypt=False");
    }
}

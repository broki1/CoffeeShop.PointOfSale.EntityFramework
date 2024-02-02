
using CoffeeShop.PointOfSale.EntityFramework.Model;
using Spectre.Console;

namespace CoffeeShop.PointOfSale.EntityFramework;

internal class ProductController
{
    internal static void AddProduct()
    {
        var productName = AnsiConsole.Ask<string>("Product Name:");
        using var db = new ProductContext();

        var product = new Product { Name = productName };

        db.Products.Add(product);

        db.SaveChanges();
    }

    internal static void DeleteProduct()
    {
        throw new NotImplementedException();
    }

    internal static void GetProductById()
    {
        throw new NotImplementedException();
    }

    internal static List<Product> GetProducts()
    {
        using var db = new ProductContext();

        var products = db.Products.ToList();

        return products;
    }

    internal static void UpdateProduct()
    {
        throw new NotImplementedException();
    }
}

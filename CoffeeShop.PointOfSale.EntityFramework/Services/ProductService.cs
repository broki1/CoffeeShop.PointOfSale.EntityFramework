using CoffeeShop.PointOfSale.EntityFramework.Controllers;
using CoffeeShop.PointOfSale.EntityFramework.Model;
using Spectre.Console;

namespace CoffeeShop.PointOfSale.EntityFramework.Services;

internal class ProductService
{

    internal static void InsertProduct()
    {
        var product = new Product();

        var productName = AnsiConsole.Ask<string>("Product Name:");
        var productPrice = AnsiConsole.Ask<decimal>("Product Price:");
        var category = CategoryService.GetCategoryOptionInput();

        product.Name = productName;
        product.Price = productPrice;
        product.CategoryId = category.CategoryId;

        ProductController.AddProduct(product);
    }

    internal static void DeleteProduct()
    {
        var product = GetProductOptionInput();
        ProductController.DeleteProduct(product);
    }

    internal static void GetProduct()
    {
        var product = GetProductOptionInput();
        UserInterface.ShowProduct(product);
    }

    internal static void GetAllProducts()
    {
        var products = ProductController.GetProducts();
        UserInterface.ShowProductTable(products);
    }

    internal static void UpdateProduct()
    {
        var product = GetProductOptionInput();

        var productName = AnsiConsole.Confirm("Update name?") ? AnsiConsole.Ask<string>("Product's New Name:") : product.Name;
        var productPrice = AnsiConsole.Confirm("Update price?") ? AnsiConsole.Ask<decimal>("Product's New Price:") : product.Price;
        var productCategory = AnsiConsole.Confirm("Update category?") ? CategoryService.GetCategoryOptionInput() : product.Category;

        product.Name = productName;
        product.Price = productPrice;
        product.Category = productCategory;

        ProductController.UpdateProduct(product);
    }

    internal static Product GetProductOptionInput()
    {
        var products = ProductController.GetProducts();
        var productsArray = products.Select(x => x.Name).ToArray();

        var option = AnsiConsole.Prompt(new SelectionPrompt<string>()
            .Title("Choose Product")
            .AddChoices(productsArray));

        var id = products.Single(x => x.Name == option).ProductId;

        var product = ProductController.GetProductById(id);

        return product;
    }

}

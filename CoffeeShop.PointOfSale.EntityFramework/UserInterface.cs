﻿using CoffeeShop.PointOfSale.EntityFramework.DTO;
using CoffeeShop.PointOfSale.EntityFramework.Model;
using CoffeeShop.PointOfSale.EntityFramework.Services;
using Spectre.Console;
using System.Globalization;
using static CoffeeShop.PointOfSale.EntityFramework.Enums;

namespace CoffeeShop.PointOfSale.EntityFramework;

internal class UserInterface
{

    static internal void MainMenu()
    {
        var isAppRunning = true;

        while (isAppRunning)
        {
            Console.Clear();

            var option = AnsiConsole.Prompt(
                new SelectionPrompt<MainMenuOptions>()
                .Title("What would you like to do?")
                .AddChoices(MainMenuOptions.ManageCategories,
                MainMenuOptions.ManageProducts,
                MainMenuOptions.ManageOrders,
                MainMenuOptions.Quit));

            switch (option)
            {
                case MainMenuOptions.ManageCategories:
                    CategoriesMenu();
                    break;
                case MainMenuOptions.ManageProducts:
                    ProductsMenu();
                    break;
                case MainMenuOptions.ManageOrders:
                    OrdersMenu();
                    break;
                case MainMenuOptions.Quit:
                    Console.WriteLine("Goodbye.");
                    isAppRunning = false;
                    break;
            }
        }
    }

    private static void OrdersMenu()
    {
        var inOrdersMenu = true;

        while (inOrdersMenu)
        {
            Console.Clear();
            var option = AnsiConsole.Prompt(
            new SelectionPrompt<OrderMenu>()
            .Title("What would you like to do?")
            .AddChoices(
            OrderMenu.AddOrder,
            OrderMenu.ViewOrders,
            OrderMenu.ViewOrder,
            OrderMenu.GoBack
            ));

            switch (option)
            {
                case OrderMenu.AddOrder:
                    OrderService.InsertOrder();
                    break;
                case OrderMenu.ViewOrders:
                    OrderService.GetOrders();
                    break;
                case OrderMenu.ViewOrder:
                    OrderService.GetOrder();
                    break;
                case OrderMenu.GoBack:
                    inOrdersMenu = false;
                    break;
            }
        }
    }

    private static void ProductsMenu()
    {
        var inProductsMenu = true;

        while (inProductsMenu)
        {
            Console.Clear();
            var option = AnsiConsole.Prompt(
            new SelectionPrompt<ProductMenu>()
            .Title("What would you like to do?")
            .AddChoices(
            ProductMenu.AddProduct,
            ProductMenu.DeleteProduct,
            ProductMenu.UpdateProduct,
            ProductMenu.ViewProduct,
            ProductMenu.ViewAllProducts,
            ProductMenu.GoBack));

            switch (option)
            {
                case ProductMenu.AddProduct:
                    ProductService.InsertProduct();
                    break;
                case ProductMenu.DeleteProduct:
                    ProductService.DeleteProduct();
                    break;
                case ProductMenu.UpdateProduct:
                    ProductService.UpdateProduct();
                    break;
                case ProductMenu.ViewProduct:
                    ProductService.GetProduct();
                    break;
                case ProductMenu.ViewAllProducts:
                    ProductService.GetAllProducts();
                    break;
                case ProductMenu.GoBack:
                    inProductsMenu = false;
                    break;
            }
        }
    }

    private static void CategoriesMenu()
    {
        var inCategoriesMenu = true;

        while (inCategoriesMenu)
        {
            Console.Clear();
            var option = AnsiConsole.Prompt(
            new SelectionPrompt<CategoryMenu>()
            .Title("What would you like to do?")
            .AddChoices(CategoryMenu.AddCategory,
            CategoryMenu.DeleteCategory,
            CategoryMenu.UpdateCategory,
            CategoryMenu.ViewCategory,
            CategoryMenu.ViewAllCategories,
            CategoryMenu.GoBack));

            switch (option)
            {
                case CategoryMenu.AddCategory:
                    CategoryService.InsertCategory();
                    break;
                case CategoryMenu.DeleteCategory:
                    CategoryService.DeleteCategory();
                    break;
                case CategoryMenu.UpdateCategory:
                    CategoryService.UpdateCategory();
                    break;
                case CategoryMenu.ViewCategory:
                    CategoryService.GetCategory();
                    break;
                case CategoryMenu.ViewAllCategories:
                    CategoryService.GetCategories();
                    break;
                case CategoryMenu.GoBack:
                    inCategoriesMenu = false;
                    break;
            }
        }
    }

    public static void ShowProductTable(List<Product> products)
    {

        var table = new Table();

        table.AddColumn("Id");
        table.AddColumn("Name");
        table.AddColumn("Price");
        table.AddColumn("Category");

        foreach (var product in products)
        {
            table.AddRow(product.ProductId.ToString(), product.Name, product.Price.ToString("C2", CultureInfo.CurrentCulture), product.Category.Name);
        }

        AnsiConsole.Write(table);

        Console.WriteLine("\nPress any key to continue");
        Console.ReadKey();
    }

    public static void ShowCategoryTable(List<Category> categories)
    {
        var table = new Table();

        table.AddColumn("Id");
        table.AddColumn("Name");

        foreach (var category in categories)
        {
            table.AddRow(category.CategoryId.ToString(), category.Name);
        }

        AnsiConsole.Write(table);

        Console.WriteLine("\nPress any key to continue");
        Console.ReadKey();
    }

    internal static void ShowOrdersTable(List<Order> orders)
    {
        var table = new Table();
        table.AddColumn("Id");
        table.AddColumn("Date");
        table.AddColumn("Count");
        table.AddColumn("Total Price");

        foreach (var order in orders)
        {
            table.AddRow(order.OrderId.ToString(), order.CreatedDate.ToString(), 
                order.OrderProducts.Sum(x=> x.Quantity).ToString(), order.TotalPrice.ToString());
        }

        AnsiConsole.Write(table);

        Console.WriteLine("\nPress any key to continue");
        Console.ReadKey();
    }

    internal static void ShowProduct(Product product)
    {
        var panel = new Panel($@"ID: {product.ProductId}
Name: {product.Name}
Price: {product.Price}
Category: {product.Category.Name}");
        panel.Header = new PanelHeader("Product Info");
        panel.Padding = new Padding(2, 2, 2, 2);

        AnsiConsole.Write(panel);

        Console.WriteLine("\nPress any key to continue");
        Console.ReadKey();
    }

    internal static void ShowCategory(Category category)
    {
        var panel = new Panel($@"ID: {category.CategoryId}
Name: {category.Name}
Product Count: {category.Products.Count}");
        panel.Header = new PanelHeader($"{category.Name}");
        panel.Padding = new Padding(2, 2, 2, 2);

        AnsiConsole.Write(panel);

        ShowProductTable(category.Products);
    }

    internal static void ShowOrder(Order order)
    {
        var panel = new Panel($@"ID: {order.OrderId}
Date: {order.CreatedDate}
Product Count: {order.OrderProducts.Sum(x => x.Quantity)}");
        panel.Header = new PanelHeader($"Order #{order.OrderId}");
        panel.Padding = new Padding(2, 2, 2, 2);

        AnsiConsole.Write(panel);
    }

    internal static void ShowProductForOrderTable(List<ProductForOrderViewDTO> products)
    {
        var table = new Table();
        table.AddColumn("Id");
        table.AddColumn("Name");
        table.AddColumn("Category");
        table.AddColumn("Price");
        table.AddColumn("Quantity");
        table.AddColumn("Total Price");

        foreach (ProductForOrderViewDTO product in products)
        {
            table.AddRow(product.Id.ToString(), product.Name, product.CategoryName, 
                product.Price.ToString(), product.Quantity.ToString(), product.TotalPrice.ToString());
        }

        AnsiConsole.Write(table);

        Console.WriteLine("\nPress any key to continue");
        Console.ReadKey();
    }
}

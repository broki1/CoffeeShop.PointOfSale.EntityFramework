﻿using CoffeeShop.PointOfSale.EntityFramework.Model;
using Microsoft.EntityFrameworkCore;
using Spectre.Console;

namespace CoffeeShop.PointOfSale.EntityFramework.Controllers;

internal class ProductController
{
    internal static void AddProduct(Product product)
    {
        using var db = new ProductContext();

        db.Products.Add(product);

        db.SaveChanges();
    }

    internal static void DeleteProduct(Product product)
    {
        using var db = new ProductContext();

        db.Products.Remove(product);
        db.SaveChanges();
    }

    internal static Product GetProductById(int id)
    {
        using var db = new ProductContext();
        var product = db.Products.Include(x=>x.Category).SingleOrDefault(x => x.ProductId == id);

        return product;
    }

    internal static List<Product> GetProducts()
    {
        using var db = new ProductContext();

        var products = db.Products
            .Include(x => x.Category)
            .ToList();

        return products;
    }

    internal static void UpdateProduct(Product product)
    {
        using var db = new ProductContext();

        db.Update(product);
        db.SaveChanges();
    }
}

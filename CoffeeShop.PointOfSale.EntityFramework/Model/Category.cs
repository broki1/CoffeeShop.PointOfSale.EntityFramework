﻿using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.PointOfSale.EntityFramework.Model;

[Index(nameof(Name), IsUnique = true)]

internal class Category
{
    //[Key]
    public int CategoryId { get; set; }
    //[Required]
    public string Name { get; set; }
    public List<Product> Products { get; set; }
}

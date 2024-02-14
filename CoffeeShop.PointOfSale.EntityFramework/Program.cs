using CoffeeShop.PointOfSale.EntityFramework;
using Spectre.Console;

var context = new ProductContext();
context.Database.EnsureDeleted();
context.Database.EnsureCreated();

UserInterface.MainMenu();
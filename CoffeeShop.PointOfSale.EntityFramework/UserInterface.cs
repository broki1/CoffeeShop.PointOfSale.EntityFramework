using CoffeeShop.PointOfSale.EntityFramework.Model;
using Spectre.Console;

namespace CoffeeShop.PointOfSale.EntityFramework;

internal class UserInterface
{

    public static void ShowProductTable(List<Product> products)
    {

        var table = new Table();

        table.AddColumn("Id");
        table.AddColumn("Name");

        foreach (var product in products)
        {
            table.AddRow(product.Id.ToString(), product.Name);
        }

        AnsiConsole.Write(table);

        Console.WriteLine("\nPress any key to continue");
        Console.ReadKey();
    }

}

using CoffeeShop.PointOfSale.EntityFramework.Controllers;
using CoffeeShop.PointOfSale.EntityFramework.Model;
using Spectre.Console;

namespace CoffeeShop.PointOfSale.EntityFramework.Services;

internal class CategoryService
{

    internal static void InsertCategory()
    {
        var category = new Category();
        category.Name = AnsiConsole.Ask<string>("Category name:");

        CategoryController.AddCategory(category);
    }

    internal static void DeleteCategory()
    {
        var category = GetCategoryOptionInput();

        CategoryController.DeleteCategory(category);
    }

    internal static void GetCategory()
    {
        var category = GetCategoryOptionInput();

        UserInterface.ShowCategory(category);
    }

    internal static void GetCategories()
    {
        var categories = CategoryController.GetCategories();

        UserInterface.ShowCategoryTable(categories);
    }

    internal static void UpdateCategory()
    {
        var category = GetCategoryOptionInput();

        var categoryName = AnsiConsole.Confirm("Update name?") ? AnsiConsole.Ask<string>("Category's New Name:") : category.Name;

        category.Name = categoryName;

        CategoryController.UpdateCategory(category);
    }

    internal static Category GetCategoryOptionInput()
    {
        var categories = CategoryController.GetCategories();
        var categoriesArray = categories.Select(x => x.Name).ToArray();

        var option = AnsiConsole.Prompt(new SelectionPrompt<string>()
            .Title("Choose Category")
            .AddChoices(categoriesArray));

        var category = categories.Single(x => x.Name == option);

        return category;
    }

}

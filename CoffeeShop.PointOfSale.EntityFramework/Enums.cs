namespace CoffeeShop.PointOfSale.EntityFramework;

internal class Enums
{
    internal enum MainMenuOptions
    {
        ManageCategories,
        ManageProducts,
        ManageOrders,
        Quit
    }

    internal enum CategoryMenu
    {
        AddCategory,
        DeleteCategory,
        UpdateCategory,
        ViewCategory,
        ViewAllCategories,
        GoBack
    }

    internal enum ProductMenu
    {
        AddProduct,
        DeleteProduct,
        UpdateProduct,
        ViewProduct,
        ViewAllProducts,
        GoBack
    }

    internal enum OrderMenu
    {
        AddOrder,
        GoBack
    }
}

using CoffeeShop.PointOfSale.EntityFramework.Model;

namespace CoffeeShop.PointOfSale.EntityFramework.Controllers;

internal class OrderController
{

    internal static void AddOrder(List<OrderProduct> orders)
    {
        using var db = new ProductContext();

        db.OrderProducts.AddRange(orders);

        db.SaveChanges();
    }

}

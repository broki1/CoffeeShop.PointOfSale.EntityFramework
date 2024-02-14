namespace CoffeeShop.PointOfSale.EntityFramework.Model;

// creates Index on Name column
// [Index(nameof(Name), IsUnique =true)]
internal class Product
{
    // [Key]
    public int ProductId { get; set; }
    // [Required]
    public string Name { get; set; }
    // [Required]
    public decimal Price { get; set; }
    public int CategoryId { get; set; }

    // [ForeignKey(nameof(CategoryId))]
    public Category Category { get; set; }

    public ICollection<OrderProduct> OrderProducts { get; set; }
}

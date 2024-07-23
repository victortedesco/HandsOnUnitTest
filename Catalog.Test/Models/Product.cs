namespace Catalog.Test.Models;

public class Product
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Name { get; set; }
    public double Price { get; set; }
    public Category Category { get; set; }
    public bool IsDeleted { get; set; } = false;

    public static bool IsInvalidProduct(Product product)
    {
        return product is null || string.IsNullOrEmpty(product.Name) || product.Price <= 0 || product.Category == Category.None;
    }
}

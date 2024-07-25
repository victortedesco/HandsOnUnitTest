namespace Catalog.Test.Models;

public class Product
{
    public Product(string name, double price, string category)
    {
        Id = Guid.NewGuid();
        ValidateName(name);
        ValidatePrice(price);
        ValidateCategory(category);

        Name = name;
        Price = price;
        Category = Enum.Parse<Category>(category, true);
    }

    public Guid Id { get; private set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public Category Category { get; set; }
    public bool IsDeleted { get; set; } = false;

    public static void ValidateName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentNullException(name);
    }

    public static void ValidatePrice(double price)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(price);
    }

    public static void ValidateCategory(string category)
    {
        Enum.Parse<Category>(category, true);
    }
}

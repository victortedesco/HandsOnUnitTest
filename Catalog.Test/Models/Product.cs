namespace Catalog.Test.Models;

public class Product
{
    public Product(string name, decimal price, string category)
    {
        ValidateName(name);
        ValidatePrice(price);
        ValidateCategory(category);

        Id = Guid.NewGuid();
        Name = name;
        Price = price;
        Category = Enum.Parse<Category>(category, true);
        IsDeleted = false;
    }

    public Guid Id { get; private set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public Category Category { get; set; }
    public bool IsDeleted { get; set; }

    private static void ValidateName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("The product name is required.");
        if (name.Length > 50)
            throw new ArgumentException("The product name has more than 50 characters.");
    }

    private static void ValidatePrice(decimal price)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(price);
    }

    private static void ValidateCategory(string category)
    {
        _ = Enum.Parse<Category>(category, true);
    }
}

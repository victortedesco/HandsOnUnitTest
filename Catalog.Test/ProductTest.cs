using Catalog.Test.Models;

namespace Catalog.Test;

public class ProductTest
{
    [Fact]
    public void Product_ShouldInitizalizeIfEverythingIsOk()
    {
        var product = new Product("Product", 10.1m, "eletronics");

        Assert.NotNull(product);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void WhenName_IsNullOrWhiteSpace_ShouldReturnArgumentException(string name)
    {
        Action productInitAction = () => _ = new Product(name, 1.1m, "eletronics");

        Assert.ThrowsAny<ArgumentException>(productInitAction);
    }

    [Fact]
    public void WhenName_HasMoreThan50Characters_ShouldReturnArgumentException()
    {
        var name = new string('a', 51);

        Action productInitAction = () => _ = new Product(name, 1.1m, "eletronics");

        Assert.ThrowsAny<ArgumentException>(productInitAction);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void WhenPrice_IsLessThanOrEqualToZero_ShouldReturnArgumentOutOfRangeException(decimal price)
    {
        Action productInitAction = () => _ = new Product("Product", price, "eletronics");

        Assert.ThrowsAny<ArgumentOutOfRangeException>(productInitAction);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("not_valid")]
    public void WhenCategory_IsNotValid_ShouldReturnArgumentException(string category)
    {
        Action productInitAction = () => _ = new Product("Product", 1.1m, category);

        Assert.ThrowsAny<ArgumentException>(productInitAction);
    }
}

using Catalog.Test.Models;

namespace Catalog.Test;

public class ProductTest
{
    [Fact]
    public void Product_ShouldInitizalizeIfEverythingIsOk()
    {
        var product = new Product("Product", 10, "eletronics");

        Assert.NotNull(product);
    }

    [Fact]
    public void WhenName_IsNullOrWhiteSpace_ShouldReturnArgumentNullException()
    {
        Action productInitAction = () => _ = new Product("          ", 1.1, "eletronics");

        Assert.ThrowsAny<ArgumentNullException>(productInitAction);
    }

    [Fact]
    public void WhenPrice_IsLessThanOrEqualToZero_ShouldReturnArgumentOutOfRangeException()
    {
        Action productInitAction = () => _ = new Product("Product", -1, "eletronics");

        Assert.ThrowsAny<ArgumentOutOfRangeException>(productInitAction);
    }

    [Fact]
    public void WhenCategory_IsNotValid_ShouldReturnArgumentException()
    {
        Action productInitAction = () => _ = new Product("Product", 1.1, null);

        Assert.ThrowsAny<ArgumentException>(productInitAction);
    }
}

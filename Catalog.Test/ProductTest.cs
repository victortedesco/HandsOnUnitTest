using Catalog.Test.Models;

namespace Catalog.Test;

public class ProductTest
{

    [Theory]
    [InlineData("Computer")]
    [InlineData("Cellphone")]
    public void WhenName_LenghtIsLessThan50AndIsNotWhiteSpace_ShouldInitizalizeProduct(string name)
    {
        var product = new Product(name, 1.1m, "eletronics");

        Assert.NotNull(product);
        Assert.Equal(name, product.Name);
    }

    [Fact]
    public void WhenName_LenghtIsMoreThan50Characters_ShouldReturnArgumentException()
    {
        var name = new string('a', 51);

        void productInitAction() => _ = new Product(name, 1.1m, "eletronics");

        Assert.ThrowsAny<ArgumentException>(productInitAction);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2.1)]
    public void WhenPrice_IsGreaterThanZero_ShouldInitizalizeProduct(decimal price)
    {
        var product = new Product("Product", price, "eletronics");

        Assert.NotNull(product);
        Assert.Equal(price, product.Price);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void WhenPrice_IsLessThanOrEqualToZero_ShouldReturnArgumentOutOfRangeException(decimal price)
    {
        void productInitAction() => _ = new Product("Product", price, "eletronics");

        Assert.ThrowsAny<ArgumentOutOfRangeException>(productInitAction);
    }

    [Theory]
    [InlineData("eletronics")]
    [InlineData("books")]
    [InlineData("pets")]
    public void WhenCategory_Exists_ShouldInitizalizeProduct(string category)
    {
        var product = new Product("Product", 1.1m, category);

        Assert.NotNull(product);
        Assert.Equal(category.ToLower(), product.Category.ToString().ToLower());
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData("foods")]
    [InlineData("invalid")]
    public void WhenCategory_IsNotValid_ShouldReturnArgumentException(string category)
    {
        void productInitAction() => _ = new Product("Product", 1.1m, category);

        Assert.ThrowsAny<ArgumentException>(productInitAction);
    }
}

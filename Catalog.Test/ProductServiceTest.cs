using Catalog.Test.Abstractions;
using Catalog.Test.Models;

namespace Catalog.Test;

public class ProductServiceTest
{
    [Fact]
    public void GetAll_ReturnsOnlyNonDeletedProducts()
    {
        var productService = new ProductService();

        var products = new List<Product>
        {
            new("Product 1", 11999.99, "eletronics"),
            new("Product 2", 999.99, "books"),
            new("Product 3", 3999.99, "pets"),
        };

        products.ForEach(p => productService.Add(p));
        productService.Delete(products.First().Id);

        var result = productService.GetAll();

        Assert.Equal(2, result.Count());
    }

    [Fact]
    public void GetById_ReturnsAnExistingProduct()
    {
        var productService = new ProductService();

        var product = new Product("Product 1", 1.1, "books");

        productService.Add(product);

        var result = productService.GetById(product.Id);

        Assert.NotNull(result);
        Assert.Equal(product.Id, result.Id);
    }

    [Fact]
    public void GetById_ReturnsNullForNonExistingProduct()
    {
        var productService = new ProductService();

        var result = productService.GetById(Guid.NewGuid());

        Assert.Null(result);
    }

    [Fact]
    public void GetById_ReturnsNullForDeletedProduct()
    {
        var productService = new ProductService();

        var product = new Product("Product 1", 1.1, "books");

        productService.Add(product);
        productService.Delete(product.Id);

        var result = productService.GetById(product.Id);

        Assert.Null(result);
    }

    [Fact]
    public void Add_ReturnsTrueIfProductIsCorrect()
    {
        var productService = new ProductService();

        var product = new Product("Product 1", 1.1, "books");

        var result = productService.Add(product);

        Assert.True(result);
    }

    [Fact]
    public void Add_ReturnsFalseIfProductHasTheSameIdAsAnother()
    {
        var productService = new ProductService();

        var product = new Product("Product 1", 1.1, "books");

        productService.Add(product);

        var result = productService.Add(product);

        Assert.False(result);
    }

    [Fact]
    public void Delete_ReturnsTrueForNonDeletedProduct()
    {
        var productService = new ProductService();

        var product = new Product("Product 1", 1.1, "books");

        productService.Add(product);

        var result = productService.Delete(product.Id);

        Assert.True(result);
    }

    [Fact]
    public void Delete_ReturnsFalseForDeletedProduct()
    {
        var productService = new ProductService();

        var product = new Product("Product 1", 1.1, "books");

        productService.Add(product);
        productService.Delete(product.Id);

        var result = productService.Delete(product.Id);

        Assert.False(result);
    }

    [Fact]
    public void Delete_ReturnsFalseForNonExistingProduct()
    {
        var productService = new ProductService();

        var result = productService.Delete(Guid.NewGuid());

        Assert.False(result);
    }

    [Fact]
    public void Update_ReturnsFalseForNonExistingProduct()
    {
        var productService = new ProductService();

        var request = new Product("Product 1", 1.1, "books");

        var result = productService.Update(Guid.NewGuid(), request);

        Assert.False(result);
    }

    [Fact]
    public void Update_ReturnsFalseForNullRequest()
    {
        var productService = new ProductService();

        var product = new Product("Product 1", 1.1, "books");

        productService.Add(product);

        var result = productService.Update(product.Id, null);

        Assert.False(result);
    }
}

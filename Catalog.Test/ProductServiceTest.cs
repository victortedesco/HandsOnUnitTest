using Catalog.Test.Models;
using Catalog.Test.Services;

namespace Catalog.Test;

public class ProductServiceTest
{
    [Fact]
    public void GetAll_ReturnsProducts()
    {
        var productService = new ProductService();

        var products = new List<Product>
        {
            new() { Name = "Product 1", Price = 11999.99, Category = Category.Eletronics },
            new() { Name = "Product 2", Price = 999.99, Category = Category.Books },
            new() { Name = "Product 3", Price = 3999.99, Category = Category.Pets },
        };

        products.ForEach(p => productService.Add(p));

        var result = productService.GetAll();

        Assert.Equal(products, result);
    }

    [Fact]
    public void GetById_ReturnsAnExistingProduct()
    {
        var product = new Product { Name = "Product 1", Price = 1.1, Category = Category.Books };
        var productService = new ProductService();
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
    public void Add_ReturnsTrueIfProductHaveAllParameters()
    {
        var productService = new ProductService();

        var product = new Product { Name = "Product 1", Price = 1.1, Category = Category.Books };

        var result = productService.Add(product);

        Assert.True(result);
    }

    [Fact]
    public void Add_ReturnsFalseIfProductDoesNotHaveAllParameters()
    {
        var productService = new ProductService();

        var product = new Product { Name = "Product 1", Category = Category.Books };

        var result = productService.Add(product);

        Assert.False(result);
    }

    [Fact]
    public void Add_ReturnsFalseIfProductHaveInvalidParameters()
    {
        var productService = new ProductService();

        var product = new Product { Name = "Product 1", Price = -10000, Category = Category.None };

        var result = productService.Add(product);

        Assert.False(result);
    }

    [Fact]
    public void Delete_ReturnsTrueForExistingProduct()
    {
        var product = new Product { Name = "Product 1", Price = 1.1, Category = Category.Books };
        var productService = new ProductService();
        productService.Add(product);

        var result = productService.Delete(product.Id);

        Assert.True(result);
    }

    [Fact]
    public void Delete_ReturnsFalseForNonExistingProduct()
    {
        var productService = new ProductService();
        var result = productService.Delete(Guid.NewGuid());

        Assert.False(result);
    }

    [Fact]
    public void Update_ReturnsTrueIfRequestHaveAllParameters()
    {
        var productService = new ProductService();
        var product = new Product { Name = "Product 1", Price = 1.1, Category = Category.Books };

        productService.Add(product);

        var request = new Product { Name = "Product 1", Price = 1000, Category = Category.Pets };
        var result = productService.Update(product.Id, request);

        Assert.True(result);
    }

    [Fact]
    public void Update_ReturnsFalseIfRequestDoesNotHaveAllParameters()
    {
        var productService = new ProductService();
        var product = new Product { Name = "Product 1", Price = 1.1, Category = Category.Books };

        productService.Add(product);

        var request = new Product { Name = "Product 1" };
        var result = productService.Update(product.Id, request);

        Assert.False(result);
    }

    [Fact]
    public void Update_ReturnsFalseIfRequestHaveInvalidParameters()
    {
        var productService = new ProductService();
        var product = new Product { Name = "Product 1", Price = 1.1, Category = Category.Books };

        productService.Add(product);

        var request = new Product { Name = "Product 1", Price = -1000, Category = Category.None };
        var result = productService.Update(product.Id, request);

        Assert.False(result);
    }

    [Fact]
    public void Update_ReturnsFalseForNonExistingProduct()
    {
        var productService = new ProductService();
        var request = new Product { Name = "Product 1", Price = 1.1, Category = Category.Books };

        var result = productService.Update(Guid.NewGuid(), request);
        Assert.False(result);
    }

    [Fact]
    public void Update_ReturnsFalseForNullRequest()
    {
        var productService = new ProductService();
        var product = new Product { Name = "Product 1", Price = 1.1, Category = Category.Books };

        productService.Add(product);

        var result = productService.Update(product.Id, null);

        Assert.False(result);
    }
}

using Catalog.Test.Models;

namespace Catalog.Test.Abstractions;

public interface IProductService
{
    IEnumerable<Product> GetAll();
    Product GetById(Guid id);
    bool Add(Product product);
    bool Update(Guid id, Product product);
    bool Delete(Guid id);
}

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository = new ProductRepository();

    public IEnumerable<Product> GetAll()
    {
        return _productRepository.GetAll().Where(p => !p.IsDeleted).ToList();
    }

    public Product GetById(Guid id)
    {
        var product = _productRepository.GetById(id);

        if (product is null || product.IsDeleted)
            return null;

        return product;
    }

    public bool Add(Product product)
    {
        if (_productRepository.GetById(product.Id) is not null)
            return false;

        return _productRepository.Add(product);
    }

    public bool Update(Guid id, Product request)
    {
        var product = _productRepository.GetById(id);

        if (product is null || request is null)
            return false;

        if (product.IsDeleted)
            return false;

        return _productRepository.Update(id, product);
    }

    public bool Delete(Guid id)
    {
        var product = _productRepository.GetById(id);

        if (product is null || product.IsDeleted)
            return false;

        return _productRepository.Delete(id);
    }
}

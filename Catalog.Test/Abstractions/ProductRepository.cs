using Catalog.Test.Models;

namespace Catalog.Test.Abstractions;

public interface IProductRepository
{
    IEnumerable<Product> GetAll();
    Product GetById(Guid id);
    bool Add(Product product);
    bool Update(Guid id, Product product);
    bool Delete(Guid id);
}

public class ProductRepository : IProductRepository
{
    /* This was designed to be similar to DbSet<Product>, 
     * but it does not provide some rules and methods,
     * they are implemented in the methods of this class (line 34).
    */
    private readonly List<Product> _products = [];

    public IEnumerable<Product> GetAll()
    {
        return _products;
    }

    public Product GetById(Guid id)
    {
        return _products.FirstOrDefault(p => p.Id == id);
    }

    public bool Add(Product product)
    {
        if (_products.FirstOrDefault(p => p.Id == product.Id) is not null)
            throw new InvalidOperationException($"A product with the id '{product.Id}' already exists.");

        _products.Add(product);

        return true;
    }

    public bool Update(Guid id, Product request)
    {
        var product = _products.FirstOrDefault(x => x.Id == id);

        product.Name = request.Name;
        product.Price = request.Price;
        product.Category = request.Category;

        return true;
    }

    public bool Delete(Guid id)
    {
        var product = _products.FirstOrDefault(p => p.Id == id);

        product.IsDeleted = true;

        return true;
    }
}

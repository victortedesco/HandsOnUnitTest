using Catalog.Test.Models;

namespace Catalog.Test.Services;

public class ProductService
{
    private readonly HashSet<Product> _products = [];

    public IEnumerable<Product> GetAll()
    {
        return _products.ToList();
    }

    public Product GetById(Guid id)
    {
        return _products.FirstOrDefault(p => p.Id == id);
    }

    public bool Add(Product product)
    {
        if (Product.IsInvalidProduct(product))
        {
            return false;
        }

        _products.Add(product);

        return true;
    }

    public bool Delete(Guid id)
    {
        var product = _products.FirstOrDefault(p => p.Id == id);

        if (product == null)
            return false;

        _products.Remove(product);

        return true;
    }

    public bool Update(Guid id, Product request)
    {
        var product = _products.FirstOrDefault(x => x.Id == id);

        if (product == null || request == null)
            return false;

        if (Product.IsInvalidProduct(request))
        {
            return false;
        }

        product.Name = request.Name;
        product.Price = request.Price;
        product.Category = request.Category;

        return true;
    }
}

using Catalog.Test.Models;

namespace Catalog.Test.Services;

public class ProductService
{
    private readonly List<Product> _products = [];

    public IEnumerable<Product> GetAll()
    {
        return _products.Where(p => !p.IsDeleted).ToList();
    }

    public Product GetById(Guid id)
    {
        return _products.Where(p => !p.IsDeleted).FirstOrDefault(p => p.Id == id);
    }

    public bool Add(Product product)
    {
        if (_products.FirstOrDefault(p => p.Id == product.Id) is not null)
            return false;
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

        if (product is null)
            return false;
        if (product.IsDeleted)
            return false;

        product.IsDeleted = true;

        return true;
    }

    public bool Update(Guid id, Product request)
    {
        var product = _products.Where(p => !p.IsDeleted).FirstOrDefault(x => x.Id == id);

        if (product is null || request is null)
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

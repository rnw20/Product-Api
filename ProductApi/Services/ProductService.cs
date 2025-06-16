using ProductApi.Models;

namespace ProductApi.Services;

public class ProductService
{
    private readonly List<Product> _products = new();
    private int _nextId = 1;

    public List<Product> GetAll() => _products;

    public Product? Get(int id) => _products.FirstOrDefault(p => p.Id == id);

    public Product Create(Product product)
    {
        product.Id = _nextId++;
        _products.Add(product);
        return product;
    }

    public bool Update(int id, Product updated)
    {
        var product = Get(id);
        if (product == null) return false;

        product.Name = updated.Name;
        product.Price = updated.Price;
        return true;
    }

    public bool Delete(int id)
    {
        var product = Get(id);
        if (product == null) return false;

        _products.Remove(product);
        return true;
    }
}

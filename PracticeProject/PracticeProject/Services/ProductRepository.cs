using System.Reflection;
using PracticeProject.Models;

namespace PracticeProject.Services;

public class ProductRepository : IProductRepository
{
    private static IEnumerable<Product> _products = new List<Product>();

    public IEnumerable<Product> GetAllProduct(SortingParameters sortingParameters)
    {
        var property = typeof(Product).GetProperty(sortingParameters.Active,
            BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

        if (property == null)
            throw new ArgumentOutOfRangeException();
        
        var sortedProducts = sortingParameters.Direction?.ToLower() == "desc"
            ? _products.OrderByDescending(p => property.GetValue(p, null))
            : _products.OrderBy(p => property.GetValue(p, null));
        
        return sortedProducts.ToList();
    }

    public Guid AddProduct(Product product)
    {
        Guid newId = Guid.NewGuid();
        product.Id = newId;

        product.Manufacturer = product.Manufacturer.Trim();
        product.Name = product.Name.Trim();
        product.Description = product.Description?.Trim();

        _products = _products.Append(product);

        return newId;
    }

    public void RemoveProduct(Guid productId)
    {
        if (!_products.Any(product => product.Id.Equals(productId)))
            throw new ArgumentOutOfRangeException();
        
        _products = _products.Where(product => product.Id != productId);
    }

    public Product UpdateProduct(Product product)
    {
        if (!_products.Any(prod => prod.Id.Equals(product.Id)))
            throw new ArgumentOutOfRangeException();
        
        product.Manufacturer = product.Manufacturer.Trim();
        product.Name = product.Name.Trim();
        product.Description = product.Description?.Trim();
        
        _products = _products.Where(prod => prod.Id != product.Id);
        _products = _products.Append(product);

        return product;
    }

    public Product GetProductById(Guid productId)
    {
        var product = _products.Single(prod => prod.Id.Equals(productId));
        
        if (product == null)
            throw new ArgumentOutOfRangeException();

        return product;
    }
}
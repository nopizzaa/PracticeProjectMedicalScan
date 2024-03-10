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

    public Product AddProduct(Product product)
    {
        product.Id = Guid.NewGuid();

        _products = _products.Append(product);

        return _products.First(pro => pro.Equals(product));
    }
}
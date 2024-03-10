using PracticeProject.Models;

namespace PracticeProject.Services;

public class ProductRepository : IProductRepository
{
    private static IEnumerable<Product> _products = new List<Product>();
    
    public IEnumerable<Product> GetAllProduct()
    {
        return _products.ToList();
    }

    public Product AddProduct(Product product)
    {
        product.Id = Guid.NewGuid();
        
        _products = _products.Append(product);

        return _products.First(pro => pro.Equals(product));
    }
}
using PracticeProject.Models;

namespace PracticeProject.Services;

public interface IProductRepository
{
    public IEnumerable<Product> GetAllProduct();
    public Product AddProduct(Product product);
}
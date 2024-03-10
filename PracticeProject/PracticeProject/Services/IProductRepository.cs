using PracticeProject.Models;

namespace PracticeProject.Services;

public interface IProductRepository
{
    public IEnumerable<Product> GetAllProduct(SortingParameters sortingParameters);
    public Product AddProduct(Product product);
}
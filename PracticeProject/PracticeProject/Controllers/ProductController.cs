using Microsoft.AspNetCore.Mvc;
using PracticeProject.Models;
using PracticeProject.Services;

namespace PracticeProject.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductRepository _productRepository;

    public ProductController(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    [HttpGet]
    public IEnumerable<Product> Get()
    {
        return _productRepository.GetAllProduct();
    }

    [HttpPost]
    public Product Post(Product product)
    {
        return _productRepository.AddProduct(product);
    }
    
    [HttpPut]
    public void Put()
    {
    }

    [HttpDelete]
    public void Delete()
    {
    }
}
using System.Globalization;
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

    /// <summary>
    /// Get a list of products with optional sorting parameters.
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///     GET /api/products?sortBy=Name&sortDirection=Asc
    /// </remarks>
    /// <param name="sortingParameters">Sorting parameters for the products.</param>
    /// <returns>Returns a list of products based on the provided sorting parameters.</returns>
    /// <response code="200">Returns the list of products.</response>
    /// <response code="500">Internal server error.</response>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<Product>), 200)]
    [ProducesResponseType(500)]
    public IActionResult Get([FromQuery] SortingParameters sortingParameters)
    {
        try
        {
            var products = _productRepository.GetAllProduct(sortingParameters);
            
            return Ok(products);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    /// <summary>
    /// Add a new product.
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///     POST /api/products
    ///     {
    ///         "manufacturer": "ABC",
    ///         "name": "New Product",
    ///         "description": "This is a new product",
    ///         "price": 39.99
    ///     }
    /// </remarks>
    /// <param name="product">The product information to add.</param>
    /// <returns>Returns the added product information.</returns>
    /// <response code="200">Returns the added product information.</response>
    /// <response code="400">Bad request. Indicates that the request is invalid.</response>
    /// <response code="500">Internal server error.</response>
    [HttpPost]
    [ProducesResponseType(typeof(Product), 200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(500)]
    public IActionResult Post(Product product)
    {
        if (string.IsNullOrWhiteSpace(product.Manufacturer))
            return StatusCode(400, $"Manufacturer is invalid: Manufacturer field is empty or white space.");

        if (string.IsNullOrWhiteSpace(product.Name))
            return StatusCode(400, $"Name is invalid: Name field is empty or white space.");

        if (product.Price < 0)
            return StatusCode(400, $"Price can not be negative:" +
                                   $" {product.Price.ToString(CultureInfo.CurrentCulture)}");

        try
        {
            return Ok(_productRepository.AddProduct(product));
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    /// <summary>
    /// Update an existing product.
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///     PUT /api/products
    ///     {
    ///         "id": "1",
    ///         "manufacturer": "Updated Manufacturer",
    ///         "name": "Updated Product",
    ///         "description": "This is the updated product",
    ///         "price": 49.99
    ///     }
    /// </remarks>
    /// <param name="product">The product information to update.</param>
    /// <returns>Returns the updated product information.</returns>
    /// <response code="200">Returns the updated product information.</response>
    /// <response code="400">Bad request. Indicates that the request is invalid or the product ID does not exist.</response>
    /// <response code="500">Internal server error.</response>
    [HttpPut]
    public IActionResult Put(Product product)
    {
        if (string.IsNullOrWhiteSpace(product.Manufacturer))
            return StatusCode(400, $"Manufacturer is invalid: Manufacturer field is empty or white space.");

        if (string.IsNullOrWhiteSpace(product.Name))
            return StatusCode(400, $"Name is invalid: Name field is empty or white space.");

        if (product.Price < 0)
            return StatusCode(400, $"Price can not be negative:" +
                                   $" {product.Price.ToString(CultureInfo.CurrentCulture)}");

        try
        {
            return Ok(_productRepository.UpdateProduct(product));
        }
        catch (ArgumentOutOfRangeException ex)
        {
            return StatusCode(400, $"Invalid, product id is not exist: {ex.Message}");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    /// <summary>
    /// Delete a product by its ID.
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///     DELETE /api/products/{productId}
    /// </remarks>
    /// <param name="productId">The ID of the product to delete.</param>
    /// <returns>Returns 200 OK if the product is successfully deleted.</returns>
    /// <response code="200">Product deleted successfully.</response>
    /// <response code="400">Bad request. Indicates that the product ID does not exist.</response>
    /// <response code="500">Internal server error.</response>
    [HttpDelete]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(500)]
    public IActionResult Delete(Guid productId)
    {
        try
        {
            _productRepository.RemoveProduct(productId);
            return Ok();
        }
        catch (ArgumentOutOfRangeException ex)
        {
            return StatusCode(400, $"Invalid, product id is not exist: {ex.Message}");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    /// <summary>
    /// Get product information by its ID.
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///     GET /api/products/productById/{productId}
    /// </remarks>
    /// <param name="productId">The ID of the product to retrieve.</param>
    /// <returns>Returns the product information based on the provided ID.</returns>
    /// <response code="200">Returns the product information.</response>
    /// <response code="400">Bad request. Indicates that the product ID does not exist.</response>
    /// <response code="500">Internal server error.</response>
    [HttpGet]
    [Route("productById/{productId}")]
    [ProducesResponseType(typeof(Product), 200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(500)]
    public IActionResult GetProductById(Guid productId)
    {
        try
        {
            return Ok(_productRepository.GetProductById(productId));
        }
        catch (InvalidOperationException ex)
        {
            return StatusCode(400, $"Invalid, product id is not exist: {ex.Message}");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}

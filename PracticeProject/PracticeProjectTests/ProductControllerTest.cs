using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using PracticeProject.Controllers;
using PracticeProject.Models;
using PracticeProject.Services;

namespace PracticeProjectTests;

[TestFixture]
public class ProductControllerTest
{
    [Test]
    public void GetObjectResultWhenRepositoryReturnsWithProducts()
    {
        var sortingParameters = new SortingParameters();
        var expectedProducts = new List<Product>
        {
            new()
            {
                Id = Guid.Parse("ea320ff9-e165-4b48-aec8-6a89638659b6"), Manufacturer = "ABC", Name = "Doe", Price = 19,
                Description = "Thi is a product."
            },
        };

        var mockRepository = new Mock<IProductRepository>();
        mockRepository.Setup(repo => repo.GetAllProduct(sortingParameters)).Returns(expectedProducts);

        var controller = new ProductController(mockRepository.Object);

        var result = controller.Get(sortingParameters);
        Assert.That(result, Is.TypeOf<OkObjectResult>());

        var okObjectResult = (OkObjectResult)result;
        Assert.That(okObjectResult.Value, Is.AssignableTo<IEnumerable<Product>>());

        var actualProducts = (IEnumerable<Product>)okObjectResult.Value!;
        CollectionAssert.AreEqual(expectedProducts, actualProducts);
    }

    [Test]
    public void GetProductByIdWithValidProductId()
    {
        var productId = Guid.NewGuid();
        var expectedProduct = new Product
        {
            Id = Guid.Parse("ea320ff9-e165-4b48-aec8-6a89638659b6"), Manufacturer = "ABC", Name = "Doe", Price = 19,
            Description = "Thi is a product."
        };

        var mockRepository = new Mock<IProductRepository>();
        mockRepository.Setup(repo => repo.GetProductById(productId)).Returns(expectedProduct);

        var controller = new ProductController(mockRepository.Object);

        var result = controller.GetProductById(productId);
        Assert.That(result, Is.TypeOf<OkObjectResult>());

        var okObjectResult = (OkObjectResult)result;
        Assert.That(okObjectResult.Value, Is.TypeOf<Product>());

        var actualProduct = (Product)okObjectResult.Value!;
        Assert.AreEqual(expectedProduct, actualProduct);
    }

    [Test]
    public void GetProductById_ReturnsBadRequest_WithInvalidProductId()
    {
        var invalidProductId = Guid.NewGuid();

        var mockRepository = new Mock<IProductRepository>();
        mockRepository.Setup(repo => repo.GetProductById(invalidProductId))
            .Throws(new InvalidOperationException("Invalid product ID"));

        var controller = new ProductController(mockRepository.Object);

        var result = controller.GetProductById(invalidProductId);
        Assert.That(result, Is.TypeOf<ObjectResult>());

        var objectResult = (ObjectResult)result;
        Assert.AreEqual(400, objectResult.StatusCode);
        Assert.AreEqual("Invalid, product id is not exist: Invalid product ID", objectResult.Value);
    }

    [Test]
    public void GetProductById_ReturnsInternalServerError_WhenExceptionOccurs()
    {
        var productId = Guid.NewGuid();

        var mockRepository = new Mock<IProductRepository>();
        mockRepository.Setup(repo => repo.GetProductById(productId)).Throws(new Exception("Sample exception"));

        var controller = new ProductController(mockRepository.Object);

        var result = controller.GetProductById(productId);
        Assert.That(result, Is.TypeOf<ObjectResult>());

        var objectResult = (ObjectResult)result;
        Assert.AreEqual(500, objectResult.StatusCode);
        Assert.AreEqual("Internal server error: Sample exception", objectResult.Value);
    }
}

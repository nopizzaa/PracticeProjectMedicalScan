using PracticeProject.Models;

namespace PracticeProject.Services
{
    /// <summary>
    /// Interface for the product repository that defines operations for managing products.
    /// </summary>
    public interface IProductRepository
    {
        /// <summary>
        /// Retrieves all products, sorted according to the provided parameters.
        /// </summary>
        /// <param name="sortingParameters">The sorting parameters to sort the products.</param>
        /// <returns>A collection of products.</returns>
        public IEnumerable<Product> GetAllProduct(SortingParameters sortingParameters);

        /// <summary>
        /// Adds a new product to the repository.
        /// </summary>
        /// <param name="product">The product to add.</param>
        /// <returns>The ID of the added product.</returns>
        public Guid AddProduct(Product product);

        /// <summary>
        /// Removes a product from the repository.
        /// </summary>
        /// <param name="productId">The ID of the product to remove.</param>
        public void RemoveProduct(Guid productId);

        /// <summary>
        /// Updates an existing product in the repository.
        /// </summary>
        /// <param name="product">The product with updated information.</param>
        /// <returns>The updated product.</returns>
        public Product UpdateProduct(Product product);

        /// <summary>
        /// Retrieves a product by its ID.
        /// </summary>
        /// <param name="productId">The ID of the product to retrieve.</param>
        /// <returns>The product if found; otherwise, null.</returns>
        public Product GetProductById(Guid productId);
    }
}

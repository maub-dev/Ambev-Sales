﻿using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    /// <summary>
    /// Repository interface for Product entity operations
    /// </summary>
    public interface IProductRepository
    {
        /// <summary>
        /// Creates a new product in the repository
        /// </summary>
        /// <param name="product">The product to create</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The created product</returns>
        Task<Product> CreateAsync(Product product, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves all products in the repository
        /// </summary>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The list of the products if any, an empty list otherwise</returns>
        Task<IEnumerable<Product>> GetAllAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a product by their unique identifier
        /// </summary>
        /// <param name="id">The unique identifier of the product</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The product if found, null otherwise</returns>
        Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates a product in the repository
        /// </summary>
        /// <param name="product">The product to update</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The updated product</returns>
        Task<Product> UpdateAsync(Product product, CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes a product from the repository
        /// </summary>
        /// <param name="id">The unique identifier of the product to delete</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>True if the product was deleted, false if not found</returns>
        Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves all existing product's categories
        /// </summary>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The list of the products if any, an empty list otherwise</returns>
        Task<IEnumerable<string>> GetAllCategoriesAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves all products for a category
        /// </summary>
        /// <param name="category">The category to filter</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The list of the products if any, an empty list otherwise</returns>
        Task<IEnumerable<Product>> GetAllProductsForCategoryAsync(string category, CancellationToken cancellationToken = default);
    }
}

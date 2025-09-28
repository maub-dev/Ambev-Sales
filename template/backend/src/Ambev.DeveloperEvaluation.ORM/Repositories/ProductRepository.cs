using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    /// <summary>
    /// Implementation of IProductRepository using Entity Framework Core
    /// </summary>
    public class ProductRepository : IProductRepository
    {
        private readonly DefaultContext _context;

        /// <summary>
        /// Initializes a new instance of ProductRepository
        /// </summary>
        /// <param name="context">The database context</param>
        public ProductRepository(DefaultContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Creates a new product in the repository
        /// </summary>
        /// <param name="product">The product to create</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The created product</returns>
        public async Task<Product> CreateAsync(Product product, CancellationToken cancellationToken = default)
        {
            await _context.Products.AddAsync(product, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return product;
        }

        /// <summary>
        /// Deletes a product from the repository
        /// </summary>
        /// <param name="id">The unique identifier of the product to delete</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>True if the product was deleted, false if not found</returns>
        public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var product = await GetByIdAsync(id, cancellationToken);
            if (product == null)
                return false;

            _context.Products.Remove(product);
            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }

        /// <summary>
        /// Retrieves all products in the repository
        /// </summary>
        /// <returns>The list of the products if any, an empty list otherwise</returns>
        public IQueryable<Product> GetAll()
        {
            return _context.Products.AsNoTracking().AsQueryable();
        }

        /// <summary>
        /// Retrieves all existing product's categories
        /// </summary>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The list of the products if any, an empty list otherwise</returns>
        public async Task<IEnumerable<string>> GetAllCategoriesAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Products.AsNoTracking().Select(x => x.Category).Distinct().ToListAsync(cancellationToken);
        }

        /// <summary>
        /// Retrieves all products in the system
        /// </summary>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The list of the products if any, an empty list otherwise</returns>
        public async Task<IEnumerable<Product>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Products.AsNoTracking().ToListAsync(cancellationToken);
        }

        /// <summary>
        /// Retrieves all products that match the specification filter
        /// </summary>
        /// <param name="predicate">A func to filter products</param>
        /// <returns>The list of the products if any, an empty list otherwise</returns>
        public IQueryable<Product> Find(Expression<Func<Product, bool>> predicate)
        {
            return _context.Products.AsNoTracking().Where(predicate).AsQueryable();
        }

        /// <summary>
        /// Retrieves a product by their unique identifier
        /// </summary>
        /// <param name="id">The unique identifier of the product</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The product if found, null otherwise</returns>
        public async Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Products.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        /// <summary>
        /// Updates a product in the repository
        /// </summary>
        /// <param name="product">The product to update</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The updated product</returns>
        public async Task<Product> UpdateAsync(Product product, CancellationToken cancellationToken = default)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync(cancellationToken);

            return product;
        }
    }
}

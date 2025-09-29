using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Services
{
    /// <summary>
    /// Interface to implement business operations in Sale entity
    /// </summary>
    public interface ISaleService
    {
        /// <summary>
        /// Creates a new Sale
        /// </summary>
        /// <param name="sale">The data to create the sale</param>
        /// <param name="cancellationToken">The cancellatio token</param>
        /// <returns>Returns the new created sale</returns>
        Task<Sale> CreateAsync(Sale sale, CancellationToken cancellationToken = default);

        /// <summary>
        /// Udpates a sale
        /// </summary>
        /// <param name="sale">The sale to be updated</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The updated sale</returns>
        Task<Sale> UpdateAsync(Sale sale, CancellationToken cancellationToken = default);

        /// <summary>
        /// Cancel a whole sale
        /// </summary>
        /// <param name="id">The sale ID to be cancelled</param>
        /// <param name="cancellationToken">The cancellation token</param>
        Task CancelAsync(Guid id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Cancel a specific item in the sale
        /// </summary>
        /// <param name="saleId">The sale that contains the item to be canceled</param>
        /// <param name="saleItemId">The sale item which is going to be canceled</param>
        /// <param name="cancellationToken">The cancellation token</param>
        Task CancelItemAsync(Guid saleId, Guid saleItemId, CancellationToken cancellationToken = default);
    }
}

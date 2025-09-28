using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Services
{
    public interface ISaleService
    {
        Task<Sale> CreateAsync(Sale sale, CancellationToken cancellationToken = default);
        Task<Sale> UpdateAsync(Sale sale, CancellationToken cancellationToken = default);
        Task CancelAsync(Guid id, CancellationToken cancellationToken = default);
        Task CancelItemAsync(Guid saleId, Guid saleItemId, CancellationToken cancellationToken = default);
    }
}

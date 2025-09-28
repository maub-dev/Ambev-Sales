using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Services
{
    public interface ISaleService
    {
        Task<Sale> CreateAsync(Sale sale, CancellationToken cancellationToken = default);
    }
}

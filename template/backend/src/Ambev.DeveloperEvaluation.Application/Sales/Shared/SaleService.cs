using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Services;
using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.Shared
{
    /// <summary>
    /// Implementation of ISaleService
    /// </summary>
    public class SaleService : ISaleService
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IProductRepository _productRepository;

        public SaleService(ISaleRepository saleRepository, IProductRepository productRepository)
        {
            _saleRepository = saleRepository;
            _productRepository = productRepository;
        }

        /// <summary>
        /// Cancel a whole sale
        /// </summary>
        /// <param name="id">The sale ID to be cancelled</param>
        /// <param name="cancellationToken">The cancellation token</param>
        public async Task CancelAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var sale = await _saleRepository.GetByIdAsync(id, cancellationToken);
            if (sale == null)
                throw new InvalidOperationException($"The sale {id} was not found.");

            sale.Cancel();

            await _saleRepository.UpdateAsync(sale, cancellationToken);
        }

        /// <summary>
        /// Cancel a specific item in the sale
        /// </summary>
        /// <param name="saleId">The sale that contains the item to be canceled</param>
        /// <param name="saleItemId">The sale item which is going to be canceled</param>
        /// <param name="cancellationToken">The cancellation token</param>
        public async Task CancelItemAsync(Guid saleId, Guid saleItemId, CancellationToken cancellationToken = default)
        {
            var sale = await _saleRepository.GetByIdAsync(saleId, cancellationToken);
            if (sale == null)
                throw new InvalidOperationException($"The sale {saleId} was not found.");

            sale.Products.First(x => x.Id == saleItemId).Cancel();
            sale.RecalculateTotal();

            await _saleRepository.UpdateAsync(sale, cancellationToken);
        }

        /// <summary>
        /// Creates a new Sale
        /// </summary>
        /// <param name="sale">The data to create the sale</param>
        /// <param name="cancellationToken">The cancellatio token</param>
        /// <returns>Returns the new created sale</returns>
        public async Task<Sale> CreateAsync(Sale sale, CancellationToken cancellationToken = default)
        {
            sale.Activate();

            foreach (var item in sale.Products)
            {
                var product = await _productRepository.GetByIdAsync(item.ProductId, cancellationToken);
                if (product is null)
                    throw new InvalidOperationException($"The product {item.ProductId} was not found.");

                item.SetOriginalPrice(product.Price);
            }

            sale.RecalculateTotal();

            var validator = new SaleValidator();
            var validationResult = await validator.ValidateAsync(sale, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            return await _saleRepository.CreateAsync(sale, cancellationToken);
        }

        /// <summary>
        /// Udpates a sale
        /// </summary>
        /// <param name="sale">The sale to be updated</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The updated sale</returns>
        public async Task<Sale> UpdateAsync(Sale sale, CancellationToken cancellationToken = default)
        {
            var existing = await _saleRepository.GetByIdAsync(sale.Id, cancellationToken);
            if (existing is null)
                throw new InvalidOperationException($"The sale {sale.Id} was not found.");

            sale.Activate();

            foreach (var item in sale.Products)
            {
                var product = await _productRepository.GetByIdAsync(item.ProductId, cancellationToken);
                if (product is null)
                    throw new InvalidOperationException($"The product {item.ProductId} was not found.");

                item.SetOriginalPrice(product.Price);
            }

            sale.RecalculateTotal();

            var validator = new SaleValidator();
            var validationResult = await validator.ValidateAsync(sale, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            return await _saleRepository.UpdateAsync(sale, cancellationToken);
        }
    }
}

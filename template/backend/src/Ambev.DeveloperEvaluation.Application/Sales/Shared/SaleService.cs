using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Services;
using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.Shared
{
    public class SaleService : ISaleService
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IProductRepository _productRepository;

        public SaleService(ISaleRepository saleRepository, IProductRepository productRepository)
        {
            _saleRepository = saleRepository;
            _productRepository = productRepository;
        }

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
    }
}

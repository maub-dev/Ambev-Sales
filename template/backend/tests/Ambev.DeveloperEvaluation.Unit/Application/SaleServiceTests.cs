using Ambev.DeveloperEvaluation.Application.Sales.Shared;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application
{
    public class SaleServiceTests
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IProductRepository _productRepository;
        private readonly SaleService _service;

        public SaleServiceTests()
        {
            _saleRepository = Substitute.For<ISaleRepository>();
            _productRepository = Substitute.For<IProductRepository>();
            _service = new SaleService(_saleRepository, _productRepository);
        }

        [Fact(DisplayName = "CancelAsync should cancel a sale successfully")]
        public async Task CancelAsync_ShouldCancelSale_WhenSaleExists()
        {
            // Arrange
            var sale = SaleTestData.GenerateValidSale();
            _saleRepository.GetByIdAsync(sale.Id, Arg.Any<CancellationToken>()).Returns(sale);

            // Act
            await _service.CancelAsync(sale.Id);

            // Assert
            sale.Status.Should().Be(SaleStatus.Cancelled);
            foreach (var item in sale.Products)
            {
                item.Status.Should().Be(SaleItemStatus.Cancelled);
            }

            await _saleRepository.Received(1).UpdateAsync(sale, Arg.Any<CancellationToken>());
        }

        [Fact(DisplayName = "CancelAsync should throw when sale not found")]
        public async Task CancelAsync_ShouldThrow_WhenSaleNotFound()
        {
            // Arrange
            var saleId = Guid.NewGuid();
            _saleRepository.GetByIdAsync(saleId, Arg.Any<CancellationToken>()).Returns((Sale)null);

            // Act
            Func<Task> act = async () => await _service.CancelAsync(saleId);

            // Assert
            await act.Should().ThrowAsync<InvalidOperationException>()
                .WithMessage($"The sale {saleId} was not found.");
            await _saleRepository.DidNotReceive().UpdateAsync(Arg.Any<Sale>(), Arg.Any<CancellationToken>());
        }

        [Fact(DisplayName = "CancelItemAsync should cancel a specific item and recalculate total")]
        public async Task CancelItemAsync_ShouldCancelItem_WhenItemExists()
        {
            // Arrange
            var sale = SaleTestData.GenerateValidSale();
            var itemToCancel = sale.Products.First();
            _saleRepository.GetByIdAsync(sale.Id, Arg.Any<CancellationToken>()).Returns(sale);

            // Act
            await _service.CancelItemAsync(sale.Id, itemToCancel.Id);

            // Assert
            itemToCancel.Status.Should().Be(SaleItemStatus.Cancelled);
            sale.TotalValue.Should().Be(sale.Products.Sum(x => x.FinalValue));
            await _saleRepository.Received(1).UpdateAsync(sale, Arg.Any<CancellationToken>());
        }

        [Fact(DisplayName = "CancelItemAsync should throw when sale not found")]
        public async Task CancelItemAsync_ShouldThrow_WhenSaleNotFound()
        {
            // Arrange
            var saleId = Guid.NewGuid();
            var itemId = Guid.NewGuid();
            _saleRepository.GetByIdAsync(saleId, Arg.Any<CancellationToken>()).Returns((Sale)null);

            // Act
            Func<Task> act = async () => await _service.CancelItemAsync(saleId, itemId);

            // Assert
            await act.Should().ThrowAsync<InvalidOperationException>()
                .WithMessage($"The sale {saleId} was not found.");
            await _saleRepository.DidNotReceive().UpdateAsync(Arg.Any<Sale>(), Arg.Any<CancellationToken>());
        }

        [Fact(DisplayName = "CreateAsync should create sale successfully when all products exist")]
        public async Task CreateAsync_ShouldCreateSale_WhenAllProductsExist()
        {
            // Arrange
            var sale = SaleTestData.GenerateValidSale();
            foreach (var item in sale.Products)
            {
                _productRepository.GetByIdAsync(item.ProductId, Arg.Any<CancellationToken>())
                    .Returns(new Product { Id = item.ProductId, Price = item.OriginalPrice });
            }

            _saleRepository.CreateAsync(sale, Arg.Any<CancellationToken>()).Returns(sale);

            // Act
            var result = await _service.CreateAsync(sale);

            // Assert
            result.Should().NotBeNull();
            result.TotalValue.Should().Be(sale.Products.Sum(x => x.FinalValue));
            await _saleRepository.Received(1).CreateAsync(sale, Arg.Any<CancellationToken>());
        }

        [Fact(DisplayName = "CreateAsync should throw when a product is not found")]
        public async Task CreateAsync_ShouldThrow_WhenProductNotFound()
        {
            // Arrange
            var sale = SaleTestData.GenerateValidSale();
            _productRepository.GetByIdAsync(sale.Products.First().ProductId, Arg.Any<CancellationToken>())
                .Returns((Product)null);

            // Act
            Func<Task> act = async () => await _service.CreateAsync(sale);

            // Assert
            await act.Should().ThrowAsync<InvalidOperationException>()
                .WithMessage($"The product {sale.Products.First().ProductId} was not found.");
            await _saleRepository.DidNotReceive().CreateAsync(Arg.Any<Sale>(), Arg.Any<CancellationToken>());
        }

        [Fact(DisplayName = "UpdateAsync should update sale successfully when all products exist and sale exists")]
        public async Task UpdateAsync_ShouldUpdateSale_WhenAllProductsExist()
        {
            // Arrange
            var sale = SaleTestData.GenerateValidSale();
            _saleRepository.GetByIdAsync(sale.Id, Arg.Any<CancellationToken>()).Returns(sale);

            foreach (var item in sale.Products)
            {
                _productRepository.GetByIdAsync(item.ProductId, Arg.Any<CancellationToken>())
                    .Returns(new Product { Id = item.ProductId, Price = item.OriginalPrice });
            }

            _saleRepository.UpdateAsync(sale, Arg.Any<CancellationToken>()).Returns(sale);

            // Act
            var result = await _service.UpdateAsync(sale);

            // Assert
            result.Should().NotBeNull();
            result.TotalValue.Should().Be(sale.Products.Sum(x => x.FinalValue));
            await _saleRepository.Received(1).UpdateAsync(sale, Arg.Any<CancellationToken>());
        }

        [Fact(DisplayName = "UpdateAsync should throw when sale not found")]
        public async Task UpdateAsync_ShouldThrow_WhenSaleNotFound()
        {
            // Arrange
            var sale = SaleTestData.GenerateValidSale();
            _saleRepository.GetByIdAsync(sale.Id, Arg.Any<CancellationToken>()).Returns((Sale)null);

            // Act
            Func<Task> act = async () => await _service.UpdateAsync(sale);

            // Assert
            await act.Should().ThrowAsync<InvalidOperationException>()
                .WithMessage($"The sale {sale.Id} was not found.");
            await _saleRepository.DidNotReceive().UpdateAsync(Arg.Any<Sale>(), Arg.Any<CancellationToken>());
        }

        [Fact(DisplayName = "UpdateAsync should throw when a product is not found")]
        public async Task UpdateAsync_ShouldThrow_WhenProductNotFound()
        {
            // Arrange
            var sale = SaleTestData.GenerateValidSale();
            _saleRepository.GetByIdAsync(sale.Id, Arg.Any<CancellationToken>()).Returns(sale);

            _productRepository.GetByIdAsync(sale.Products.First().ProductId, Arg.Any<CancellationToken>())
                .Returns((Product)null);

            // Act
            Func<Task> act = async () => await _service.UpdateAsync(sale);

            // Assert
            await act.Should().ThrowAsync<InvalidOperationException>()
                .WithMessage($"The product {sale.Products.First().ProductId} was not found.");
            await _saleRepository.DidNotReceive().UpdateAsync(Arg.Any<Sale>(), Arg.Any<CancellationToken>());
        }
    }
}

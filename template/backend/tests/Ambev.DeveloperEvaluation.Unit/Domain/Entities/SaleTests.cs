using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using FluentAssertions;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities
{
    public class SaleTests
    {
        [Fact(DisplayName = "Constructor should initialize sale with Active status and empty products")]
        public void Constructor_ShouldInitializeWithActiveStatus_AndEmptyProducts()
        {
            // Arrange & Act
            var sale = new Sale();

            // Assert
            sale.Status.Should().Be(SaleStatus.Active);
            sale.TotalValue.Should().Be(0);
            sale.Products.Should().BeEmpty();
        }

        [Fact(DisplayName = "Activate should set status to Active and activate all items")]
        public void Activate_ShouldSetStatusToActive_AndActivateItems()
        {
            // Arrange
            var sale = new Sale();
            sale.AddProduct(Guid.NewGuid(), 5, 10m);
            sale.Cancel();

            // Act
            sale.Activate();

            // Assert
            sale.Status.Should().Be(SaleStatus.Active);
            sale.Products.Should().AllSatisfy(item =>
                item.Status.Should().Be(SaleItemStatus.Active));
        }

        [Fact(DisplayName = "Cancel should set status to Cancelled and cancel all items")]
        public void Cancel_ShouldSetStatusToCancelled_AndCancelItems()
        {
            // Arrange
            var sale = new Sale();
            sale.AddProduct(Guid.NewGuid(), 5, 10m);

            // Act
            sale.Cancel();

            // Assert
            sale.Status.Should().Be(SaleStatus.Cancelled);
            sale.Products.Should().AllSatisfy(item =>
                item.Status.Should().Be(SaleItemStatus.Cancelled));
        }

        [Fact(DisplayName = "AddProduct should add a new product when it does not exist")]
        public void AddProduct_ShouldAddNewProduct_WhenProductDoesNotExist()
        {
            // Arrange
            var sale = new Sale();
            var productId = Guid.NewGuid();

            // Act
            sale.AddProduct(productId, 2, 10m);

            // Assert
            sale.Products.Should().ContainSingle()
                .Which.ProductId.Should().Be(productId);

            sale.TotalValue.Should().BeGreaterThan(0);
        }

        [Fact(DisplayName = "AddProduct should increase quantity when product already exists")]
        public void AddProduct_ShouldIncreaseQuantity_WhenProductAlreadyExists()
        {
            // Arrange
            var sale = new Sale();
            var productId = Guid.NewGuid();
            sale.AddProduct(productId, 2, 10m);

            // Act
            sale.AddProduct(productId, 3, 10m);

            // Assert
            var item = sale.Products.First(p => p.ProductId == productId);
            item.Quantity.Should().Be(5);
            sale.TotalValue.Should().Be(item.FinalValue);
        }

        [Fact(DisplayName = "AddProduct should throw when quantity exceeds 20")]
        public void AddProduct_ShouldThrow_WhenQuantityExceedsLimit()
        {
            // Arrange
            var sale = new Sale();
            var productId = Guid.NewGuid();

            // Act
            Action act = () => sale.AddProduct(productId, 25, 10m);

            // Assert
            act.Should().Throw<InvalidOperationException>()
                .WithMessage("It's not possible to sell more than 20 identical items.");
        }

        [Fact(DisplayName = "AddProduct should work when quantity is minimum 1")]
        public void AddProduct_ShouldWork_WhenQuantityIsOne()
        {
            // Arrange
            var sale = new Sale();

            // Act
            sale.AddProduct(Guid.NewGuid(), 1, 50m);

            // Assert
            sale.Products.Should().ContainSingle()
                .Which.Quantity.Should().Be(1);

            sale.TotalValue.Should().Be(sale.Products.First().FinalValue);
        }

        [Fact(DisplayName = "AddProduct should work when quantity is maximum 20")]
        public void AddProduct_ShouldWork_WhenQuantityIsAtLimit20()
        {
            // Arrange
            var sale = new Sale();

            // Act
            sale.AddProduct(Guid.NewGuid(), 20, 15m);

            // Assert
            var item = sale.Products.Single();
            item.Quantity.Should().Be(20);
            sale.TotalValue.Should().Be(item.FinalValue);
        }

        [Fact(DisplayName = "AddProduct should accumulate total when adding multiple products")]
        public void AddProduct_ShouldAccumulateTotal_WhenMultipleProductsAdded()
        {
            // Arrange
            var sale = new Sale();

            // Act
            sale.AddProduct(Guid.NewGuid(), 2, 10m);
            sale.AddProduct(Guid.NewGuid(), 3, 20m);

            // Assert
            sale.TotalValue.Should().Be(sale.Products.Sum(x => x.FinalValue));
            sale.Products.Should().HaveCount(2);
        }

        [Fact(DisplayName = "RecalculateTotal should update total value based on products")]
        public void RecalculateTotal_ShouldUpdateTotalValue()
        {
            // Arrange
            var sale = new Sale();
            sale.AddProduct(Guid.NewGuid(), 2, 10m);
            sale.AddProduct(Guid.NewGuid(), 4, 20m);

            // Act
            sale.RecalculateTotal();

            // Assert
            sale.TotalValue.Should().Be(sale.Products.Sum(x => x.FinalValue));
        }

        [Fact(DisplayName = "RecalculateTotal should work with no products")]
        public void RecalculateTotal_ShouldWork_WhenNoProducts()
        {
            // Arrange
            var sale = new Sale();

            // Act
            sale.RecalculateTotal();

            // Assert
            sale.TotalValue.Should().Be(0);
        }

        [Fact(DisplayName = "Cancel then Activate should restore Active status and activate items")]
        public void Cancel_Then_Activate_ShouldRestoreActiveStatusAndItems()
        {
            // Arrange
            var sale = new Sale();
            sale.AddProduct(Guid.NewGuid(), 5, 10m);
            sale.Cancel();

            // Act
            sale.Activate();

            // Assert
            sale.Status.Should().Be(SaleStatus.Active);
            sale.Products.Should().AllSatisfy(item =>
                item.Status.Should().Be(SaleItemStatus.Active));
        }
    }
}

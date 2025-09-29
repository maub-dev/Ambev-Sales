using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData
{
    /// <summary>
    /// Provides methods for generating test data using the Bogus library.
    /// This class centralizes all test data generation to ensure consistency
    /// across test cases and provide both valid and invalid data scenarios.
    /// </summary>
    public static class SaleTestData
    {
        /// <summary>
        /// Configures the Faker to generate valid SaleItem value objects.
        /// The generated cart items will have valid:
        /// - SaleId
        /// - ProductId
        /// - OriginalPrice
        /// - Quantity
        /// - Status
        /// </summary>
        private static readonly Faker<SaleItem> SaleItemFaker = new Faker<SaleItem>()
            .RuleFor(x => x.SaleId, f => f.Random.Guid())
            .RuleFor(x => x.ProductId, f => f.Random.Guid())
            .RuleFor(x => x.OriginalPrice, f => f.Random.Decimal(0.1M))
            .RuleFor(x => x.Status, f => SaleItemStatus.Active)
            .RuleFor(x => x.Quantity, f => f.Random.Int(1, 20));


        /// <summary>
        /// Configures the Faker to generate valid Cart entities.
        /// The generated carts will have valid:
        /// - Date
        /// - UserId
        /// - Products (using CartItemFaker)
        /// </summary>
        private static readonly Faker<Sale> SaleFaker = new Faker<Sale>()
            .RuleFor(x => x.Date, f => f.Date.Recent())
            .RuleFor(x => x.SaleNumber, f => f.Random.Int(1))
            .RuleFor(x => x.Customer, f => f.Random.String2(3, 100))
            .RuleFor(x => x.Branch, f => f.Random.Int(1))
            .RuleFor(x => x.Status, f => SaleStatus.Active)
            .RuleFor(x => x.Products, f => SaleItemFaker.Generate(5));

        public static SaleItem GenerateValidSaleItem()
        {
            var saleItem = SaleItemFaker.Generate();

            // Used just to recalculate the SaleItem values
            saleItem.SetQuantity(saleItem.Quantity);

            return saleItem;
        }

        public static Sale GenerateValidSale()
        {
            var sale = SaleFaker.Generate();
            foreach (var item in sale.Products)
            {
                // Used just to recalculate the SaleItem values
                item.SetQuantity(item.Quantity);
            }

            sale.RecalculateTotal();

            return sale;
        }
    }
}

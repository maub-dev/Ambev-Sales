using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.ValueObjects;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData
{
    /// <summary>
    /// Provides methods for generating test data using the Bogus library.
    /// This class centralizes all test data generation to ensure consistency
    /// across test cases and provide both valid and invalid data scenarios.
    /// </summary>
    public static class CartTestData
    {
        /// <summary>
        /// Configures the Faker to generate valid CartItem value objects.
        /// The generated cart items will have valid:
        /// - ProductId
        /// - Quantity
        /// </summary>
        private static readonly Faker<CartItem> CartItemFaker = new Faker<CartItem>()
            .RuleFor(x => x.ProductId, f => f.Random.Guid())
            .RuleFor(x => x.Quantity, f => f.Random.Int(1, 20));

        /// <summary>
        /// Configures the Faker to generate valid Cart entities.
        /// The generated carts will have valid:
        /// - Date
        /// - UserId
        /// - Products (using CartItemFaker)
        /// </summary>
        private static readonly Faker<Cart> CartFaker = new Faker<Cart>()
            .RuleFor(x => x.Date, f => f.Date.Recent())
            .RuleFor(x => x.UserId, f => f.Random.Guid())
            .RuleFor(x => x.Products, f => CartItemFaker.Generate(5));

        /// <summary>
        /// Generates a valid Cart entity with randomized data.
        /// The generated cart will have all properties populated with valid values
        /// that meet the system's validation requirements.
        /// </summary>
        /// <returns>A valid Cart entity with randomly generated data.</returns>
        public static Cart GenerateValidCart()
        {
            return CartFaker.Generate();
        }

        /// <summary>
        /// Generates a valid CartItem value object with randomized data.
        /// The generated cart item will have all properties populated with valid values
        /// that meet the system's validation requirements.
        /// </summary>
        /// <returns>A valid CartItem entity with randomly generated data.</returns>
        public static CartItem GenerateValidCartItem()
        {
            return CartItemFaker.Generate();
        }
    }
}

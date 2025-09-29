using Ambev.DeveloperEvaluation.Application.Carts.CreateCart;
using Ambev.DeveloperEvaluation.Application.Carts.Shared;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Application.TestData
{
    public static class CreateCartHandlerTestData
    {
        /// <summary>
        /// Configures the Faker to generate valid CreateCartCommand entities.
        /// The generated carts will have valid:
        /// - Date (recent date)
        /// - UserId (new Guid)
        /// - Products (1 to 5 valid cart items)
        /// </summary>
        private static readonly Faker<CreateCartCommand> createCartFaker = new Faker<CreateCartCommand>()
            .RuleFor(c => c.Date, f => f.Date.Recent())
            .RuleFor(c => c.UserId, _ => Guid.NewGuid())
            .RuleFor(c => c.Products, f => cartItemFaker.Generate(f.Random.Int(1, 5)));

        /// <summary>
        /// Configures the Faker to generate valid CartItemDto entities.
        /// The generated items will have valid:
        /// - ProductId (new Guid)
        /// - Quantity (between 1 and 10)
        /// </summary>
        private static readonly Faker<CartItemDto> cartItemFaker = new Faker<CartItemDto>()
            .RuleFor(p => p.ProductId, _ => Guid.NewGuid())
            .RuleFor(p => p.Quantity, f => f.Random.Int(1, 10));

        /// <summary>
        /// Generates a valid CreateCartCommand with randomized data.
        /// The generated cart will have all properties populated with valid values
        /// that meet the system's validation requirements.
        /// </summary>
        /// <returns>A valid CreateCartCommand with randomly generated data.</returns>
        public static CreateCartCommand GenerateValidCommand()
        {
            return createCartFaker.Generate();
        }
    }
}

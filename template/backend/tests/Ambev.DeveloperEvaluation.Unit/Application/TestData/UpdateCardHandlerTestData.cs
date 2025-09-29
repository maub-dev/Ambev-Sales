using Ambev.DeveloperEvaluation.Application.Carts.Shared;
using Ambev.DeveloperEvaluation.Application.Carts.UpdateCart;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Application.TestData
{
    public static class UpdateCardHandlerTestData
    {
        private static readonly Faker<UpdateCartCommand> updateCartHandlerFaker =
            new Faker<UpdateCartCommand>()
                .RuleFor(c => c.Id, f => f.Random.Guid())
                .RuleFor(c => c.Date, f => f.Date.Recent())
                .RuleFor(c => c.UserId, f => f.Random.Guid())
                .RuleFor(c => c.Products, f =>
                    new Faker<CartItemDto>()
                        .RuleFor(p => p.ProductId, _ => Guid.NewGuid())
                        .RuleFor(p => p.Quantity, _ => f.Random.Int(1, 10))
                        .Generate(f.Random.Int(1, 5)));

        /// <summary>
        /// Generates a valid UpdateCartCommand with randomized data.
        /// The generated command will have all properties populated with valid values
        /// that meet the system's validation requirements.
        /// </summary>
        /// <returns>A valid UpdateCartCommand instance.</returns>
        public static UpdateCartCommand GenerateValidCommand()
        {
            return updateCartHandlerFaker.Generate();
        }

        /// <summary>
        /// Generates multiple valid UpdateCartCommand instances with randomized data.
        /// </summary>
        /// <param name="count">Number of commands to generate</param>
        /// <returns>A list of valid UpdateCartCommand instances.</returns>
        public static List<UpdateCartCommand> GenerateValidCommands(int count)
        {
            return updateCartHandlerFaker.Generate(count);
        }
    }
}

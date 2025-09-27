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
    public static class ProductTestData
    {
        /// <summary>
        /// Configures the Faker to generate valid Rating value objects.
        /// The generated ratings will have valid:
        /// - Rate
        /// - Count
        /// </summary>
        private static readonly Faker<Rating> RatingFaker = new Faker<Rating>()
            .RuleFor(x => x.Rate, f => f.Random.Double(0, 5))
            .RuleFor(x => x.Count, f => f.Random.Int(0));

        /// <summary>
        /// Configures the Faker to generate valid Product entities.
        /// The generated products will have valid:
        /// - Title
        /// - Price
        /// - Description
        /// - Category
        /// - Image
        /// - Rating (using Faker)
        /// </summary>
        private static readonly Faker<Product> ProductFaker = new Faker<Product>()
            .RuleFor(x => x.Title, f => f.Random.String(5, 100))
            .RuleFor(x => x.Price, f => f.Random.Decimal(0.1M))
            .RuleFor(x => x.Description, f => f.Random.String(10, 500))
            .RuleFor(x => x.Category, f => f.Random.String(5, 100))
            .RuleFor(x => x.Image, f => f.Random.String(1, 1000))
            .RuleFor(x => x.Rating, f => RatingFaker.Generate());

        /// <summary>
        /// Generates a valid Product entity with randomized data.
        /// The generated product will have all properties populated with valid values
        /// that meet the system's validation requirements.
        /// </summary>
        /// <returns>A valid Product entity with randomly generated data.</returns>
        public static Product GenerateValidProduct()
        {
            return ProductFaker.Generate();
        }

        /// <summary>
        /// Generates a title that exceeds the maximum length limit.
        /// The generated title will:
        /// - Be longer than 100 characters
        /// - Contain random alphanumeric characters
        /// This is useful for testing username title validation error cases.
        /// </summary>
        /// <returns>A title that exceeds the maximum length limit.</returns>
        public static string GenerateLongTitle()
        {
            return new Faker().Random.String2(101);
        }

        /// <summary>
        /// Generates a description that exceeds the maximum length limit.
        /// The generated description will:
        /// - Be longer than 500 characters
        /// - Contain random alphanumeric characters
        /// This is useful for testing description length validation error cases.
        /// </summary>
        /// <returns>A description that exceeds the maximum length limit.</returns>
        public static string GenerateLongDescription()
        {
            return new Faker().Random.String2(501);
        }

        /// <summary>
        /// Generates a category that exceeds the maximum length limit.
        /// The generated category will:
        /// - Be longer than 100 characters
        /// - Contain random alphanumeric characters
        /// This is useful for testing category length validation error cases.
        /// </summary>
        /// <returns>A category that exceeds the maximum length limit.</returns>
        public static string GenerateLongCategory()
        {
            return new Faker().Random.String2(101);
        }

        /// <summary>
        /// Generates an image that exceeds the maximum length limit.
        /// The generated image will:
        /// - Be longer than 1000 characters
        /// - Contain random alphanumeric characters
        /// This is useful for testing image length validation error cases.
        /// </summary>
        /// <returns>An image that exceeds the maximum length limit.</returns>
        public static string GenerateLongImage()
        {
            var faker = new Faker();
            return faker.Internet.UrlWithPath("https", faker.Random.String2(1001));
        }
    }
}

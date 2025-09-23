namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.Shared
{
    /// <summary>
    /// Represents a response for Product's Rating in the system.
    /// </summary>
    public class RatingResponse
    {
        /// <summary>
        /// Gets the product's rate
        /// It represents the average of all ratings
        /// </summary>
        public double? Rate { get; set; }

        /// <summary>
        /// Gets the product's rating count
        /// Must not be null, it should start with zero
        /// </summary>
        public int Count { get; set; }
    }
}

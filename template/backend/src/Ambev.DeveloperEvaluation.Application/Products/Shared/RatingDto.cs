namespace Ambev.DeveloperEvaluation.Application.Products.Shared
{
    /// <summary>
    /// Data Transfer Object that represents the rating informations for a product
    /// </summary>
    public class RatingDto
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

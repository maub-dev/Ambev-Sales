namespace Ambev.DeveloperEvaluation.Domain.ValueObjects
{
    /// <summary>
    /// Value Object that represents the rating informations for a product
    /// </summary>
    public class Rating
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

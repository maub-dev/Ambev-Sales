using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.ValueObjects;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    /// <summary>
    /// Represents a product in the domain, including basic information and its rating.
    /// </summary>
    public class Product : BaseEntity
    {
        /// <summary>
        /// Gets the product's title
        /// Must not be null or empty and should be short
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Gets the product's price
        /// Must not be null or zero
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets the product's full description
        /// Must not be null or empty and this should contain more details of the product
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Gets the product's category
        /// Must not be null or empty and indicate the group the product belongs
        /// </summary>
        public string Category { get; set; } = string.Empty;

        /// <summary>
        /// Gets the product's image URL
        /// Must not be null or empty and needs to be a public access URL
        /// </summary>
        public string Image { get; set; } = string.Empty;

        /// <summary>
        /// Gets the product's rating
        /// </summary>
        public Rating Rating { get; set; }
    }
}

using Ambev.DeveloperEvaluation.Application.Products.Shared;

namespace Ambev.DeveloperEvaluation.Application.Products.GetAllProducts
{
    /// <summary>
    /// Represents the response item returned for product's listing.
    /// </summary>
    public class GetAllProductsResult
    {
        /// <summary>
        /// Gets or sets the unique identifier of the product.
        /// </summary>
        /// <value>A GUID that uniquely identifies the product in the system.</value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets the product's title
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Gets the product's price
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets the product's full description
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Gets the product's category
        /// </summary>
        public string Category { get; set; } = string.Empty;

        /// <summary>
        /// Gets the product's image URL
        /// </summary>
        public string Image { get; set; } = string.Empty;

        /// <summary>
        /// Gets the product's rating
        /// </summary>
        public RatingDto Rating { get; set; }
    }
}

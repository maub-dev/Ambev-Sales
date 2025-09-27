using Ambev.DeveloperEvaluation.WebApi.Features.Products.Shared;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetAllProductsForCategory
{
    /// <summary>
    /// Represents the response item returned for listing all products withing a specific category
    /// </summary>
    public class GetAllProductsForCategoryResponse
    {
        /// <summary>
        /// Gets or sets the unique identifier of the newly created product.
        /// </summary>
        /// <value>A GUID that uniquely identifies the created product in the system.</value>
        public Guid Id { get; set; }

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
        public RatingRequest Rating { get; set; }
    }
}

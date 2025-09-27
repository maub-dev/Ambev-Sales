using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.ValueObjects
{
    /// <summary>
    /// Value Object that represents a item of cart entity
    /// </summary>
    public class CartItem
    {
        /// <summary>
        /// Gets the product id for the cart item
        /// Must not be null
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// Gets the product entity related with the ProductId
        /// </summary>
        public Product? Product { get; set; }

        /// <summary>
        /// Gets the quantity of the products
        /// Must not be null
        /// </summary>
        public int Quantity { get; set; }
    }
}

namespace Ambev.DeveloperEvaluation.Application.Carts.Shared
{
    public class CartItemDto
    {
        /// <summary>
        /// Gets the cart id that owns the cart item
        /// Must not be null
        /// </summary>
        public Guid CartId { get; set; }

        /// <summary>
        /// Gets the product id for the cart item
        /// Must not be null
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// Gets the quantity of the products
        /// Must not be null
        /// </summary>
        public int Quantity { get; set; }
    }
}

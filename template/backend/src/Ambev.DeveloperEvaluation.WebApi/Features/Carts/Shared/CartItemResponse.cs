namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.Shared
{
    public class CartItemResponse
    {
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

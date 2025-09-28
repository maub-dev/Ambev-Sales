using Ambev.DeveloperEvaluation.WebApi.Features.Carts.Shared;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.GetAllCarts
{
    /// <summary>
    /// Represents the response item returned for listing all carts
    /// </summary>
    public class GetAllCartsResponse
    {
        /// <summary>
        /// Gets or sets the unique identifier of a cart.
        /// </summary>
        /// <value>A GUID that uniquely identifies a cart in the system.</value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets the cart's last modification date
        /// Must not be null
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets the user id that owns this cart
        /// Must not be null
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Gets the products of the cart
        /// </summary>
        public IEnumerable<CartItemResponse> Products { get; set; } = [];
    }
}

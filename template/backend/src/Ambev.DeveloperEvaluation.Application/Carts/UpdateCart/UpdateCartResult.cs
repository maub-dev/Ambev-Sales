using Ambev.DeveloperEvaluation.Application.Carts.Shared;

namespace Ambev.DeveloperEvaluation.Application.Carts.UpdateCart
{
    /// <summary>
    /// Represents the response returned after successfully updating a cart.
    /// </summary>
    public class UpdateCartResult
    {
        /// <summary>
        /// Gets or sets the unique identifier of the cart.
        /// </summary>
        /// <value>A GUID that uniquely identifies the created cart in the system.</value>
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
        public IEnumerable<CartItemDto> Products { get; set; } = [];
    }
}

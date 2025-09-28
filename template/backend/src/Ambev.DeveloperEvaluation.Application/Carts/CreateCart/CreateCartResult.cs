using Ambev.DeveloperEvaluation.Application.Carts.Shared;

namespace Ambev.DeveloperEvaluation.Application.Carts.CreateCart
{
    /// <summary>
    /// Represents the response returned after successfully creating a new cart.
    /// </summary>
    /// <remarks>
    /// This response contains the unique identifier of the newly created cart,
    /// which can be used for subsequent operations or reference.
    /// </remarks>
    public class CreateCartResult
    {
        /// <summary>
        /// Gets or sets the unique identifier of the newly created cart.
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

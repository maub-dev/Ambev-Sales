using Ambev.DeveloperEvaluation.WebApi.Features.Carts.Shared;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.CreateCart
{
    public class CreateCartResponse
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
        public IEnumerable<CartItemResponse> Products { get; set; } = [];
    }
}

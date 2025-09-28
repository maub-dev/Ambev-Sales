using Ambev.DeveloperEvaluation.Application.Carts.Shared;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.UpdateCart
{
    /// <summary>
    /// Command for updating a cart by their ID
    /// </summary>
    public class UpdateCartCommand : IRequest<UpdateCartResult>
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

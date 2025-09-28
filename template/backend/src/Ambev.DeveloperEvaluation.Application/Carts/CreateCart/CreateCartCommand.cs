using Ambev.DeveloperEvaluation.Application.Carts.Shared;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.CreateCart
{
    /// <summary>
    /// Command for creating a new cart
    /// </summary>
    public class CreateCartCommand : IRequest<CreateCartResult>
    {
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

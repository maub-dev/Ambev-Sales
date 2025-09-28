using Ambev.DeveloperEvaluation.Application.Carts.Shared;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.Shared;
using Microsoft.AspNetCore.Mvc;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.UpdateCart
{
    public class UpdateCartRequest
    {
        /// <summary>
        /// Gets or sets the unique identifier of the cart.
        /// </summary>
        /// <value>A GUID that uniquely identifies the cart in the system.</value>
        public Guid Id { get; private set; }

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
        public IEnumerable<CartItemRequest> Products { get; set; } = [];

        public void SetId(Guid id)
        {
            Id = id;
        }
    }
}

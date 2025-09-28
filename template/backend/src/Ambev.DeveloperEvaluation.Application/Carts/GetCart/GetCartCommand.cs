using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.GetCart
{
    /// <summary>
    /// Command for retrieving a cart by their ID
    /// </summary>
    public class GetCartCommand : IRequest<GetCartResult>
    {
        /// <summary>
        /// The unique identifier of the cart to retrieve
        /// </summary>
        public Guid Id { get; set; }
    }
}

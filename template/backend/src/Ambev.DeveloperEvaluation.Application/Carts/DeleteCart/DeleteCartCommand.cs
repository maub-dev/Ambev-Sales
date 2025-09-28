using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.DeleteCart
{
    /// <summary>
    /// Request model for deleting a cart
    /// </summary>
    public class DeleteCartCommand : IRequest<DeleteCartResult>
    {
        /// <summary>
        /// The unique identifier of the user to delete
        /// </summary>
        public Guid Id { get; set; }
    }
}

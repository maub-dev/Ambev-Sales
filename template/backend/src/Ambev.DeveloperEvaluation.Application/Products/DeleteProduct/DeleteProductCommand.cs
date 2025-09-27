using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.DeleteProduct
{
    /// <summary>
    /// Request model for deleting a user
    /// </summary>
    public class DeleteProductCommand : IRequest<DeleteProductResult>
    {
        /// <summary>
        /// The unique identifier of the user to delete
        /// </summary>
        public Guid Id { get; set; }
    }
}

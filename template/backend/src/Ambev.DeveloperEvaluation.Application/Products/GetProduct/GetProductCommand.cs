using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProduct
{
    /// <summary>
    /// Command for retrieving a product by their ID
    /// </summary>
    public class GetProductCommand : IRequest<GetProductResult>
    {
        /// <summary>
        /// The unique identifier of the product to retrieve
        /// </summary>
        public Guid Id { get; set; }
    }
}

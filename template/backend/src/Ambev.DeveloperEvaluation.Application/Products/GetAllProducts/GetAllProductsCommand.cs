using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.GetAllProducts
{
    /// <summary>
    /// Request model to get all products list
    /// </summary>
    public class GetAllProductsCommand : IRequest<IQueryable<GetAllProductsResult>>
    {
        
    }
}

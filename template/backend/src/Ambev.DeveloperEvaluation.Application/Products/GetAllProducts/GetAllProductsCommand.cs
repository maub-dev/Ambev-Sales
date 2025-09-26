using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.GetAllProducts
{
    public class GetAllProductsCommand : IRequest<IQueryable<GetAllProductsResult>>
    {
        
    }
}

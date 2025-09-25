using Ambev.DeveloperEvaluation.Application.Common.Pagination;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.GetAllProducts
{
    public class GetAllProductsCommand : PaginatedCommand, IRequest<IEnumerable<GetAllProductsResult>>
    {
        
    }
}

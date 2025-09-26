using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.GetAllCategories
{
    /// <summary>
    /// Request model to get all product categories
    /// </summary>
    public class GetAllCategoriesCommand : IRequest<GetAllCategoriesResult>
    {
    }
}

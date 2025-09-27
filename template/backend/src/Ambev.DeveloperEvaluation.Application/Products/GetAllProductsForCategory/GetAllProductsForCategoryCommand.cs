using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.GetAllProductsForCategory
{
    /// <summary>
    /// Request model to get all products for a specific category
    /// </summary>
    public class GetAllProductsForCategoryCommand : IRequest<IQueryable<GetAllProductsForCategoryResult>>
    {
        /// <summary>
        /// The category to filter the products
        /// </summary>
        public string Category { get; set; } = string.Empty;
    }
}

using Ambev.DeveloperEvaluation.WebApi.Common;
using Microsoft.AspNetCore.Mvc;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetAllProductsForCategory
{
    /// <summary>
    /// Request model to get all products for a particular category
    /// </summary>
    public class GetAllProductsForCategoryRequest : PaginatedRequest
    {
        /// <summary>
        /// The category to filter
        /// </summary>
        [FromRoute(Name="category")]
        public string Category { get; set; } = string.Empty;
    }
}

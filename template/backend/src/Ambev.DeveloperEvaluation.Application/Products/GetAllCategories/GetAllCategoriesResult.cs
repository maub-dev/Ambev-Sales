namespace Ambev.DeveloperEvaluation.Application.Products.GetAllCategories
{
    /// <summary>
    /// Represents the response returned for get all product categories
    /// </summary>
    public class GetAllCategoriesResult
    {
        /// <summary>
        /// Gets the list of categories (only unique values)
        /// </summary>
        public IEnumerable<string> Categories { get; set; } = [];
    }
}

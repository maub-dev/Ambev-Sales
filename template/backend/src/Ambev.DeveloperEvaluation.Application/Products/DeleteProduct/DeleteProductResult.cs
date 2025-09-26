namespace Ambev.DeveloperEvaluation.Application.Products.DeleteProduct
{
    /// <summary>
    /// Represents the response returned after successfully deleting a product.
    /// </summary>
    public class DeleteProductResult
    {
        /// <summary>
        /// Gets the status of the delete product
        /// </summary>
        /// <value>True if the Product existed and was deleted succesfully.</value>
        public bool Success { get; set; }
    }
}

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.Shared
{
    public class SaleItemRequest
    {
        /// <summary>
        /// The sale id which this item belongs
        /// Must not be null
        /// </summary>
        public Guid SaleId { get; set; }

        /// <summary>
        /// The product id which this item refers
        /// Must not be null
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// The quantity being selled
        /// Must not be null
        /// </summary>
        public int Quantity { get; set; }
    }
}

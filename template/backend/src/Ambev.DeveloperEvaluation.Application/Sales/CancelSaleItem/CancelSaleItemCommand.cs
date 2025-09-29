using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CancelSaleItem
{
    /// <summary>
    /// Request model for cancelling a sale item
    /// </summary>
    public class CancelSaleItemCommand : IRequest<CancelSaleItemResult>
    {
        /// <summary>
        /// The unique identifier of the sale that owns the item to be cancelled
        /// </summary>
        public Guid SaleId { get; set; }

        /// <summary>
        /// The unique identifier of the sale item to be cancelled
        /// </summary>
        public Guid SaleItemId { get; set; }
    }
}

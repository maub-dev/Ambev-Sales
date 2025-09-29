using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Application.Sales.Shared
{
    public class SaleItemDto
    {
        /// <summary>
        /// The unique identifier for this sale item
        /// </summary>
        public Guid Id { get; set; }

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

        /// <summary>
        /// The gross price
        /// Must not be null
        /// </summary>
        public decimal OriginalPrice { get; set; }

        /// <summary>
        /// The percent to be discounted in OriginalPrice
        /// Must not be null
        /// </summary>
        public decimal DiscountPercentage { get; set; }

        /// <summary>
        /// The net price (after discounts being applied)
        /// Must not be null
        /// </summary>
        public decimal FinalValue { get; set; }

        /// <summary>
        /// The item status
        /// Must not be null
        /// </summary>
        public SaleItemStatus Status { get; set; }
    }
}

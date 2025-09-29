using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.Shared;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale
{
    public class UpdateSaleResponse
    {
        /// <summary>
        /// Gets or sets the unique identifier of the newly created sale.
        /// </summary>
        /// <value>A GUID that uniquely identifies the created sale in the system.</value>
        public Guid Id { get; set; }

        /// <summary>
        /// The sale number in the system
        /// </summary>
        public int SaleNumber { get; set; }

        /// <summary>
        /// The date of the sale
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// The Customer that bought the products
        /// </summary>
        public string Customer { get; set; } = string.Empty;

        /// <summary>
        /// Branch which the sale was made
        /// </summary>
        public int Branch { get; set; }

        /// <summary>
        /// The net amount customer is going to pay
        /// </summary>
        public decimal TotalValue { get; set; }

        /// <summary>
        /// The Sale status
        /// </summary>
        public SaleStatus Status { get; set; }

        /// <summary>
        /// The list of the products
        /// </summary>
        public IEnumerable<SaleItemResponse> Products { get; private set; } = new List<SaleItemResponse>();
    }
}

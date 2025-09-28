using Ambev.DeveloperEvaluation.Application.Sales.Shared;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    public class CreateSaleCommand : IRequest<CreateSaleResult>
    {
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
        /// The list of the products
        /// </summary>
        public IEnumerable<SaleItemDto> Products { get; set; } = new List<SaleItemDto>();
    }
}

using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Sale : BaseEntity
    {
        public Sale()
        {
            Activate();
        }

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
        /// The net amount customer is going to pay
        /// </summary>
        public decimal TotalValue { get; private set; }

        /// <summary>
        /// Branch which the sale was made
        /// </summary>
        public int Branch { get; set; }

        /// <summary>
        /// The list of the products
        /// </summary>
        public IEnumerable<SaleItem> Products { get; private set; } = new List<SaleItem>();

        /// <summary>
        /// The Sale status
        /// </summary>
        public SaleStatus Status { get; private set; } = SaleStatus.Active;

        public void Activate()
        { 
            Status = SaleStatus.Active;
            
            foreach (SaleItem item in Products)
                item.Activate();
        }

        public void Cancel()
        { 
            Status = SaleStatus.Cancelled;
            foreach (SaleItem item in Products)
                item.Cancel();
        }

        public void AddProduct(Guid productId, int quantity, decimal originalPrice)
        {
            if (quantity > 20)
                throw new InvalidOperationException("It's not possible to sell more than 20 identical items.");

            var existing = Products.FirstOrDefault(p => p.ProductId == productId);
            if (existing != null)
            {
                existing.IncreaseQuantity(quantity);
            }
            else
            {
                var newItem = new SaleItem(Id, productId, quantity, originalPrice);
                Products = Products.Append(newItem);
            }

            RecalculateTotal();
        }

        public void RecalculateTotal()
        {
            foreach (var item in Products)
                item.CalculateValues();

            TotalValue = Products.Sum(x => x.FinalValue);
        }
    }
}

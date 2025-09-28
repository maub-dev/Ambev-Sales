using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Sale : BaseEntity
    {
        public int SaleNumber { get; set; }

        public DateTime Date { get; set; }

        public string Customer { get; set; } = string.Empty;

        public decimal TotalValue { get; private set; }

        public int Branch { get; set; }

        public IEnumerable<SaleItem> Products { get; private set; } = new List<SaleItem>();

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
            TotalValue = Products.Sum(x => x.FinalValue);
        }
    }
}

using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class SaleItem : BaseEntity
    {
        private const decimal Discount10 = 0.10m;
        private const decimal Discount20 = 0.20m;

        public SaleItem() { }

        public SaleItem(Guid saleId, Guid productId, int quantity, decimal originalPrice)
        {
            SaleId = saleId;
            ProductId = productId;
            OriginalPrice = originalPrice;
            SetQuantity(quantity);
            Activate();
        }

        public Guid SaleId { get; set; }
        
        public Sale? Sale { get; set; }

        public Guid ProductId { get; set; }

        public Product? Product { get; set; }

        public int Quantity { get; private set; }

        public decimal OriginalPrice { get; private set; }

        public decimal DiscountPercentage { get; private set; }

        public decimal FinalValue { get; set; }

        public SaleItemStatus Status { get; private set; }

        public void Activate()
        {
            Status = SaleItemStatus.Active;
        }

        public void Cancel()
        {
            Status = SaleItemStatus.Cancelled;
        }

        public void ChangeOriginalPrice(decimal newPrice)
        {
            if (newPrice <= 0)
                throw new DomainException("The price cannot be zero or less.");
            
            OriginalPrice = newPrice;

            CalculateTotal();
        }
        public void IncreaseQuantity(int quantity)
        {
            SetQuantity(Quantity + quantity);
        }

        public void SetQuantity(int quantity)
        {
            if (quantity > 20)
                throw new DomainException("It's not possible to sell more than 20 identical items.");

            Quantity = quantity;

            ApplyDiscountRules();
            CalculateTotal();
        }

        private void ApplyDiscountRules()
        {
            DiscountPercentage = 0;

            if (Quantity >= 4 && Quantity < 10)
                DiscountPercentage = Discount10;
            else if (Quantity >= 10 && Quantity <= 20)
                DiscountPercentage = Discount20;
        }

        private void CalculateTotal()
        {
            var gross = Quantity * OriginalPrice;
            var discount = gross * DiscountPercentage;
            FinalValue = gross - discount;
        }
    }
}

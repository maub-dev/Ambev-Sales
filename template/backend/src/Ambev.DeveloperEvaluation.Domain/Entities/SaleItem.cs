using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class SaleItem : BaseEntity
    {
        private const decimal Discount10 = 0.10m;
        private const decimal Discount20 = 0.20m;

        public SaleItem() 
        {
            Activate();
        }

        public SaleItem(Guid saleId, Guid productId, int quantity, decimal originalPrice)
        {
            SaleId = saleId;
            ProductId = productId;
            OriginalPrice = originalPrice;
            SetQuantity(quantity);
            Activate();
        }

        /// <summary>
        /// The sale id which this item belongs
        /// Must not be null
        /// </summary>
        public Guid SaleId { get; set; }

        /// <summary>
        /// The sale which this item belongs
        /// </summary>
        public Sale? Sale { get; set; }

        /// <summary>
        /// The product id which this item refers
        /// Must not be null
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// The product which this item refers
        /// </summary>
        public Product? Product { get; set; }

        /// <summary>
        /// The quantity being selled
        /// Must not be null
        /// </summary>
        public int Quantity { get; private set; }

        /// <summary>
        /// The gross price
        /// Must not be null
        /// </summary>
        public decimal OriginalPrice { get; private set; }

        /// <summary>
        /// The percent to be discounted in OriginalPrice
        /// Must not be null
        /// </summary>
        public decimal DiscountPercentage { get; private set; }

        /// <summary>
        /// The net price (after discounts being applied)
        /// Must not be null
        /// </summary>
        public decimal FinalValue { get; set; }

        /// <summary>
        /// The item status
        /// Must not be null
        /// </summary>
        public SaleItemStatus Status { get; private set; } = SaleItemStatus.Active;

        /// <summary>
        /// Activates the item
        /// </summary>
        public void Activate()
        {
            Status = SaleItemStatus.Active;
        }

        /// <summary>
        /// Cancels the item
        /// </summary>
        public void Cancel()
        {
            Status = SaleItemStatus.Cancelled;
        }

        /// <summary>
        /// Changes the original price
        /// </summary>
        public void SetOriginalPrice(decimal newPrice)
        {
            if (newPrice <= 0)
                throw new DomainException("The price cannot be zero or less.");
            
            OriginalPrice = newPrice;

            CalculateValues();
        }

        /// <summary>
        /// Increase the value in the actual quantity in the item
        /// </summary>
        /// <param name="quantity">The quantity to be increased</param>
        public void IncreaseQuantity(int quantity)
        {
            SetQuantity(Quantity + quantity);
        }

        /// <summary>
        /// Replaces the actual quantity with the new value
        /// </summary>
        /// <param name="quantity">The new item quantity</param>
        /// <exception cref="DomainException">Throws a DomainException if the quantity is being set an invalid range</exception>
        public void SetQuantity(int quantity)
        {
            if (quantity < 1 || quantity > 20)
                throw new DomainException("The Quantity must be between 1 and 20.");

            Quantity = quantity;

            CalculateValues();
        }

        private void ApplyDiscountRules()
        {
            DiscountPercentage = 0;

            if (Quantity >= 4 && Quantity < 10)
                DiscountPercentage = Discount10;
            else if (Quantity >= 10 && Quantity <= 20)
                DiscountPercentage = Discount20;
        }

        public void CalculateValues()
        {
            ApplyDiscountRules();

            if (Status == SaleItemStatus.Cancelled)
            {
                FinalValue = 0;
                return;
            }

            var gross = Quantity * OriginalPrice;
            var discount = gross * DiscountPercentage;
            FinalValue = gross - discount;
        }
    }
}

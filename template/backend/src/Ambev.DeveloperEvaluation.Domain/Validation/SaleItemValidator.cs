using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation
{
    /// <summary>
    /// Validator for SaleItem entity.
    /// </summary>
    public class SaleItemValidator : AbstractValidator<SaleItem>
    {
        /// <summary>
        /// Initializes a new instance of the SaleItemValidator with defined validation rules.
        /// </summary>
        /// <remarks>
        /// Validation rules include:
        /// - SaleId: Not empty
        /// - ProductId: Not empty
        /// - Quantity: Not empty, value between 1 and 20
        /// - OriginalPrice: Not empty 
        /// - DiscountPercentage: Not null 
        /// - FinalValue: Not empty 
        /// - Status: Cannot be Unknown
        /// </remarks>
        public SaleItemValidator()
        {
            //RuleFor(x => x.SaleId)
            //    .NotEmpty();

            RuleFor(x => x.ProductId)
                .NotEmpty();

            RuleFor(x => x.Quantity)
                .NotEmpty()
                .InclusiveBetween(1, 20);

            RuleFor(x => x.OriginalPrice)
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(x => x.DiscountPercentage)
                .NotNull()
                .GreaterThanOrEqualTo(0);

            RuleFor(x => x.FinalValue)
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(x => x.Status)
                .NotEqual(SaleItemStatus.Unknown).WithMessage("Sale item status cannot be Unknown.");
        }
    }
}

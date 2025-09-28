using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.Shared
{
    public class SaleItemRequestValidator : AbstractValidator<SaleItemRequest>
    {
        /// <summary>
        /// Initializes a new instance of the CartItemDtoValidator with defined validation rules.
        /// </summary>
        /// <remarks>
        /// Validation rules include:
        /// - SaleId: Not Empty
        /// - ProductId: Not Empty
        /// - Quantity: Value must be between 1 and 20
        /// - OriginalPrice: Not empty and greater than zero
        /// </remarks>
        public SaleItemRequestValidator()
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
        }
    }
}

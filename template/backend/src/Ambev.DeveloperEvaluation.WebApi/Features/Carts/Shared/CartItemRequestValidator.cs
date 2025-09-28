using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.Shared
{
    public class CartItemRequestValidator : AbstractValidator<CartItemRequest>
    {
        /// <summary>
        /// Initializes a new instance of the CartItemRequestValidator with defined validation rules.
        /// </summary>
        /// <remarks>
        /// Validation rules include:
        /// - ProductId: Not Empty
        /// - Quantity: Value must be between 1 and 20
        /// </remarks>
        public CartItemRequestValidator()
        {
            RuleFor(x => x.ProductId)
                .NotEmpty();

            RuleFor(x => x.Quantity)
                .NotEmpty()
                .InclusiveBetween(1, 20);
        }
    }
}

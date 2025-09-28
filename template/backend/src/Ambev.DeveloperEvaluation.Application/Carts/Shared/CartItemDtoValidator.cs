using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Carts.Shared
{
    /// <summary>
    /// Validator CartItemDto.
    /// </summary>
    public class CartItemDtoValidator : AbstractValidator<CartItemDto>
    {
        /// <summary>
        /// Initializes a new instance of the CartItemDtoValidator with defined validation rules.
        /// </summary>
        /// <remarks>
        /// Validation rules include:
        /// - ProductId: Not Empty
        /// - Quantity: Value must be between 1 and 20
        /// </remarks>
        public CartItemDtoValidator()
        {
            RuleFor(x => x.ProductId)
                .NotEmpty();

            RuleFor(x => x.Quantity)
                .NotEmpty()
                .InclusiveBetween(1, 20);
        }
    }
}

using Ambev.DeveloperEvaluation.Domain.ValueObjects;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation
{
    /// <summary>
    /// Validator CartItem Value Object.
    /// </summary>
    public class CartItemValidator : AbstractValidator<CartItem>
    {
        /// <summary>
        /// Initializes a new instance of the CartItemValidator with defined validation rules.
        /// </summary>
        /// <remarks>
        /// Validation rules include:
        /// - ProductId: Not Empty
        /// - Quantity: Value must be between 1 and 20
        /// </remarks>
        public CartItemValidator()
        {
            RuleFor(x => x.ProductId)
                .NotEmpty();

            RuleFor(x => x.Quantity)
                .NotEmpty()
                .InclusiveBetween(1, 20);
        }
    }
}

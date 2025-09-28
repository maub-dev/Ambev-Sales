using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation
{
    /// <summary>
    /// Validator for Cart entity.
    /// </summary>
    public class CartValidator : AbstractValidator<Cart>
    {
        /// <summary>
        /// Initializes a new instance of the CartValidator with defined validation rules.
        /// </summary>
        /// <remarks>
        /// Validation rules include:
        /// - Date: Not empty
        /// - UserId: Not empty
        /// - Products: Not empty and for each item it uses CartItemValidator
        /// </remarks>
        public CartValidator()
        {
            RuleFor(x => x.Date)
                .NotEmpty();

            RuleFor(x => x.UserId)
                .NotEmpty();

            RuleFor(x => x.Products)
                .NotEmpty()
                .ForEach(x => x.SetValidator(new CartItemValidator()));
        }
    }
}

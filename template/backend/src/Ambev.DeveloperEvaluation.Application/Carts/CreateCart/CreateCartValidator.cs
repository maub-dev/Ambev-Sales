using Ambev.DeveloperEvaluation.Application.Carts.Shared;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Carts.CreateCart
{
    /// <summary>
    /// Validator CreateCartCommand.
    /// </summary>
    public class CreateCartValidator : AbstractValidator<CreateCartCommand>
    {
        /// <summary>
        /// Initializes a new instance of the CreateCartValidator with defined validation rules.
        /// </summary>
        /// <remarks>
        /// Validation rules include:
        /// - Date: Not empty
        /// - UserId: Not empty
        /// - Products: Not empty and for each item it uses CartItemValidator
        /// </remarks>
        public CreateCartValidator()
        {
            RuleFor(x => x.Date)
                .NotEmpty();

            RuleFor(x => x.UserId)
                .NotEmpty();

            RuleFor(x => x.Products)
                .NotEmpty()
                .ForEach(x => x.SetValidator(new CartItemDtoValidator()));
        }
    }
}


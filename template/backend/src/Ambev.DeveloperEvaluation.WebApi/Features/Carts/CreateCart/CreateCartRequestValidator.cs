using Ambev.DeveloperEvaluation.WebApi.Features.Carts.Shared;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.CreateCart
{
    public class CreateCartRequestValidator : AbstractValidator<CreateCartRequest>
    {
        /// <summary>
        /// Initializes a new instance of the CreateCartRequestValidator with defined validation rules.
        /// </summary>
        /// <remarks>
        /// Validation rules include:
        /// - Date: Not empty
        /// - UserId: Not empty
        /// - Products: Not empty and for each item it uses CartItemValidator
        /// </remarks>
        public CreateCartRequestValidator()
        {
            RuleFor(x => x.Date)
                .NotEmpty();

            RuleFor(x => x.UserId)
                .NotEmpty();

            RuleFor(x => x.Products)
                .NotEmpty()
                .ForEach(x => x.SetValidator(new CartItemRequestValidator()));
        }
    }
}

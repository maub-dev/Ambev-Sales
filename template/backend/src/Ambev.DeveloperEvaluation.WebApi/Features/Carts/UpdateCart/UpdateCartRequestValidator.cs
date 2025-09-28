using Ambev.DeveloperEvaluation.WebApi.Features.Carts.Shared;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.UpdateCart
{
    public class UpdateCartRequestValidator : AbstractValidator<UpdateCartRequest>
    {
        /// <summary>
        /// Initializes a new instance of the UpdateCartRequestValidator with defined validation rules.
        /// </summary>
        /// <remarks>
        /// Validation rules include:
        /// - Id: Not empty
        /// - Date: Not empty
        /// - UserId: Not empty
        /// - Products: Not empty and for each item it uses CartItemDtoValidator
        /// </remarks>
        public UpdateCartRequestValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();

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
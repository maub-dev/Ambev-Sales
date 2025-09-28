using Ambev.DeveloperEvaluation.Application.Carts.Shared;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Carts.UpdateCart
{
    /// <summary>
    /// Validator UpdateCartCommand.
    /// </summary>
    public class UpdateCartValidator : AbstractValidator<UpdateCartCommand>
    {
        /// <summary>
        /// Initializes a new instance of the UpdateCartValidator with defined validation rules.
        /// </summary>
        /// <remarks>
        /// Validation rules include:
        /// - Id: Not empty
        /// - Date: Not empty
        /// - UserId: Not empty
        /// - Products: Not empty and for each item it uses CartItemDtoValidator
        /// </remarks>
        public UpdateCartValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();

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

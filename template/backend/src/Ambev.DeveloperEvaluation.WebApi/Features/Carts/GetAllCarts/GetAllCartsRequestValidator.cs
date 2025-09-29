using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.GetAllCarts
{
    public class GetAllCartsRequestValidator : AbstractValidator<GetAllCartsRequest>
    {
        public GetAllCartsRequestValidator()
        {
            RuleFor(x => x.Page)
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(x => x.Size)
                .NotEmpty()
                .GreaterThan(0);
        }
    }
}

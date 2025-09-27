using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetAllProductsForCategory
{
    public class GetAllProductsForCategoryRequestValidator : AbstractValidator<GetAllProductsForCategoryRequest>
    {
        public GetAllProductsForCategoryRequestValidator()
        {
            RuleFor(x => x.Page)
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(x => x.Size)
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(x => x.Category)
                .NotEmpty()
                .MinimumLength(5);
        }
    }
}

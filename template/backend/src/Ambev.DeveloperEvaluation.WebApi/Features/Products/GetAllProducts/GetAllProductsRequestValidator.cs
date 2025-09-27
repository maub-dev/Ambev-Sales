using Ambev.DeveloperEvaluation.WebApi.Common;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetAllProducts
{
    public class GetAllProductsRequestValidator : AbstractValidator<GetAllProductsRequest>
    {
        public GetAllProductsRequestValidator()
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

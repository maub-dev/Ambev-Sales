using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetAllSales
{
    public class GetAllSalesRequestValidator : AbstractValidator<GetAllSalesRequest>
    {
        public GetAllSalesRequestValidator()
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

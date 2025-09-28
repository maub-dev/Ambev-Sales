using Ambev.DeveloperEvaluation.WebApi.Features.Sales.Shared;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale
{
    public class UpdateSaleRequestValidator : AbstractValidator<UpdateSaleRequest>
    {
        public UpdateSaleRequestValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();

            RuleFor(x => x.SaleNumber)
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(x => x.Date)
                .NotEmpty();

            RuleFor(x => x.Customer)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(100);

            RuleFor(x => x.Branch)
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(x => x.Products)
                .NotEmpty()
                .ForEach(x => x.SetValidator(new SaleItemRequestValidator()));
        }
    }
}

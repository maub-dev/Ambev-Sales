using Ambev.DeveloperEvaluation.Application.Sales.Shared;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    public class CreateSaleValidator : AbstractValidator<CreateSaleCommand>
    {
        public CreateSaleValidator()
        {
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
                .ForEach(x => x.SetValidator(new SaleItemDtoValidator()));
        }
    }
}

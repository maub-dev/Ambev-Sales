﻿using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.CancelSaleItem
{
    public class CancelSaleItemValidator : AbstractValidator<CancelSaleItemCommand>
    {
        public CancelSaleItemValidator()
        {
            RuleFor(x => x.SaleId)
                .NotEmpty()
                .WithMessage("Sale ID is required");

            RuleFor(x => x.SaleItemId)
                .NotEmpty()
                .WithMessage("Sale Item ID is required");
        }
    }
}

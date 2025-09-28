using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Validation
{
    /// <summary>
    /// Validator for Sale entity.
    /// </summary>
    public class SaleValidator : AbstractValidator<Sale>
    {
        /// <summary>
        /// Initializes a new instance of the SaleValidator with defined validation rules.
        /// </summary>
        /// <remarks>
        /// Validation rules include:
        /// - SaleNumber: Not empty, greater than 0
        /// - Date: Not empty
        /// - Customer: Not empty, min length 3 and max length 100
        /// - TotalValue: Not empty, greater than 0
        /// - Branch: Not empty, greater than 0
        /// - Products: Not empty and for each item it uses SaleItemValidator
        /// - Status: Cannot be Unknown
        /// </remarks>
        public SaleValidator()
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

            RuleFor(x => x.TotalValue)
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(x => x.Branch)
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(x => x.Products)
                .NotEmpty()
                .ForEach(x => x.SetValidator(new SaleItemValidator()));

            RuleFor(x => x.Status)
                .NotEqual(SaleStatus.Unknown).WithMessage($"Sale status cannot be {SaleStatus.Unknown}.");
        }
    }
}

using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .MinimumLength(5).WithMessage("Title must be at least 5 characters long.")
                .MaximumLength(100).WithMessage("Title cannot be longer than 100 characters."); ;

            RuleFor(x => x.Price)
                .NotEmpty();

            RuleFor(x => x.Description)
                .NotEmpty()
                .MinimumLength(10).WithMessage("Description must be at least 10 characters long.")
                .MaximumLength(500).WithMessage("Description cannot be longer than 500 characters."); ;

            RuleFor(x => x.Category)
                .NotEmpty()
                .MinimumLength(5).WithMessage("Category must be at least 5 characters long.")
                .MaximumLength(100).WithMessage("Category cannot be longer than 100 characters."); ;

            RuleFor(x => x.Image)
                .NotEmpty();

            RuleFor(x => x.Rating)
                .SetValidator(new RatingValidator());
        }
    }
}

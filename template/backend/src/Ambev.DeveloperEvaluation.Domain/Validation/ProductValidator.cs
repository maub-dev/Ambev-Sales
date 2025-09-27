using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation
{
    /// <summary>
    /// Validator Product entity.
    /// </summary>
    public class ProductValidator : AbstractValidator<Product>
    {
        /// <summary>
        /// Initializes a new instance of the ProductValidator with defined validation rules.
        /// </summary>
        /// <remarks>
        /// Validation rules include:
        /// - Title: Not empty, length between 5 and 100
        /// - Price: Not empty, greater than 0
        /// - Description: Not empty, length between 10 and 500 characters
        /// - Category: Not empty, length between 5 and 100 characters
        /// - Image: Not empty, maximum length 1000 characters
        /// - Rating: Uses RatingValidator
        /// </remarks>
        public ProductValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .MinimumLength(5).WithMessage("Title must be at least 5 characters long.")
                .MaximumLength(100).WithMessage("Title cannot be longer than 100 characters.");

            RuleFor(x => x.Price)
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(x => x.Description)
                .NotEmpty()
                .MinimumLength(10).WithMessage("Description must be at least 10 characters long.")
                .MaximumLength(500).WithMessage("Description cannot be longer than 500 characters.");

            RuleFor(x => x.Category)
                .NotEmpty()
                .MinimumLength(5).WithMessage("Category must be at least 5 characters long.")
                .MaximumLength(100).WithMessage("Category cannot be longer than 100 characters.");

            RuleFor(x => x.Image)
                .NotEmpty()
                .MaximumLength(1000).WithMessage("Category cannot be longer than 1000 characters.");

            RuleFor(x => x.Rating)
                .SetValidator(new RatingValidator());
        }
    }
}

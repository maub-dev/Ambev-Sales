using Ambev.DeveloperEvaluation.WebApi.Features.Products.Shared;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct
{
    /// <summary>
    /// Validator for CreateProductRequest that defines validation rules for product creation.
    /// </summary>
    public class CreateProductRequestValidator : AbstractValidator<CreateProductRequest>
    {
        /// <summary>
        /// Initializes a new instance of the CreateProductRequestValidator with defined validation rules.
        /// </summary>
        /// <remarks>
        /// Validation rules include:
        /// - Title: Not empty, length between 5 and 100
        /// - Price: Not empty
        /// - Description: Not empty, length between 10 and 500 characters
        /// - Category: Not empty, length between 5 and 100 characters
        /// - Image: Not empty, maximum length 1000 characters
        /// - Rating: Uses RatingRequestValidator
        /// </remarks>
        public CreateProductRequestValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .MinimumLength(5)
                .MaximumLength(100);

            RuleFor(x => x.Price)
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(x => x.Description)
                .NotEmpty()
                .MinimumLength(10)
                .MaximumLength(500);

            RuleFor(x => x.Category)
                .NotEmpty()
                .MinimumLength(5)
                .MaximumLength(100);

            RuleFor(x => x.Image)
                .NotEmpty()
                .MaximumLength(1000);

            RuleFor(x => x.Rating)
                .SetValidator(new RatingRequestValidator());
        }
    }
}

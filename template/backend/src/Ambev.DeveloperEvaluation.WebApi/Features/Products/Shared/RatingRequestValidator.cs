using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.Shared
{
    /// <summary>
    /// Validator for RatingRequest that defines validation rules for Product's Rating creation.
    /// </summary>
    public class RatingRequestValidator : AbstractValidator<RatingRequest>
    {
        /// <summary>
        /// Initializes a new instance of the RatingRequestValidator with defined validation rules.
        /// </summary>
        /// <remarks>
        /// Validation rules include:
        /// - Rate: Must be between 0.0 and 5.0
        /// - Count: Not null and greater or equal to zero
        /// </remarks>
        public RatingRequestValidator()
        {
            RuleFor(x => x.Rate)
                .InclusiveBetween(0.0, 5.0);

            RuleFor(x => x.Count)
                .NotNull()
                .GreaterThanOrEqualTo(0);
        }
    }
}

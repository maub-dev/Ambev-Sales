using Ambev.DeveloperEvaluation.Domain.ValueObjects;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation
{
    public class RatingValidator : AbstractValidator<Rating>
    {
        public RatingValidator()
        {
            RuleFor(x => x.Rate)
                .InclusiveBetween(0.0, 5.0).WithMessage("Rate must be between 0.0 and 5.0.");

            RuleFor(x => x.Count)
                .NotNull()
                .GreaterThanOrEqualTo(0).WithMessage("Count cannot be negative.");
        }
    }
}

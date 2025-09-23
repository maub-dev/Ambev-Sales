using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Products.Shared
{
    public class RatingDtoValidator : AbstractValidator<RatingDto>
    {
        public RatingDtoValidator()
        {
            RuleFor(x => x.Rate)
                .InclusiveBetween(0.0, 5.0);

            RuleFor(x => x.Count)
                .NotNull()
                .GreaterThanOrEqualTo(0);
        }
    }
}

using Ambev.DeveloperEvaluation.Domain.Validation;
using Ambev.DeveloperEvaluation.Domain.ValueObjects;
using FluentAssertions;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Validation
{
    /// <summary>
    /// Contains unit tests for the RatingValidator class.
    /// Tests cover validation of all Rating properties including rate and count
    /// </summary>
    public class RatingValidatorTests
    {
        [Theory(DisplayName = "Given a rate When validating Then should validate according to valid range")]
        [InlineData(null, true)]    // Valid - null
        [InlineData(-1.0, false)]   // Invalid - Negative number
        [InlineData(-0.1, false)]   // Invalid - Negative number
        [InlineData(0.0, true)]     // Valid - Zero and between valid range
        [InlineData(0.1, true)]     // Valid - Positive number and between valid range
        [InlineData(1.0, true)]     // Valid - Positive number and between valid range
        [InlineData(4.9, true)]     // Valid - Positive number and between valid range
        [InlineData(5.0, true)]     // Valid - Positive number and between valid range
        [InlineData(5.1, false)]    // Invalid - Positive number but outside valid range
        public void Given_Rate_When_Validating_Then_ShouldValidateAccordingToValidRange(double? rate, bool expectedResult)
        {
            // Arrange
            var validator = new RatingValidator();
            var rating = new Rating { Rate = rate };

            // Act
            var result = validator.Validate(rating);

            // Assert
            result.IsValid.Should().Be(expectedResult);
        }

        [Theory(DisplayName = "Given the count When validating Then should validate according to valid range")]
        [InlineData(-1, false)] // Invalid - Negative number
        [InlineData(0, true)]   // Valid - Zero
        [InlineData(1, true)]   // Valid - Greater than zero
        public void Given_Count_When_Validating_Then_ShouldValidateAccordingToValidRange(int count, bool expectedResult)
        {
            // Arrange
            var validator = new RatingValidator();
            var rating = new Rating { Count = count };

            // Act
            var result = validator.Validate(rating);

            // Assert
            result.IsValid.Should().Be(expectedResult);
        }
    }
}

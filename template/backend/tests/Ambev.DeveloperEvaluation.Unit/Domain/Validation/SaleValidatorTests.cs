using Ambev.DeveloperEvaluation.Domain.Validation;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using FluentAssertions;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Validation
{
    public class SaleValidatorTests
    {
        private readonly SaleValidator _validator = new();

        /// <summary>
        /// Tests that validation passes when all Sale properties are valid.
        /// This test verifies that a Sale item with valid:
        /// - ProductId: Not empty
        /// - Quantity: Not empty, between 1 and 20
        /// passes all validation rules without any errors.
        /// </summary>
        [Fact(DisplayName = "Given a valid Sale When validating Then should validate succesfuly")]
        public void Given_ValidSale_When_Validating_Then_ShouldValidateSuccesfully()
        {
            // Arrange
            var validator = new SaleValidator();
            var sale = SaleTestData.GenerateValidSale();

            // Act
            var result = validator.Validate(sale);

            // Assert
            result.IsValid.Should().Be(true);
            result.Errors.Should().BeEmpty();
        }
    }
}

using Ambev.DeveloperEvaluation.Domain.Validation;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using FluentAssertions;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Validation
{
    public class SaleItemValidatorTests
    {
        private readonly SaleItemValidator _validator = new();

        /// <summary>
        /// Tests that validation passes when all Sale item properties are valid.
        /// This test verifies that a Sale item with valid:
        /// - ProductId: Not empty
        /// - Quantity: Not empty, between 1 and 20
        /// passes all validation rules without any errors.
        /// </summary>
        [Fact(DisplayName = "Given a valid SaleItem When validating Then should validate succesfuly")]
        public void Given_ValidSaleItem_When_Validating_Then_ShouldValidateSuccesfully()
        {
            // Arrange
            var validator = new SaleItemValidator();
            var saleItem = SaleTestData.GenerateValidSaleItem();

            // Act
            var result = validator.Validate(saleItem);

            // Assert
            result.IsValid.Should().Be(true);
            result.Errors.Should().BeEmpty();
        }

        /// <summary>
        /// Tests that validation fails for empty product id.
        /// This test verifies product id that are:
        /// - Empty
        /// fail validation with appropriate error messages.
        /// The ProductId is a required field.
        /// </summary>
        [Fact(DisplayName = "Given an empty product id When validating Then should validate return validation errors")]
        public void Given_EmptyProductId_When_Validating_Then_ShouldReturnValidationErrors()
        {
            // Arrange
            var validator = new SaleItemValidator();
            var saleItem = SaleTestData.GenerateValidSaleItem();
            saleItem.ProductId = Guid.Empty;

            // Act
            var result = validator.Validate(saleItem);

            // Assert
            result.IsValid.Should().Be(false);
            result.Errors.Should().Contain(x => x.PropertyName == nameof(saleItem.ProductId));
        }
    }
}

using Ambev.DeveloperEvaluation.Domain.Validation;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using FluentAssertions;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Validation
{
    /// <summary>
    /// Contains unit tests for the CartItemValidator class.
    /// Tests cover validation of all CartItems properties including ProductId and Quantity
    /// </summary>
    public class CartItemValidatorTests
    {
        /// <summary>
        /// Tests that validation passes when all cart item properties are valid.
        /// This test verifies that a cart item with valid:
        /// - ProductId: Not empty
        /// - Quantity: Not empty, between 1 and 20
        /// passes all validation rules without any errors.
        /// </summary>
        [Fact(DisplayName = "Given a valid CartItem When validating Then should validate succesfuly")]
        public void Given_ValidCartItem_When_Validating_Then_ShouldValidateSuccesfully()
        {
            // Arrange
            var validator = new CartItemValidator();
            var cartItem = CartTestData.GenerateValidCartItem();

            // Act
            var result = validator.Validate(cartItem);

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
            var validator = new CartItemValidator();
            var cartItem = CartTestData.GenerateValidCartItem();
            cartItem.ProductId = Guid.Empty;

            // Act
            var result = validator.Validate(cartItem);

            // Assert
            result.IsValid.Should().Be(false);
            result.Errors.Should().Contain(x => x.PropertyName == nameof(cartItem.ProductId));
        }

        /// <summary>
        /// Tests that validation passes for valid quantities.
        /// </summary>
        /// <param name="quantity">The valid quantity to test.</param>
        [Theory(DisplayName = "Given a valid quantity When validating Then should validate according to valid range")]
        [InlineData(1)]
        [InlineData(10)]
        [InlineData(20)]
        public void Given_ValidQuantity_When_Validating_Then_ShouldValidateAccordingToValidRange(int quantity)
        {
            // Arrange
            var validator = new CartItemValidator();
            var cartItem = CartTestData.GenerateValidCartItem();
            cartItem.Quantity = quantity;

            // Act
            var result = validator.Validate(cartItem);

            // Assert
            result.IsValid.Should().Be(true);
            result.Errors.Should().BeEmpty();
        }

        /// <summary>
        /// Tests that validation fails for invalid quantity.
        /// This test verifies quantity that are outside of the valid range
        /// Fail validation with appropriate error messages.
        /// The quantity must be between 1 and 20.
        /// </summary>
        /// <param name="quantity">The invalid quantity to test.</param>
        [Theory(DisplayName = "Given an invalid quantity When validating Then should validate according to valid range")]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(21)]
        public void Given_InvalidQuantity_When_Validating_Then_ShouldValidateAccordingToValidRange(int quantity)
        {
            // Arrange
            var validator = new CartItemValidator();
            var cartItem = CartTestData.GenerateValidCartItem();
            cartItem.Quantity = quantity;

            // Act
            var result = validator.Validate(cartItem);

            // Assert
            result.IsValid.Should().Be(false);
            result.Errors.Should().Contain(x => x.PropertyName == nameof(cartItem.Quantity));
        }
    }
}

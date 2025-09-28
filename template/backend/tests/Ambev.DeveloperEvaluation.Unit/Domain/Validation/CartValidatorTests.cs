using Ambev.DeveloperEvaluation.Domain.Validation;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using FluentAssertions;
using FluentValidation.TestHelper;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Validation
{
    /// <summary>
    /// Contains unit tests for the CartValidator class.
    /// Tests cover validation of all product properties Date, UserId, Products.
    /// </summary>
    public class CartValidatorTests
    {
        private readonly CartValidator _validator;

        public CartValidatorTests()
        {
            _validator = new CartValidator();
        }

        /// <summary>
        /// Tests that validation passes when all cart properties are valid.
        /// This test verifies that a cart with valid:
        /// - Date: Not empty
        /// - UserId: Not empty
        /// - Products: Not empty and also uses CartItemValidator
        /// passes all validation rules without any errors.
        /// </summary>
        [Fact(DisplayName = "Valid cart should pass all validation rules")]
        public void Given_ValidCart_When_Validated_Then_ShouldNotHaveErrors()
        {
            // Arrange
            var cart = CartTestData.GenerateValidCart();

            // Act
            var result = _validator.TestValidate(cart);

            // Assert
            result.ShouldNotHaveAnyValidationErrors();
        }

        /// <summary>
        /// Tests that validation fails for invalid date.
        /// This test verifies that date that are:
        /// - Null
        /// - Empty
        /// fail validation with appropriate error messages.
        /// The date is a required field.
        /// </summary>
        /// <param name="date">The invalid date to test.</param>
        [Theory(DisplayName = "Invalid cart date should fail validation")]
        [InlineData(null)]
        [InlineData("01/01/0001")]
        public void Given_InvalidDate_When_Validated_Then_ShouldHaveError(DateTime date)
        {
            // Arrange
            var cart = CartTestData.GenerateValidCart();
            cart.Date = date;

            // Act
            var result = _validator.TestValidate(cart);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Date);
        }

        /// <summary>
        /// Tests that validation fails for empty user id.
        /// This test verifies user id that are:
        /// - Empty
        /// fail validation with appropriate error messages.
        /// The UserId is a required field.
        /// </summary>
        [Fact(DisplayName = "Given an empty user id When validating Then should validate return validation errors")]
        public void Given_EmptyUserId_When_Validating_Then_ShouldReturnValidationErrors()
        {
            // Arrange
            var validator = new CartValidator();
            var cart = CartTestData.GenerateValidCart();
            cart.UserId = Guid.Empty;

            // Act
            var result = validator.Validate(cart);

            // Assert
            result.IsValid.Should().Be(false);
            result.Errors.Should().Contain(x => x.PropertyName == nameof(cart.UserId));
        }

        /// <summary>
        /// Tests that validation fails for empty products list.
        /// This test verifies products list that are:
        /// - Empty
        /// fail validation with appropriate error messages.
        /// </summary>
        [Fact(DisplayName = "Cart with empty products list should fail validation")]
        public void Given_CartWithEmptyProducts_When_Validated_Then_ShouldHaveError()
        {
            // Arrange
            var cart = CartTestData.GenerateValidCart();
            cart.Products = [];

            // Act
            var result = _validator.TestValidate(cart);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Products);
        }

        /// <summary>
        /// Tests that validation fails for null products list.
        /// This test verifies  products list that are:
        /// - Null
        /// fail validation with appropriate error messages.
        /// </summary>
        [Fact(DisplayName = "Cart with null products list should fail validation")]
        public void Given_CartWithNullProducts_When_Validated_Then_ShouldHaveError()
        {
            // Arrange
            var cart = CartTestData.GenerateValidCart();
            cart.Products = null;

            // Act
            var result = _validator.TestValidate(cart);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Products);
        }
    }
}

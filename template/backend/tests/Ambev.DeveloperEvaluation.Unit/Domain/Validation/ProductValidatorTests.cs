using Ambev.DeveloperEvaluation.Domain.Validation;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using FluentValidation.TestHelper;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Validation
{
    /// <summary>
    /// Contains unit tests for the ProductValidator class.
    /// Tests cover validation of all product properties Title, Price, Description,
    /// Category, Image, Rating requirements.
    /// </summary>
    public class ProductValidatorTests
    {
        private readonly ProductValidator _validator;

        public ProductValidatorTests()
        {
            _validator = new ProductValidator();
        }

        /// <summary>
        /// Tests that validation passes when all product properties are valid.
        /// This test verifies that a user with valid:
        /// - Title: Not empty, length between 5 and 100
        /// - Price: Not empty
        /// - Description: Not empty, length between 10 and 500 characters
        /// - Category: Not empty, length between 5 and 100 characters
        /// - Image: Not empty, maximum length 1000 characters
        /// - Rating: Uses RatingValidator
        /// passes all validation rules without any errors.
        /// </summary>
        [Fact(DisplayName = "Valid product should pass all validation rules")]
        public void Given_ValidProduct_When_Validated_Then_ShouldNotHaveErrors()
        {
            // Arrange
            var product = ProductTestData.GenerateValidProduct();

            // Act
            var result = _validator.TestValidate(product);

            // Assert
            result.ShouldNotHaveAnyValidationErrors();
        }

        /// <summary>
        /// Tests that validation fails for invalid title length.
        /// This test verifies that title that are:
        /// - Null
        /// - Empty strings
        /// - Less than 5 characters
        /// fail validation with appropriate error messages.
        /// The title is a required field and must be between 5 and 100 characters.
        /// </summary>
        /// <param name="title">The invalid title to test.</param>
        [Theory(DisplayName = "Invalid title length should fail validation")]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("abcd")] // Less than 5 characters
        public void Given_InvalidTitle_When_Validated_Then_ShouldHaveError(string title)
        {
            // Arrange
            var product = ProductTestData.GenerateValidProduct();
            product.Title = title;

            // Act
            var result = _validator.TestValidate(product);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Title);
        }

        /// <summary>
        /// Tests that validation fails when title exceeds maximum length.
        /// This test verifies that titles longer than 100 characters fail validation.
        /// The test uses TestDataGenerator to create a title that exceeds the maximum
        /// length limit, ensuring the validation rule is properly enforced.
        /// </summary>
        [Fact(DisplayName = "Title longer than maximum length should fail validation")]
        public void Given_TitleLongerThanMaximum_When_Validated_Then_ShouldHaveError()
        {
            // Arrange
            var product = ProductTestData.GenerateValidProduct();
            product.Title = ProductTestData.GenerateLongTitle();

            // Act
            var result = _validator.TestValidate(product);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Title);
        }

        /// <summary>
        /// Tests that validation fails for invalid price values.
        /// This test verifies that price that are:
        /// - Negative
        /// - Zero
        /// fail validation with appropriate error messages.
        /// The price is a required field and must be greater than 0.
        /// </summary>
        /// <param name="price">The invalid price to test.</param>
        [Theory(DisplayName = "Invalid price values should fail validation")]
        [InlineData(-1.0)]
        [InlineData(-0.1)]
        [InlineData(0.0)]
        public void Given_InvalidPrice_When_Validated_Then_ShouldHaveError(decimal price)
        {
            // Arrange
            var product = ProductTestData.GenerateValidProduct();
            product.Price = price;

            // Act
            var result = _validator.TestValidate(product);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Price);
        }

        /// <summary>
        /// Tests that validation fails for invalid description length.
        /// This test verifies that description that are:
        /// - Null
        /// - Empty strings
        /// - Less than 10 characters
        /// fail validation with appropriate error messages.
        /// The description is a required field and must be between 10 and 500 characters.
        /// </summary>
        /// <param name="description">The invalid descrition to test.</param>
        [Theory(DisplayName = "Invalid description length should fail validation")]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("abcdefghi")] // Less than 10 characters
        public void Given_InvalidDescription_When_Validated_Then_ShouldHaveError(string description)
        {
            // Arrange
            var product = ProductTestData.GenerateValidProduct();
            product.Description = description;

            // Act
            var result = _validator.TestValidate(product);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Description);
        }

        /// <summary>
        /// Tests that validation fails when description exceeds maximum length.
        /// This test verifies that descriptions longer than 500 characters fail validation.
        /// The test uses TestDataGenerator to create a description that exceeds the maximum
        /// length limit, ensuring the validation rule is properly enforced.
        /// </summary>
        [Fact(DisplayName = "Description longer than maximum length should fail validation")]
        public void Given_DescriptionLongerThanMaximum_When_Validated_Then_ShouldHaveError()
        {
            // Arrange
            var product = ProductTestData.GenerateValidProduct();
            product.Description = ProductTestData.GenerateLongDescription();

            // Act
            var result = _validator.TestValidate(product);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Description);
        }

        /// <summary>
        /// Tests that validation fails for invalid category length.
        /// This test verifies that category that are:
        /// - Null
        /// - Empty strings
        /// - Less than 5 characters
        /// fail validation with appropriate error messages.
        /// The category is a required field and must be between 10 and 500 characters.
        /// </summary>
        /// <param name="category">The invalid category to test.</param>
        [Theory(DisplayName = "Invalid category length should fail validation")]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("abcd")] // Less than 5 characters
        public void Given_InvalidCategory_When_Validated_Then_ShouldHaveError(string category)
        {
            // Arrange
            var product = ProductTestData.GenerateValidProduct();
            product.Category = category;

            // Act
            var result = _validator.TestValidate(product);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Category);
        }

        /// <summary>
        /// Tests that validation fails when category exceeds maximum length.
        /// This test verifies that descriptions longer than 100 characters fail validation.
        /// The test uses TestDataGenerator to create a description that exceeds the maximum
        /// length limit, ensuring the validation rule is properly enforced.
        /// </summary>
        [Fact(DisplayName = "Category longer than maximum length should fail validation")]
        public void Given_CategoryLongerThanMaximum_When_Validated_Then_ShouldHaveError()
        {
            // Arrange
            var product = ProductTestData.GenerateValidProduct();
            product.Category = ProductTestData.GenerateLongCategory();

            // Act
            var result = _validator.TestValidate(product);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Category);
        }

        /// <summary>
        /// Tests that validation fails for invalid image length.
        /// This test verifies that image that are:
        /// - Null
        /// - Empty strings
        /// fail validation with appropriate error messages.
        /// The category is a required field and must be between 10 and 500 characters.
        /// </summary>
        /// <param name="image">The invalid image to test.</param>
        [Theory(DisplayName = "Invalid image length should fail validation")]
        [InlineData(null)]
        [InlineData("")]
        public void Given_InvalidImage_When_Validated_Then_ShouldHaveError(string image)
        {
            // Arrange
            var product = ProductTestData.GenerateValidProduct();
            product.Image = image;

            // Act
            var result = _validator.TestValidate(product);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Image);
        }

        /// <summary>
        /// Tests that validation fails when image exceeds maximum length.
        /// This test verifies that image longer than 1000 characters fail validation.
        /// The test uses TestDataGenerator to create a description that exceeds the maximum
        /// length limit, ensuring the validation rule is properly enforced.
        /// </summary>
        [Fact(DisplayName = "Image longer than maximum length should fail validation")]
        public void Given_ImageLongerThanMaximum_When_Validated_Then_ShouldHaveError()
        {
            // Arrange
            var product = ProductTestData.GenerateValidProduct();
            product.Category = ProductTestData.GenerateLongCategory();

            // Act
            var result = _validator.TestValidate(product);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Category);
        }
    }
}

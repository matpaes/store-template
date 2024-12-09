using Xunit;

public class CreateProductValidationTests
{
    private readonly CreateProductValidation _validation;

    public CreateProductValidationTests()
    {
        _validation = new CreateProductValidation();
    }

    [Fact]
    public void Validate_ShouldThrowException_WhenNameIsNullOrEmpty()
    {
        // Arrange
        var input = new CreateProductInput
        {
            Name = null,
            Description = "Valid Description",
            Price = 10.0m
        };

        // Act & Assert
        var exception = Assert.Throws<ArgumentException>(() => _validation.Validate(input));
        Assert.Equal("Product name is required.", exception.Message);
    }

    [Fact]
    public void Validate_ShouldThrowException_WhenDescriptionIsNullOrEmpty()
    {
        // Arrange
        var input = new CreateProductInput
        {
            Name = "Valid Name",
            Description = null,
            Price = 10.0m
        };

        // Act & Assert
        var exception = Assert.Throws<ArgumentException>(() => _validation.Validate(input));
        Assert.Equal("Product description is required.", exception.Message);
    }

    [Fact]
    public void Validate_ShouldThrowException_WhenPriceIsInvalid()
    {
        // Arrange
        var input = new CreateProductInput
        {
            Name = "Valid Name",
            Description = "Valid Description",
            Price = 0
        };

        // Act & Assert
        var exception = Assert.Throws<ArgumentException>(() => _validation.Validate(input));
        Assert.Equal("Product price must be greater than zero.", exception.Message);
    }

    [Fact]
    public void Validate_ShouldNotThrowException_WhenInputIsValid()
    {
        // Arrange
        var input = new CreateProductInput
        {
            Name = "Valid Name",
            Description = "Valid Description",
            Price = 10.0m
        };

        // Act & Assert
        _validation.Validate(input); // No exception expected
    }
}

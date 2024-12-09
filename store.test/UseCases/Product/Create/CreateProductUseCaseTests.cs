using Moq;
using Xunit;
using store.api.Entities;
using store.api.Gateways.Interfaces;
using store.api.UseCases; // Ajuste o namespace conforme necessário
using System;

public class CreateProductUseCaseTests
{
    private readonly Mock<IProductRepository> _productRepositoryMock;
    private readonly Mock<ICreateProductMapper> _mapperMock;
    private readonly Mock<ICreateProductValidation> _validationMock;
    private readonly CreateProductUseCase _useCase;

    public CreateProductUseCaseTests()
    {
        _productRepositoryMock = new Mock<IProductRepository>();
        _mapperMock = new Mock<ICreateProductMapper>();
        _validationMock = new Mock<ICreateProductValidation>();

        _useCase = new CreateProductUseCase(_productRepositoryMock.Object, _mapperMock.Object, _validationMock.Object);
    }

    [Fact]
    public async Task Execute_ShouldReturnCreateProductOutput_WhenProductIsValid()
    {
        var input = new CreateProductInput
        {
            Name = "Produto",
            Description = "Descrição do produto",
            Price = 10.0m,
            Stock = 100
        };

        var productEntity = new Product("Produto", "Descrição do produto", 10.0m, 100);
        _mapperMock.Setup(m => m.MapToEntity(It.IsAny<CreateProductInput>())).Returns(productEntity);

        var output = new CreateProductOutput
        {
            Id = productEntity.Id,
            Name = productEntity.Name,
            Description = productEntity.Description,
            Price = productEntity.Price,
            CreatedAt = productEntity.CreatedAt
        };
        _mapperMock.Setup(m => m.MapToOutput(It.IsAny<Product>())).Returns(output);

        _validationMock.Setup(v => v.Validate(It.IsAny<CreateProductInput>()));

        var result = await _useCase.Execute(input);

        Assert.NotNull(result);
        Assert.Equal(output.Id, result.Id);
        Assert.Equal(output.Name, result.Name);
        Assert.Equal(output.Description, result.Description);
        Assert.Equal(output.Price, result.Price);
        Assert.Equal(output.CreatedAt, result.CreatedAt);

        // Verifica se o método de validação foi chamado uma vez
        _validationMock.Verify(v => v.Validate(It.IsAny<CreateProductInput>()), Times.Once);

        // Verifica se o método de mapeamento foi chamado
        _mapperMock.Verify(m => m.MapToEntity(It.IsAny<CreateProductInput>()), Times.Once);
        _mapperMock.Verify(m => m.MapToOutput(It.IsAny<Product>()), Times.Once);
    }
}

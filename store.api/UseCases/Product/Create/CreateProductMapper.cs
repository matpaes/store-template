using store.api.Entities;

public interface ICreateProductMapper
{
    Product MapToEntity(CreateProductInput input);
    CreateProductOutput MapToOutput(Product product);
}

public class CreateProductMapper : ICreateProductMapper
{
    public Product MapToEntity(CreateProductInput input) => new(input.Name, input.Description, input.Price, input.Stock);

    public CreateProductOutput MapToOutput(Product product)
    {
        return new CreateProductOutput
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            CreatedAt = product.CreatedAt
        };
    }
}

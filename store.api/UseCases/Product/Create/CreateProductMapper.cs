using store.api.Entities;

public interface ICreateProductMapper
{
    Product MapToEntity(CreateProductInput input);
    CreateProductOutput MapToOutput(Product product);
}

public class CreateProductMapper : ICreateProductMapper
{
    public Product MapToEntity(CreateProductInput input)
    {
        // Mapeia os dados de entrada para a entidade Product
        return new Product
        {
            Name = input.Name,
            Description = input.Description,
            Price = input.Price,
            CreatedAt = DateTime.UtcNow // Definindo a data de criação como a data atual
        };
    }

    public CreateProductOutput MapToOutput(Product product)
    {
        // Mapeia a entidade Product para o formato de saída esperado
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

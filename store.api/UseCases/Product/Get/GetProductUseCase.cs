using store.api.Gateways.Interfaces;

namespace store.api.UseCases.Product.Get;
public interface IGetProductUseCase
{
    Task<GetProductOutput> ExecuteAsync(GetProductInput input);
}
public class GetProductUseCase : IGetProductUseCase
{
    private readonly IProductRepository _repository;

    public GetProductUseCase(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<GetProductOutput> ExecuteAsync(GetProductInput input)
    {
        var product = await _repository.GetByIdAsync(input.Id);

        if (product == null)
            return null;

        return new GetProductOutput
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            Stock = product.Stock
        };
    }
}

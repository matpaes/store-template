using store.api.Gateways.Interfaces;

namespace store.api.UseCases.Product.List;
public interface IListProductUseCase
{
    Task<IEnumerable<ListProductOutput>> ExecuteAsync();
}


public class ListProductUseCase : IListProductUseCase
{
    private readonly IProductRepository _repository;

    public ListProductUseCase(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<ListProductOutput>> ExecuteAsync()
    {
        var products = await _repository.GetAllAsync();
        return products.Select(product => new ListProductOutput
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price
        });
    }
}


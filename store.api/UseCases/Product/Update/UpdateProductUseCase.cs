using store.api.Gateways.Interfaces;

namespace store.api.UseCases.Product.Update;
public interface IUpdateProductUseCase
{
    Task<UpdateProductOutput> ExecuteAsync(UpdateProductInput input);
}
public class UpdateProductUseCase : IUpdateProductUseCase
{
    private readonly IProductRepository _repository;

    public UpdateProductUseCase(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<UpdateProductOutput> ExecuteAsync(UpdateProductInput input)
    {
        var product = await _repository.GetByIdAsync(input.Id);

        if (product == null)
            return new UpdateProductOutput { Success = false, Message = "Product not found" };

        product.UpdateName(input.Name);
        product.UpdatePrice(input.Price);
        product.UpdateDescription(input.Description);
        product.UpdateStock(input.Stock);

        await _repository.UpdateAsync(product);

        return new UpdateProductOutput { Success = true, Message = "Product updated successfully" };
    }
}

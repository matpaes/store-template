using store.api.Gateways.Interfaces;

namespace store.api.UseCases.Product.Delete
{
    public interface IDeleteProductUseCase
    {
        Task<DeleteProductOutput> ExecuteAsync(DeleteProductInput input);
    }

    public class DeleteProductUseCase : IDeleteProductUseCase
    {
        private readonly IProductRepository _repository;

        public DeleteProductUseCase(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<DeleteProductOutput> ExecuteAsync(DeleteProductInput input)
        {            
            await _repository.DeleteAsync(input.Id);

            return new DeleteProductOutput { Success = true, Message = "Product deleted successfully" };
        }
    }
}

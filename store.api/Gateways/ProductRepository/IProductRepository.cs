using store.api.Entities;

namespace store.api.Gateways.ProductRepository;

public interface IProductRepository
{
    Task<Product> AddAsync(Product product);
    Task<Product> UpdateAsync(Product product);
    Task<Product> GetByIdAsync(int id);
    Task<IEnumerable<Product>> GetAllAsync();
    Task DeleteAsync(int id);
}
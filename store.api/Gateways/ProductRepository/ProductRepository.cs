using Microsoft.EntityFrameworkCore;
using store.api.Entities;
using store.api.Gateways.Interfaces;

namespace store.api.Gateways.ProductRepository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Product> GetByIdAsync(int id) => await _context.Products.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id && (p.DeletedAt == null || p.DeletedAt == DateTime.MinValue));


        public async Task<IEnumerable<Product>> GetAllAsync() => await _context.Products.AsNoTracking().Where(p => p.DeletedAt == null || p.DeletedAt == DateTime.MinValue).ToListAsync();

        public async Task AddAsync(Product product)
        {
            if (product == null) throw new ArgumentNullException(nameof(product));

            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Product product)
        {
            if (product == null) throw new ArgumentNullException(nameof(product));

            var existingProduct = await _context.Products.FindAsync(product.Id);
            if (existingProduct == null)
            {
                throw new KeyNotFoundException($"Product with id {product.Id} not found.");
            }

            _context.Entry(existingProduct).CurrentValues.SetValues(product);
            await _context.SaveChangesAsync();
        }
    }
}

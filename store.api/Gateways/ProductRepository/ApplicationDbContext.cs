using System.Data.Entity;
using store.api.Entities;

namespace store.api.Gateways.ProductRepository
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(string connectionString) : base(connectionString)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}

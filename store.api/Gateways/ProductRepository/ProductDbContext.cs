using Microsoft.EntityFrameworkCore;
using store.api.Entities;
using System.Collections.Generic;
using System.Reflection.Emit;

public class ProductDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }

    public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options) { }

    // Configurações adicionais, como mappings de entidades, se necessário.
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // Configurações adicionais de mapeamento, se necessário
    }
}

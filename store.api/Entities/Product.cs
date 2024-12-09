namespace store.api.Entities;
public class Product
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public decimal Price { get; private set; }
    public int Stock { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }
    public DateTime DeletedAt { get; private set; }
    public Product()
    {
            
    }
    public Product(string name, string description, decimal price, int stock)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Product name cannot be empty", nameof(name));

        if (price <= 0)
            throw new ArgumentException("Price must be greater than zero", nameof(price));

        if (stock < 0)
            throw new ArgumentException("Stock cannot be negative", nameof(stock));

        Name = name;
        Description = description;
        Price = price;
        Stock = stock;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }

    public void UpdateName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Product name cannot be empty", nameof(name));

        Name = name;
        SetUpdatedAt();
    }

    public void Delete() => DeletedAt = DateTime.UtcNow;

    public void UpdateDescription(string description)
    {
        if (string.IsNullOrWhiteSpace(description))
            throw new ArgumentException("Description cannot be empty", nameof(description));

        Description = description;
        SetUpdatedAt();
    }

    public void UpdatePrice(decimal price)
    {
        if (price <= 0)
            throw new ArgumentException("Price must be greater than zero", nameof(price));

        Price = price;
        SetUpdatedAt();
    }

    public void UpdateStock(int stock)
    {
        if (stock < 0)
            throw new ArgumentException("Stock cannot be negative", nameof(stock));

        Stock = stock;
        SetUpdatedAt();
    }

    private void SetUpdatedAt()
    {
        UpdatedAt = DateTime.UtcNow;
    }
}




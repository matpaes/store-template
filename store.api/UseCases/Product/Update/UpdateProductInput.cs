﻿namespace store.api.UseCases.Product.Update;

public class UpdateProductInput
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public string Description { get; set; }
}

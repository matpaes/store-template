public interface ICreateProductValidation
{
    void Validate(CreateProductInput input);
}

public class CreateProductValidation : ICreateProductValidation
{
    public void Validate(CreateProductInput input)
    {
        if (string.IsNullOrEmpty(input.Name))
        {
            throw new ArgumentException("Product name is required.");
        }

        if (string.IsNullOrEmpty(input.Description))
        {
            throw new ArgumentException("Product description is required.");
        }

        if (input.Price <= 0)
        {
            throw new ArgumentException("Product price must be greater than zero.");
        }
    }
}

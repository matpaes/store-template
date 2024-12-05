using store.api.Gateways.Interfaces;

public class CreateProductUseCase
{
    private readonly IProductRepository _productRepository;
    private readonly ICreateProductMapper _mapper;
    private readonly ICreateProductValidation _validation;

    public CreateProductUseCase(IProductRepository productRepository,
                                ICreateProductMapper mapper,
                                ICreateProductValidation validation)
    {
        _productRepository = productRepository;
        _mapper = mapper;
        _validation = validation;
    }

    public async Task<CreateProductOutput> Execute(CreateProductInput input)
    {
        _validation.Validate(input);

        var productEntity = _mapper.MapToEntity(input);

        await _productRepository.AddAsync(productEntity);

        return _mapper.MapToOutput(productEntity);
    }
}

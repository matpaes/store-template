using store.api.Gateways.ProductRepository;
using store.api.Gateways.KeyVault;
using store.api.Gateways.Interfaces;
using store.api.UseCases.Product.Delete;
using store.api.UseCases.Product.Get;
using store.api.UseCases.Product.List;
using store.api.UseCases.Product.Update;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<ICreateProductMapper, CreateProductMapper>();
builder.Services.AddScoped<ICreateProductValidation, CreateProductValidation>();

builder.Services.AddScoped<ICreateProductUseCase, CreateProductUseCase>();
builder.Services.AddScoped<IUpdateProductUseCase, UpdateProductUseCase>();
builder.Services.AddScoped<IGetProductUseCase, GetProductUseCase>();
builder.Services.AddScoped<IListProductUseCase, ListProductUseCase>();
builder.Services.AddScoped<IDeleteProductUseCase, DeleteProductUseCase>();




await ConfigureDataBase(builder);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

static async Task ConfigureDataBase(WebApplicationBuilder builder)
{
    builder.Services.AddKeyVaultGateway(builder.Configuration);

    KeyVaultGateway keyVaultGateway = builder.Services.BuildServiceProvider().GetRequiredService<KeyVaultGateway>();

    var connectionString = await keyVaultGateway.GetSecretAsync("ConnectionStringSqlStore") ?? "";

    builder.Services.AddScoped(provider => new ApplicationDbContext(connectionString));

    builder.Services.AddScoped<IProductRepository, ProductRepository>();
}
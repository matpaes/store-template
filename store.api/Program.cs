using store.api.Gateways.ProductRepository;
using store.api.Gateways.KeyVault;
using store.api.Gateways.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
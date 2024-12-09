using store.api.Gateways.ProductRepository;
using store.api.Gateways.KeyVault;
using store.api.Gateways.Interfaces;
using store.api.UseCases.Product.Delete;
using store.api.UseCases.Product.Get;
using store.api.UseCases.Product.List;
using store.api.UseCases.Product.Update;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = true,
            ValidateLifetime = false,
            ValidateIssuerSigningKey = false,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SecretKey"]))
        };
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequireAdminRole", policy =>
    {
        policy.RequireRole("Admin");
    });
});


await ConfigureDataBase(builder);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

static async Task ConfigureDataBase(WebApplicationBuilder builder)
{
    builder.Services.AddKeyVaultGateway(builder.Configuration);

    KeyVaultGateway keyVaultGateway = builder.Services.BuildServiceProvider().GetRequiredService<KeyVaultGateway>();

    var connectionString = await keyVaultGateway.GetSecretAsync("ConnectionStringSqlStore") ?? "";

    builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

    builder.Services.AddScoped<IProductRepository, ProductRepository>();

}
namespace store.api.Gateways.KeyVault;
public static class KeyVaultServiceConfiguration
{
    public static IServiceCollection AddKeyVaultGateway(this IServiceCollection services, IConfiguration configuration)
    {
        var keyVaultUrl = configuration["KeyVaultUrl"];

        if (string.IsNullOrEmpty(keyVaultUrl))
            throw new Exception("A URL do KeyVault não foi configurada.");

        services.AddSingleton(new KeyVaultGateway(keyVaultUrl));

        return services;
    }
}


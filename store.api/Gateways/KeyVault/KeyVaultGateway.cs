using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Azure.Core.Diagnostics;

namespace store.api.Gateways.KeyVault;

public class KeyVaultGateway
{
    private readonly SecretClient _secretClient;

    public KeyVaultGateway(string keyVaultUrl)
    {
        _secretClient = new SecretClient(new Uri(keyVaultUrl), new DefaultAzureCredential());
    }

    public async Task<string> GetSecretAsync(string secretName)
    {
        try
        {         
            using var listener = AzureEventSourceListener.CreateConsoleLogger();
            var secret = await _secretClient.GetSecretAsync(secretName);
            return secret.Value.Value;
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao buscar o segredo '{secretName}' do Key Vault: {ex.Message}");
        }
    }
}

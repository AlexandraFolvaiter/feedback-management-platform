using Azure.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Graph;

namespace FeedbackManagementPlatform.DataAccess.Contexts;

public class GraphApiConnection
{
    public IConfiguration _configuration;

    public GraphApiConnection(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public GraphServiceClient CreateGraphServiceClient()
    {
        var scopes = new[] { _configuration["AzureAd:GraphApiScope"] };
        var tenantId = _configuration["AzureAd:TenantId"];

        var clientId = _configuration["AzureAd:ClientId"];

        var clientSecret = _configuration["AzureAd:ClientSecret"];

        var options = new TokenCredentialOptions
        {
            AuthorityHost = AzureAuthorityHosts.AzurePublicCloud
        };

        var clientSecretCredential = new ClientSecretCredential(
            tenantId, clientId, clientSecret, options);

        var graphClient = new GraphServiceClient(clientSecretCredential, scopes);

        return graphClient;
    }
}
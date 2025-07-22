using Microsoft.Extensions.Logging;
using RestSharp.Interceptors;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using TipsTrade.ApiClient.Core.Credential;
using TipsTrade.ApiClient.Core.Tenant;

namespace TipsTrade.VCheck {
  internal class ApiKeyInterceptor : Interceptor {
    private readonly ICredentialProvider credentialProvider;
    private readonly ILogger? logger;
    private readonly ITenantProvider? tenantProvider;

    public ApiKeyInterceptor(ICredentialProvider credentialProvider,
      ILogger? logger = null,
      ITenantProvider? tenantProvider = null
      ) {
      this.credentialProvider = credentialProvider;
      this.logger = logger;
      this.tenantProvider = tenantProvider;
    }

    private async Task<string> GetTenantIdAsync() {
      try {
        return await tenantProvider.GetTenantOrDefaultAsync();
      } catch (Exception ex) {
        logger?.LogError("Failed to retrieve tenant: {message}", ex.Message);
        throw new InvalidOperationException("An error occurred retrieving the tenant.", ex);
      }
    }

    private async Task<string?> GetApiKeyAsync() {
      var tenantId = await GetTenantIdAsync();

      try {
        return (await credentialProvider.GetCredentialAsync(tenantId)).ApiKey;
      } catch (Exception ex) {
        logger?.LogError("Failed to retrieve credential for Tenant={tenantId}: {message}", tenantId, ex.Message);
        throw new InvalidOperationException("An error occurred retrieving the credential.", ex);
      }
    }

    public override async ValueTask BeforeHttpRequest(HttpRequestMessage requestMessage, CancellationToken cancellationToken) {
      var apiKey = await GetApiKeyAsync();

      if (apiKey != null) {
        requestMessage.Headers.Add("Authorization", $"Token {apiKey}");
      }

      await base.BeforeHttpRequest(requestMessage, cancellationToken);
    }
  }
}

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

    private async Task<string?> GetTenantIdAsync() {
      try {
        return await tenantProvider.GetTenantOrDefault();
      } catch (Exception ex) {
        logger?.LogError("Failed to get Tenant ID: {message}", ex.Message);
      }

      return null;
    }

    private async Task<string?> GetApiKeyAsync() {
      var tenantId = await GetTenantIdAsync();

      if (tenantId == null) {
        return null;
      }

      var resp = await credentialProvider.TryGetCredentialAsync(tenantId);

      if (!resp.IsSuccess) {
        logger?.LogError("Failed to get credentials for Tenant {tenantId}: {message}", tenantId, resp.Message ?? resp.Exception?.Message);
      }

      return resp.Value?.ApiKey;
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

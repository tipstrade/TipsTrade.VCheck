using Microsoft.Extensions.Logging;
using RestSharp.Interceptors;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace TipsTrade.VCheck {
  internal class ApiKeyInterceptor : Interceptor {
    private readonly ICredentialsProvider credentialsProvider;
    private readonly ILogger? logger;
    private readonly ITennantProvider? tennantProvider;

    public ApiKeyInterceptor(ICredentialsProvider credentialsProvider,
      ILogger? logger = null,
      ITennantProvider? tennantProvider = null
      ) {
      this.credentialsProvider = credentialsProvider;
      this.logger = logger;
      this.tennantProvider = tennantProvider;
    }

    private async Task<string?> GetTennantIdAsync() {
      try {
        return await tennantProvider.GetTennantIdOrDefault();
      } catch (Exception ex) {
        logger?.LogError("Failed to get Tennant ID: {message}", ex.Message);
      }

      return null;
    }

    private async Task<string?> GetApiKeyAsync() {
      var tennantId = await GetTennantIdAsync();

      if (tennantId == null) {
        return null;
      }

      try {
        return await credentialsProvider.GetApiKeyAsync(tennantId);
      } catch (Exception ex) {
        logger?.LogError("Failed to get credentials for Tennant {tennant}: {message}", tennantId, ex.Message);
      }

      return null;
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

using Microsoft.Extensions.Logging;
using RestSharp.Interceptors;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using TipsTrade.ApiClient.Core.Credential;
using TipsTrade.ApiClient.Core.Logging;
using TipsTrade.ApiClient.Core.Tenant;

namespace TipsTrade.VCheck {
  internal class ApiKeyInterceptor : Interceptor, IWithLogger {
    #region DI
    private ICredentialProvider CredentialProvider { get; }
    public ILogger? Logger { get; }
    private ITenantProvider? TenantProvider { get; }
    #endregion

    public ApiKeyInterceptor(ICredentialProvider credentialProvider,
      ILogger? logger = null,
      ITenantProvider? tenantProvider = null
      ) {
      CredentialProvider = credentialProvider;
      Logger = logger;
      TenantProvider = tenantProvider;
    }

    public override async ValueTask BeforeHttpRequest(HttpRequestMessage requestMessage, CancellationToken cancellationToken) {
      var tenantId = await TenantProvider.GetTenantOrThrowAsync(cancellationToken);
      var apiKey = await CredentialProvider.GetCredentialOrThrowAsync(tenantId, cancellationToken);

      if (apiKey != null) {
        requestMessage.Headers.Add("Authorization", $"Token {apiKey.ApiKey}");
      }

      await base.BeforeHttpRequest(requestMessage, cancellationToken);
    }
  }
}

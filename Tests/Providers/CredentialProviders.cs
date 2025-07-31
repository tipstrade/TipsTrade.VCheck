using Microsoft.Extensions.Configuration;
using System;
using System.Threading;
using System.Threading.Tasks;
using TipsTrade.ApiClient.Core.Credential;
using TipsTrade.VCheck;

namespace Tests.Providers {
  public class CredentialProvider : ICredentialProvider {
    private IConfiguration Configuration { get; set; }

    public CredentialProvider(IConfiguration configuration) {
      Configuration = configuration;
    }

    public Task<ApiKeyCredential> GetCredentialAsync(string key, CancellationToken ct) {
      string? apiKey = null;

      if (key == "(default)") {
        apiKey = Configuration.GetValue<string>("ApiKey") ?? throw new InvalidOperationException("ApiKey is unavailable.");
      } else if (key == "invalid") {
        apiKey = "000000";
      }

      if (apiKey == null) {
        throw new InvalidOperationException("No ApiKey is available");
      }

      return Task.FromResult(new ApiKeyCredential(apiKey));
    }
  }

  public class DummyCredentialsProvider : ICredentialProvider {
    public Task<ApiKeyCredential> GetCredentialAsync(string key, CancellationToken ct) {
      var resp = new ApiKeyCredential("abcdef");

      return Task.FromResult(resp);
    }
  }
}

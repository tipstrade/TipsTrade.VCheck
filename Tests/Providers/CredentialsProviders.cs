using Microsoft.Extensions.Configuration;
using NUnit.Framework.Constraints;
using System;
using System.Threading;
using System.Threading.Tasks;
using TipsTrade.ApiClient.Core.Credential;
using TipsTrade.VCheck;

namespace Tests.Providers {
  public class CredentialsProvider : ICredentialProvider {
    private readonly IConfiguration configuration;

    public CredentialsProvider(IConfiguration configuration) {
      this.configuration = configuration;
    }

    public Task<CredentialResponse<ApiKeyCredential>> GetCredentialAsync(string key, CancellationToken ct) {
      var resp = new ApiKeyCredential(configuration.GetValue<string>("ApiKey") ?? throw new InvalidOperationException("ApiKey is invalid."));

      return Task.FromResult<CredentialResponse<ApiKeyCredential>>(resp);
    }
  }

  public class DummyCredentialsProvider : ICredentialProvider {
    public Task<CredentialResponse<ApiKeyCredential>> GetCredentialAsync(string key, CancellationToken ct) {
      var resp = new ApiKeyCredential("abcdef");

      return Task.FromResult<CredentialResponse<ApiKeyCredential>>(resp);
    }
  }
}

using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using TipsTrade.VCheck;

namespace Tests.Providers {
  public class CredentialsProvider : ICredentialsProvider {
    private readonly IConfiguration configuration;

    public CredentialsProvider(IConfiguration configuration) {
      this.configuration = configuration;
    }
    public Task<string> GetApiKeyAsync(string tennantId) {
      return Task.FromResult(configuration.GetValue<string>("ApiKey"));
    }
  }

  public class DummyCredentialsProvider : ICredentialsProvider {
    public Task<string> GetApiKeyAsync(string tennantId) {
      return Task.FromResult("");
    }
  }
}

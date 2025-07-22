using System.Threading;
using System.Threading.Tasks;
using TipsTrade.VCheck;

namespace Tests.Providers {
  internal class TenantProvider : ITenantProvider {
    public Task<string> GetTenantAsync(CancellationToken cancellationToken = default) {
      return Task.FromResult("my-tenant");
    }
  }
}

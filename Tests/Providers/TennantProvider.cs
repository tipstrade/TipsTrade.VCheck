using System.Threading.Tasks;
using TipsTrade.VCheck;

namespace Tests.Providers {
  internal class TennantProvider : ITennantProvider {
    public Task<string> GetTennantIdAsync() {
      return Task.FromResult("my-tennant");
    }
  }
}

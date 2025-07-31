using TipsTrade.ApiClient.Core.Caching;

namespace TipsTrade.VCheck {
  /// <summary>Provides methods for caching lookups.</summary>
  public interface ICacheProvider : IReadWriteCache<(string TenantId, string Key)> {
  }
}

using System.Threading.Tasks;

namespace TipsTrade.VCheck {
  /// <summary>Provides methods for getting the tennant ID.</summary>
  public interface ITennantProvider {
    /// <summary>Gets the tennant ID.</summary>
    Task<string> GetTennantIdAsync();
  }

  internal static class TennantProviderExtensions {
    internal static async Task<string> GetTennantIdOrDefault(this ITennantProvider? tennant) {
      return tennant == null ? "(default)" : await tennant.GetTennantIdAsync();
    }
  }
}

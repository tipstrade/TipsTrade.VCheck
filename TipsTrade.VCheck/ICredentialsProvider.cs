using System.Threading.Tasks;

namespace TipsTrade.VCheck {
  /// <summary>Provides methods for fetching credentials for the <see cref="VCheckClient"/>.</summary>
  public interface ICredentialsProvider {
    /// <summary>Gets the ApiKey.</summary>
    Task<string?> GetApiKeyAsync(string tennantId);
  }
}

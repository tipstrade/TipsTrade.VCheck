using TipsTrade.ApiClient.Core.Credential;

namespace TipsTrade.VCheck {
  /// <summary>Provides methods for fetching credentials for the <see cref="VCheckClient"/>.</summary>
  public interface ICredentialProvider : IGetCredential<string, ApiKeyCredential> { }  
}

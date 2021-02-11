using Newtonsoft.Json;

namespace TipsTrade.VCheck.Model {
  /// <summary>An error response returned by the VCheck API.</summary>
  public  class ErrorResponse {
    /// <summary>The error detail.</summary>
    [JsonProperty("detail")]
    public string Detail { get; set; }
  }
}

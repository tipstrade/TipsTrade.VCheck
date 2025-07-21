using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace TipsTrade.VCheck {
  /// <summary>An error response returned by the VCheck API.</summary>
  public  class ErrorResponse {
    /// <summary>The error detail.</summary>
    [JsonProperty("detail"), JsonPropertyName("detail")]
    public string? Detail { get; set; }
  }
}

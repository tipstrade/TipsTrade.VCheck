using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace TipsTrade.VCheck.Model.Reports {
  /// <summary>The vehicle exise duty (VED) rate</summary>
  public class VedRate {
    /// <summary>The first year VED rate.</summary>
    [JsonProperty("first_year"), JsonPropertyName("first_year")]
    public VedRateValue FirstYear { get; set; }

    /// <summary>The premium VED rate.</summary>
    [JsonProperty("premium"), JsonPropertyName("premium")]
    public VedRateValue Premium { get; set; }

    /// <summary>The standard VED rate.</summary>
    [JsonProperty("standard"), JsonPropertyName("standard")]
    public VedRateValue Standard { get; set; }
  }
}

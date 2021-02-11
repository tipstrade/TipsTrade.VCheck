using Newtonsoft.Json;

namespace TipsTrade.VCheck.Model.Reports {
  /// <summary>The vehicle exise duty (VED) rate</summary>
  public class VedRate {
    /// <summary>The first year VED rate.</summary>
    [JsonProperty("first_year")]
    public VedRateValue FirstYear { get; set; }

    /// <summary>The premium VED rate.</summary>
    [JsonProperty("premium")]
    public VedRateValue Premium { get; set; }

    /// <summary>The standard VED rate.</summary>
    [JsonProperty("standard")]
    public VedRateValue Standard { get; set; }
  }
}

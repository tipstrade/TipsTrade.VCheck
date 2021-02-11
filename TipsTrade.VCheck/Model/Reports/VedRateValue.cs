using Newtonsoft.Json;

namespace TipsTrade.VCheck.Model.Reports {
  /// <summary>The vehicle exise duty (VED) rate breakdown.</summary>
  public class VedRateValue {
    /// <summary>The annual VED rate</summary>
    [JsonProperty("12")]
    public float? Annual { get; set; }

    /// <summary>The 6-month VED rate</summary>
    [JsonProperty("6")]
    public float? SixMonth { get; set; }
  }
}

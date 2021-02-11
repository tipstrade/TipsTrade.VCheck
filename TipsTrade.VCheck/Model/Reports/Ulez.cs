using Newtonsoft.Json;

namespace TipsTrade.VCheck.Model.Reports {
  /// <summary>The ultra-low emission zone charges.</summary>
  public class Ulez {
    /// <summary>The ULEZ cost.</summary>
    [JsonProperty("cost")]
    public float? Cost { get; set; }

    /// <summary>A flag indicating whether ULEZ charges are payable.</summary>
    [JsonProperty("is_payable")]
    public bool IsPayable { get; set; }

    /// <summary>The ULEZ rate.</summary>
    [JsonProperty("rate")]
    public string Rate { get; set; }
  }
}

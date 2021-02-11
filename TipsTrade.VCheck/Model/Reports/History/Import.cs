using Newtonsoft.Json;

namespace TipsTrade.VCheck.Model.Reports {
  /// <summary>A vehicle import status.</summary>
  public class Import {
    /// <summary>A flag indicating whether the vehicle has been imported.</summary>
    [JsonProperty("is_imported")]
    public bool IsImported { get; set; }

    /// <summary>A flag indicating whether the vehicle has been imported from outside of the EU.</summary>
    [JsonProperty("is_non_eu")]
    public bool IsNonEu { get; set; }
  }
}

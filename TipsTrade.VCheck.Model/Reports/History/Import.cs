using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace TipsTrade.VCheck.Model.Reports {
  /// <summary>A vehicle import status.</summary>
  public class Import {
    /// <summary>A flag indicating whether the vehicle has been imported.</summary>
    [JsonProperty("is_imported"), JsonPropertyName("is_imported")]
    public bool IsImported { get; set; }

    /// <summary>A flag indicating whether the vehicle has been imported from outside of the EU.</summary>
    [JsonProperty("is_non_eu"), JsonPropertyName("is_non_eu")]
    public bool IsNonEu { get; set; }

    /// <summary>Returns a string that represents the current object.</summary>
    public override string ToString() {
      if (IsNonEu) {
        return "Imported from outside EU";
      } else if (IsImported) {
        return "Imported";
      } else {
        return "Not imported";
      }
    }
  }
}

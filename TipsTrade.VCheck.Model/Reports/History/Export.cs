using Newtonsoft.Json;
using System;
using System.Text.Json.Serialization;

namespace TipsTrade.VCheck.Model.Reports.History {
  /// <summary>A vehicle export status.</summary>
  public class Export {
    /// <summary>The date on which the vehicle was exported.</summary>
    [JsonProperty("date_exported"), JsonPropertyName("date_exported")]
    public DateTime? DateExported { get; set; }

    /// <summary>A flag indicating whether the vehicle has been exported.</summary>
    [JsonProperty("is_exported"), JsonPropertyName("is_exported")]
    public bool IsExported { get; set; }

    /// <summary>Returns a string that represents the current object.</summary>
    public override string ToString() {
      if (IsExported && DateExported != null) {
        return $"Exported on ${DateExported:d}";
      } else if (IsExported) {
        return "Exported";
      } else {
        return "Not exported";
      }
    }
  }
}

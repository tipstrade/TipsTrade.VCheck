using Newtonsoft.Json;
using System;

namespace TipsTrade.VCheck.Model.Reports {
  /// <summary>A vehicle export status.</summary>
  public class Export {
    /// <summary>The date on which the vehicle was exported.</summary>
    [JsonProperty("date_exported")]
    public DateTime? DateExported { get; set; }

    /// <summary>A flag indicating whether the vehicle has been exported.</summary>
    [JsonProperty("is_exported")]
    public bool IsExported { get; set; }
  }
}

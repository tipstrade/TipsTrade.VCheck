using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace TipsTrade.VCheck.Model.Reports {
  /// <summary>An MOT report.</summary>
  public class Mot {
    /// <summary>The number of days left on the current MOT certificate.</summary>
    [JsonProperty("days_left")]
    public int? DaysLeft { get; set; }

    /// <summary>The date on which current MOT certificate expires.</summary>
    [JsonProperty("expiry")]
    public DateTime? Expiry { get; set; }

    /// <summary>A flag indicating whether the current MOT certificate is valid.</summary>
    [JsonProperty("is_valid")]
    public bool? IsValid { get; set; }

    /// <summary>The list of MOT tests.</summary>
    [JsonProperty("tests")]
    public IEnumerable<MotTest> Tests { get; set; }
  }
}

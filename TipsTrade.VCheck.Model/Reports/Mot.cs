using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TipsTrade.VCheck.Model.Reports {
  /// <summary>An MOT report.</summary>
  public class Mot {
    /// <summary>The number of days left on the current MOT certificate.</summary>
    [JsonProperty("days_left"), JsonPropertyName("days_left")]
    public int? DaysLeft { get; set; }

    /// <summary>The date on which current MOT certificate expires.</summary>
    [JsonProperty("expiry"), JsonPropertyName("expiry")]
    public DateTime? Expiry { get; set; }

    /// <summary>A flag indicating whether the current MOT certificate is valid.</summary>
    [JsonProperty("is_valid"), JsonPropertyName("is_valid")]
    public bool? IsValid { get; set; }

    /// <summary>The list of MOT tests.</summary>
    [JsonProperty("tests"), JsonPropertyName("tests")]
    public IEnumerable<MotTest> Tests { get; set; }
  }
}

using Newtonsoft.Json;
using System;

namespace TipsTrade.VCheck.Model.Reports.History {
  /// <summary>A vehicle mileage record.</summary>
  public class MileageRecord {
    /// <summary>The date of when the mileage was recorded.</summary>
    [JsonProperty("date")]
    public DateTime? Date { get; set; }

    /// <summary>A flag indicating whether the mileage record has an issue.</summary>
    [JsonProperty("has_issue")]
    public bool HasIssue { get; set; }

    /// <summary>The mileage reading.</summary>
    [JsonProperty("mileage")]
    public int Mileage { get; set; }

    /// <summary>The source of the mileage reading.</summary>
    [JsonProperty("source")]
    public string Source { get; set; }

    /// <summary>Returns a string that represents the current object.</summary>
    public override string ToString() {
      return $"{Mileage:N0} on {Date?.ToString("d") ?? "unknown"} from {Source}";
    }
  }
}

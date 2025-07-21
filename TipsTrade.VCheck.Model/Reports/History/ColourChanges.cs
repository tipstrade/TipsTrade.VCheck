using Newtonsoft.Json;
using System;
using System.Text.Json.Serialization;

namespace TipsTrade.VCheck.Model.Reports.History {
  /// <summary>A exterior colour change.</summary>
  public class ColourChanges {
    /// <summary>The number of colour changes.</summary>
    [JsonProperty("count"), JsonPropertyName("count")]
    public int Count { get; set; }

    /// <summary>The date of the latest colour change.</summary>
    [JsonProperty("latest_change_date"), JsonPropertyName("latest_change_date")]
    public DateTime? LatestChangeDate { get; set; }

    /// <summary>The previous colour.</summary>
    [JsonProperty("previous_colour"), JsonPropertyName("previous_colour")]
    public string? PreviousColour { get; set; }

    /// <summary>Returns a string tha represents the current obbject.</summary>
    public override string ToString() {
      if (PreviousColour != null && LatestChangeDate != null) {
        return $"{PreviousColour} on {LatestChangeDate:d}";
      } else if (PreviousColour != null) {
        return PreviousColour;
      } else if (LatestChangeDate != null) {
        return $"on {LatestChangeDate:d}";
      } else {
        return "Never";
      }
    }
  }
}

using Newtonsoft.Json;
using System;

namespace TipsTrade.VCheck.Model.Reports.History {
  /// <summary>A exterior colour change.</summary>
  public class ColourChanges {
    /// <summary>The number of colour changes.</summary>
    [JsonProperty("count")]
    public int Count { get; set; }

    /// <summary>The date of the latest colour change.</summary>
    [JsonProperty("latest_change_date")]
    public DateTime? LatestChangeDate { get; set; }

    /// <summary>The previous colour.</summary>
    [JsonProperty("previous_colour")]
    public string PreviousColour { get; set; }

    /// <summary>Returns a string tha represents the current obbject.</summary>
    public override string ToString() {
      if (PreviousColour == null && LatestChangeDate == null) {
        return "Never";
      } else {
        return $"{PreviousColour} on {LatestChangeDate.Value.ToString("d") ?? "unkown"}";
      }
    }
  }
}

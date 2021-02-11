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
  }
}

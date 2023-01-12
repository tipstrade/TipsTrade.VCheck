using Newtonsoft.Json;
using System;
using System.Text.Json.Serialization;

namespace TipsTrade.VCheck.Model.Reports {
  /// <summary>A vehicle scrappage status.</summary>
  public class Scrapped {
    /// <summary>The date on which the vehicle was scrapped.</summary>
    [JsonProperty("date_scrapped"), JsonPropertyName("date_scrapped")]
    public DateTime? DateScrapped { get; set; }

    /// <summary>A flag indicating whether the vehicle has been scrapped.</summary>
    [JsonProperty("is_scrapped"), JsonPropertyName("is_scrapped")]
    public bool? IsScrapped { get; set; }

    /// <summary>Returns a string that represents the current object.</summary>
    public override string ToString() {
      if (IsScrapped == true) {
        return $"Scrapped on {DateScrapped?.ToString("d") ?? "unknown"}";
      } else {
        return "Not scrapped";
      }
    }
  }
}

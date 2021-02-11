using Newtonsoft.Json;
using System;

namespace TipsTrade.VCheck.Model.Reports {
  /// <summary>A vehicle scrappage status.</summary>
  public class Scrapped {
    /// <summary>The date on which the vehicle was scrapped.</summary>
    [JsonProperty("date_scrapped")]
    public DateTime? DateScrapped { get; set; }

    /// <summary>A flag indicating whether the vehicle has been scrapped.</summary>
    [JsonProperty("is_scrapped")]
    public bool? IsScrapped { get; set; }
  }
}

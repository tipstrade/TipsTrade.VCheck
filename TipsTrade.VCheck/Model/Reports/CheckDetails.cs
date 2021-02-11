using Newtonsoft.Json;
using System;

namespace TipsTrade.VCheck.Model.Reports {
  /// <summary>The details of the vehicle check.</summary>
  public class CheckDetails {
    /// <summary>The date on which the check was made.</summary>
    [JsonProperty("check_date")]
    public DateTime? CheckDate { get; set; }

    /// <summary>The unique reference of the check, </summary>
    [JsonProperty("check_reference")]
    public string CheckReference { get; set; }

    /// <summary>The type of check made.</summary>
    [JsonProperty("check_type")]
    public string CheckType { get; set; }

    /// <summary>The URL at which the report can be viewed.</summary>
    [JsonProperty("url")]
    public string Url { get; set; }

    /// <summary>The ID of the user that made the check.</summary>
    [JsonProperty("user")]
    public int User { get; set; }
  }
}

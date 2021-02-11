using Newtonsoft.Json;
using System;

namespace TipsTrade.VCheck.Model.Reports {
  /// <summary>A vehicle stolen status.</summary>
  public class Stolen {
    /// <summary></summary>
    [JsonProperty("contact_number")]
    public string ContactNumber { get; set; }

    /// <summary>The date on which the vehicle was reported stolen.</summary>
    [JsonProperty("date_scrapped")]
    public DateTime? Date { get; set; }

    /// <summary>A flag indicating whether the vehicle has been stolen.</summary>
    [JsonProperty("is_stolen")]
    public bool IsStolen { get; set; }

    /// <summary>The police force to which the vehicle was reported stolen.</summary>
    [JsonProperty("police_force")]
    public string PoliceForce { get; set; }

    /// <summary>The soruce from which the stolen information was retrieved.</summary>
    [JsonProperty("stolen_info_source")]
    public string StolenInfoSource { get; set; }
  }
}

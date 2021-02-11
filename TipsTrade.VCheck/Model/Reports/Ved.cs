using Newtonsoft.Json;
using System;

namespace TipsTrade.VCheck.Model.Reports {
  /// <summary>The vehicle exise duty report.</summary>
  public class Ved {
    /// <summary>The number of days left on the current MOT certificate.</summary>
    [JsonProperty("days_left")]
    public int? DaysLeft { get; set; }

    /// <summary>The CO2 emissions (g/km)</summary>
    [JsonProperty("co2")]
    public float? Co2 { get; set; }

    /// <summary>The date on which the VED expires.</summary>
    [JsonProperty("expiry")]
    public DateTime? Expiry { get; set; }

    /// <summary>A flag indicating whether the vehicle has a statutory off-road notification (SORN).</summary>
    [JsonProperty("is_sort")]
    public bool? IsSorn { get; set; }

    /// <summary>A flag indicating whether the VED is valid.</summary>
    [JsonProperty("is_valid")]
    public bool? IsValid { get; set; }

    /// <summary>The VED rate.</summary>
    [JsonProperty("rate")]
    public VedRate Rate { get; set; }

    /// <summary>The VED tax band.</summary>
    [JsonProperty("tax_band")]
    public string TaxBand { get; set; }
  }
}
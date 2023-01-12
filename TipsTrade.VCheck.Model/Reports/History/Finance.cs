using Newtonsoft.Json;
using System;
using System.Text.Json.Serialization;

namespace TipsTrade.VCheck.Model.Reports {
  /// <summary>A vehicle finance record.</summary>
  public class Finance {
    /// <summary>The finance agreement number.</summary>
    [JsonProperty("agreement_number"), JsonPropertyName("agreement_number")]
    public string AgreementNumber { get; set; }

    /// <summary>The finance date.</summary>
    [JsonProperty("date"), JsonPropertyName("date")]
    public DateTime? Date { get; set; }

    /// <summary>The name of the company who has interest in the vehicle.</summary>
    [JsonProperty("finance_company"), JsonPropertyName("finance_company")]
    public string FinanceCompany { get; set; }

    /// <summary>The term of the finance agreement.</summary>
    [JsonProperty("term"), JsonPropertyName("term")]
    public int Term { get; set; }

    /// <summary>The vehicle description.</summary>
    [JsonProperty("vehicle_description"), JsonPropertyName("vehicle_description")]
    public string VehicleDescription { get; set; }
  }
}

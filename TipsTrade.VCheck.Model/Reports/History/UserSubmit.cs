using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TipsTrade.VCheck.Model.Reports.History {
  /// <summary>A user submitted record.</summary>
  public class UserSubmit : IVin, IVrm {
    /// <summary>The date on which the user submitted the record.</summary>
    [JsonProperty("date"), JsonPropertyName("date")]
    public DateTime? Date { get; set; }

    /// <summary>The list of user submitted images.</summary>
    [JsonProperty("images"), JsonPropertyName("images")]
    public IEnumerable<string> Images { get; set; }

    /// <summary>The user submitted mileage.</summary>
    [JsonProperty("mileage"), JsonPropertyName("mileage")]
    public string Mileage { get; set; }

    /// <summary>The user submitted notes.</summary>
    [JsonProperty("notes"), JsonPropertyName("notes")]
    public string Notes { get; set; }

    /// <summary>The VIN of the vehicle.</summary>
    [JsonProperty("vin"), JsonPropertyName("vin")]
    public string Vin { get; set; }

    /// <summary>The VRM of the vehicle.</summary>
    [JsonProperty("vrm"), JsonPropertyName("vrm")]
    public string Vrm { get; set; }
  }
}

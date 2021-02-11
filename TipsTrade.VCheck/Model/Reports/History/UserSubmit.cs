using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace TipsTrade.VCheck.Model.Reports.History {
  /// <summary>A user submitted record.</summary>
  public class UserSubmit : IVin, IVrm {
    /// <summary>The date on which the user submitted the record.</summary>
    [JsonProperty("date")]
    public DateTime? Date { get; set; }

    /// <summary>The list of user submitted images.</summary>
    [JsonProperty("images")]
    public IEnumerable<string> Images { get; set; }

    /// <summary>The user submitted mileage.</summary>
    [JsonProperty("mileage")]
    public string Mileage { get; set; }

    /// <summary>The user submitted notes.</summary>
    [JsonProperty("notes")]
    public string Notes { get; set; }

    /// <summary>The VIN of the vehicle.</summary>
    [JsonProperty("vin")]
    public string Vin { get; set; }

    /// <summary>The VRM of the vehicle.</summary>
    [JsonProperty("vrm")]
    public string Vrm { get; set; }
  }
}

using Newtonsoft.Json;
using System;

namespace TipsTrade.VCheck.Model.Reports {
  /// <summary>A vehicle ancestory record.</summary>
  public class VehicleAncestory : IVrm {
    /// <summary>The date until which the ancestory is valid.</summary>
    [JsonProperty("date_from")]
    public DateTime? DateFrom { get; set; }

    /// <summary>The date from which the ancestory is valid.</summary>
    [JsonProperty("date_to")]
    public DateTime? DateTo { get; set; }

    /// <summary>The description of the vehicle.</summary>
    [JsonProperty("vehicle")]
    public string Vehicle { get; set; }

    /// <summary>The type of ancestory record.</summary>
    [JsonProperty("record_type")]
    public string RecordType { get; set; }

    /// <summary>The source of the vehicle ancestory.</summary>
    [JsonProperty("source")]
    public string Source { get; set; }

    /// <summary>The VRM of the vehicle.</summary>
    [JsonProperty("vrm")]
    public string Vrm { get; set; }
  }
}

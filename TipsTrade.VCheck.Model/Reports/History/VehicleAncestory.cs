using Newtonsoft.Json;
using System;
using System.Text.Json.Serialization;

namespace TipsTrade.VCheck.Model.Reports {
  /// <summary>A vehicle ancestory record.</summary>
  public class VehicleAncestory : IVrm {
    /// <summary>The date until which the ancestory is valid.</summary>
    [JsonProperty("date_from"), JsonPropertyName("date_from")]
    public DateTime? DateFrom { get; set; }

    /// <summary>The date from which the ancestory is valid.</summary>
    [JsonProperty("date_to"), JsonPropertyName("date_to")]
    public DateTime? DateTo { get; set; }

    /// <summary>The description of the vehicle.</summary>
    [JsonProperty("vehicle"), JsonPropertyName("vehicle")]
    public string Vehicle { get; set; }

    /// <summary>The type of ancestory record.</summary>
    [JsonProperty("record_type"), JsonPropertyName("record_type")]
    public string RecordType { get; set; }

    /// <summary>The source of the vehicle ancestory.</summary>
    [JsonProperty("source"), JsonPropertyName("source")]
    public string Source { get; set; }

    /// <summary>The VRM of the vehicle.</summary>
    [JsonProperty("vrm"), JsonPropertyName("vrm")]
    public string Vrm { get; set; }

    /// <summary>Returns a string that represents the current object.</summary>
    public override string ToString() {
      return $"{RecordType} from {Source} from ${DateFrom?.ToString("d") ?? "unknown"} to {DateTo?.ToString("d" ?? "unknown")}";
    }
  }
}

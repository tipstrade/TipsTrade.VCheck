using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace TipsTrade.VCheck.Model.Reports.Technical {
  /// <summary>The general information for a vehicle.</summary>
  public class General {
    /// <summary>The position of the driver.</summary>
    [JsonProperty("driver_position"), JsonPropertyName("driver_position")]
    public string DriverPosition { get; set; }

    /// <summary>The driving axle.</summary>
    [JsonProperty("driving_axle"), JsonPropertyName("driving_axle")]
    public string DrivingAxle { get; set; }

    /// <summary>The Euro status.</summary>
    [JsonProperty("euro_status"), JsonPropertyName("euro_status")]
    public string EuroStatus { get; set; }

    /// <summary>The type of fuel delivery.</summary>
    [JsonProperty("power_delivery"), JsonPropertyName("power_delivery")]
    public string PowerDelivery { get; set; }
  }
}

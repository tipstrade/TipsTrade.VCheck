using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace TipsTrade.VCheck.Model.Reports.Technical {
  /// <summary>The performance data of a vehicle.</summary>
  public class Permformance {
    /// <summary>The time to accelerate from 0 to 60 mph.</summary>
    [JsonProperty("acceleration"), JsonPropertyName("acceleration")]
    public float? Acceleration { get; set; }

    /// <summary>The maximum speed of the vehicle.</summary>
    [JsonProperty("max_speed"), JsonPropertyName("max_speed")]
    public float? MaxSpeed { get; set; }

    /// <summary>The maximum power values.</summary>
    [JsonProperty("power"), JsonPropertyName("power")]
    public PowerValues Power { get; set; }

    /// <summary>The maximum torque values.</summary>
    [JsonProperty("torque"), JsonPropertyName("torque")]
    public TorqueValues Torque { get; set; }
  }

  /// <summary>The power values.</summary>
  public class PowerValues {
    /// <summary>The power in bhp.</summary>
    [JsonProperty("bhp"), JsonPropertyName("bhp")]
    public float? Bhp { get; set; }

    /// <summary>The power in kilowatts.</summary>
    [JsonProperty("kw"), JsonPropertyName("kw")]
    public float? Kilowatt { get; set; }

    /// <summary>The rpm at which thw power was measured.</summary>
    [JsonProperty("rpm"), JsonPropertyName("rpm")]
    public float? Rpm { get; set; }
  }

  /// <summary>The torque values.</summary>
  public class TorqueValues {
    /// <summary>The torque in foot-pounds.</summary>
    [JsonProperty("ftlb"), JsonPropertyName("ftlb")]
    public float? FootPound { get; set; }

    /// <summary>The torque in newton-metres.</summary>
    [JsonProperty("nm"), JsonPropertyName("nm")]
    public float? NewtonMetre { get; set; }

    /// <summary>The rpm at which the torque was measured.</summary>
    [JsonProperty("rpm"), JsonPropertyName("rpm")]
    public float? Rpm { get; set; }
  }
}
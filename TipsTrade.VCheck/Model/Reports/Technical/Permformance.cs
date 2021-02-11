using Newtonsoft.Json;

namespace TipsTrade.VCheck.Model.Reports.Technical {
  /// <summary>The performance data of a vehicle.</summary>
  public class Permformance {
    /// <summary>The time to accelerate from 0 to 60 mph.</summary>
    [JsonProperty("acceleration")]
    public float? Acceleration { get; set; }

    /// <summary>The maximum speed of the vehicle.</summary>
    [JsonProperty("max_speed")]
    public float? MaxSpeed { get; set; }

    /// <summary>The maximum power values.</summary>
    [JsonProperty("power")]
    public PowerValues Power { get; set; }

    /// <summary>The maximum torque values.</summary>
    [JsonProperty("torque")]
    public TorqueValues Torque { get; set; }
  }

  /// <summary>The power values.</summary>
  public class PowerValues {
    /// <summary>The power in bhp.</summary>
    [JsonProperty("bhp")]
    public float? Bhp { get; set; }

    /// <summary>The power in kilowatts.</summary>
    [JsonProperty("kw")]
    public float? Kilowatt { get; set; }

    /// <summary>The rpm at which thw power was measured.</summary>
    [JsonProperty("rpm")]
    public float? Rpm { get; set; }
  }

  /// <summary>The torque values.</summary>
  public class TorqueValues {
    /// <summary>The torque in foot-pounds.</summary>
    [JsonProperty("ftlb")]
    public float? FootPound { get; set; }

    /// <summary>The torque in newton-metres.</summary>
    [JsonProperty("nm")]
    public float? NewtonMetre { get; set; }

    /// <summary>The rpm at which the torque was measured.</summary>
    [JsonProperty("rpm")]
    public float? Rpm { get; set; }
  }
}
using Newtonsoft.Json;

namespace TipsTrade.VCheck.Model.Reports.Technical {
  /// <summary>The physical dimensions of a vehicle.</summary>
  public class Dimensions {
    /// <summary>The number of axles on the vehicle.</summary>
    [JsonProperty("axles")]
    public int? Axles { get; set; }

    /// <summary>The number of doors on the vehicle.</summary>
    [JsonProperty("door")]
    public int? Doors { get; set; }

    /// <summary>The capacity of the fuel tank.</summary>
    [JsonProperty("fuel_tank_capacity")]
    public float? FuelTankCapacity { get; set; }

    /// <summary>The gross weight of the vehicle (kg).</summary>
    [JsonProperty("gross_weight")]
    public float? GrossWeight { get; set; }

    /// <summary>The height of the vehicle (mm).</summary>
    [JsonProperty("height")]
    public float? Height { get; set; }

    /// <summary>The kerb weight of the vehicle (kg).</summary>
    [JsonProperty("kerb_weight")]
    public float? KerbWeight { get; set; }

    /// <summary>The length of the vehicle (mm).</summary>
    [JsonProperty("length")]
    public float? Length { get; set; }

    /// <summary>The number of seats in the vehicle.</summary>
    [JsonProperty("seats")]
    public int? Seats { get; set; }

    /// <summary>The wheel base of the vehicle (mm).</summary>
    [JsonProperty("wheel_base")]
    public float? WheelBase { get; set; }

    /// <summary>The width of the vehicle (mm).</summary>
    [JsonProperty("width")]
    public float? Width { get; set; }
  }
}

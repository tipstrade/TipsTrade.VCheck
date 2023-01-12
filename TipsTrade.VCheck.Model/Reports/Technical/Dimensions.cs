using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace TipsTrade.VCheck.Model.Reports.Technical {
  /// <summary>The physical dimensions of a vehicle.</summary>
  public class Dimensions {
    /// <summary>The number of axles on the vehicle.</summary>
    [JsonProperty("axles"), JsonPropertyName("axles")]
    public int? Axles { get; set; }

    /// <summary>The number of doors on the vehicle.</summary>
    [JsonProperty("doors"), JsonPropertyName("doors")]
    public int? Doors { get; set; }

    /// <summary>The capacity of the fuel tank.</summary>
    [JsonProperty("fuel_tank_capacity"), JsonPropertyName("fuel_tank_capacity")]
    public float? FuelTankCapacity { get; set; }

    /// <summary>The gross weight of the vehicle (kg).</summary>
    [JsonProperty("gross_weight"), JsonPropertyName("gross_weight")]
    public float? GrossWeight { get; set; }

    /// <summary>The height of the vehicle (mm).</summary>
    [JsonProperty("height"), JsonPropertyName("height")]
    public float? Height { get; set; }

    /// <summary>The kerb weight of the vehicle (kg).</summary>
    [JsonProperty("kerb_weight"), JsonPropertyName("kerb_weight")]
    public float? KerbWeight { get; set; }

    /// <summary>The length of the vehicle (mm).</summary>
    [JsonProperty("length"), JsonPropertyName("length")]
    public float? Length { get; set; }

    /// <summary>The number of seats in the vehicle.</summary>
    [JsonProperty("seats"), JsonPropertyName("seats")]
    public int? Seats { get; set; }

    /// <summary>The wheel base of the vehicle (mm).</summary>
    [JsonProperty("wheel_base"), JsonPropertyName("wheel_base")]
    public float? WheelBase { get; set; }

    /// <summary>The width of the vehicle (mm).</summary>
    [JsonProperty("width"), JsonPropertyName("width")]
    public float? Width { get; set; }
  }
}

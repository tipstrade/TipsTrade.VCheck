using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace TipsTrade.VCheck.Model.Reports.Technical {
  /// <summary>The engine data of a vehicle.</summary>
  public class Engine {
    /// <summary>The type of aspiration of the engine.</summary>
    [JsonProperty("aspiration"), JsonPropertyName("aspiration")]
    public string Aspriation { get; set; }

    /// <summary>The diametre of the cylinder bore.</summary>
    [JsonProperty("bore"), JsonPropertyName("bore")]
    public float? Bore { get; set; }

    /// <summary>The cylinder arrangement.</summary>
    [JsonProperty("cylinder_arrangement"), JsonPropertyName("cylinder_arrangement")]
    public string CylinderArrangement { get; set; }

    /// <summary>The type of fuel delivery.</summary>
    [JsonProperty("fuel_delivery"), JsonPropertyName("fuel_delivery")]
    public string FuelDelivery { get; set; }

    /// <summary>The location of the engine in the vehicle.</summary>
    [JsonProperty("location"), JsonPropertyName("location")]
    public string Location { get; set; }

    /// <summary>The number of cylinders in the engine.</summary>
    [JsonProperty("number_of_cylinders"), JsonPropertyName("number_of_cylinders")]
    public int? NumberOfCylinders { get; set; }

    /// <summary>The length of the piston stroke.</summary>
    [JsonProperty("stroke"), JsonPropertyName("stroke")]
    public float? Stroke { get; set; }

    /// <summary>The type of valve gear.</summary>
    [JsonProperty("valve_gear"), JsonPropertyName("valve_gear")]
    public string ValveGear { get; set; }

    /// <summary>The number of valves per cylinder.</summary>
    [JsonProperty("valves_per_cylinder"), JsonPropertyName("valves_per_cylinder")]
    public int? ValvesPerCylinder { get; set; }
  }
}

using Newtonsoft.Json;
using System.Text.Json.Serialization;
using TipsTrade.VCheck.Model.Reports.History;
using TipsTrade.VCheck.Model.Reports.Technical;

namespace TipsTrade.VCheck.Model.Reports {
  /// <summary>A full report.</summary>
  public class Report {
    /// <summary>The check details.</summary>
    [JsonProperty("check_details"), JsonPropertyName("check_details")]
    public CheckDetails CheckDetails { get; set; }

    /// <summary>The fuel costs.</summary>
    [JsonProperty("fuel_costs"), JsonPropertyName("fuel_costs")]
    public FuelCosts FuelCosts { get; set; }

    /// <summary>The MOT information.</summary>
    [JsonProperty("mot"), JsonPropertyName("mot")]
    public Mot Mot { get; set; }

    /// <summary>The vehicle summary.</summary>
    [JsonProperty("summary"), JsonPropertyName("summary")]
    public VehicleSummary Summary { get; set; }

    /// <summary>The vehicle technical specification.</summary>
    [JsonProperty("technical_specification"), JsonPropertyName("technical_specification")]
    public TechnicalSpecification TechnicalSpecification { get; set; }

    /// <summary>The ultra-low emission zone (London) information.</summary>
    [JsonProperty("ulez"), JsonPropertyName("ulez")]
    public Ulez Ulez { get; set; }

    /// <summary>The vehicle valuation status.</summary>
    [JsonProperty("valuation"), JsonPropertyName("valuation")]
    public Valuation Valuation { get; set; }

    /// <summary>The VED information.</summary>
    [JsonProperty("road_tax"), JsonPropertyName("road_tax")]
    public Ved Ved { get; set; }


    /// <summary>The vehicle details.</summary>
    [JsonProperty("vehicle_details"), JsonPropertyName("vehicle_details")]
    public VehicleDetails VehicleDetails { get; set; }

    /// <summary>The vehicle history.</summary>
    [JsonProperty("vehicle_history"), JsonPropertyName("vehicle_history")]
    public VehicleHistory VehicleHistory { get; set; }
  }
}

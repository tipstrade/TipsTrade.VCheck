using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TipsTrade.VCheck.Model.Reports {
  /// <summary>The estimated fuel costs of the vehicle.</summary>
  public class FuelCosts {
    /// <summary>The fuel consumption values.</summary>
    [JsonProperty("fuel_consumption"), JsonPropertyName("fuel_consumption")]
    public FuelConsumptionValues FuelConsumption { get; set; }

    /// <summary>The fuel prices.</summary>
    [JsonProperty("fuel_price"), JsonPropertyName("fuel_price")]
    public Dictionary<string, float> FuelPrice { get; set; }

    /// <summary>The estimated yearly fuel cost for a range of mileages.</summary>
    [JsonProperty("yearly_fuel_cost"), JsonPropertyName("yearly_fuel_cost")]
    public Dictionary<int, int> YearlyFuelCost { get; set; }
  }

  /// <summary>The fuel consumption values.</summary>
  public class FuelConsumption {
    /// <summary>The fuel consumption in miles per gallon.</summary>
    [JsonProperty("mpg"), JsonPropertyName("mpg")]
    public float? Mpg { get; set; }

    /// <summary>The fuel consumption per kilometre.</summary>
    [JsonProperty("lkm"), JsonPropertyName("lkm")]
    public float? PerKm { get; set; }
  }

  /// <summary>The fuel consumption values.</summary>
  public class FuelConsumptionValues {
    /// <summary>The combined fuel consumption.</summary>
    [JsonProperty("combined"), JsonPropertyName("combined")]
    public FuelConsumption Combined { get; set; }

    /// <summary>The extra-urban fuel consumption.</summary>
    [JsonProperty("extra_urban"), JsonPropertyName("extra_urban")]
    public FuelConsumption ExtraUrban { get; set; }

    /// <summary>The cold urban fuel consumption.</summary>
    [JsonProperty("urban_cold"), JsonPropertyName("urban_cold")]
    public FuelConsumption UrbanCold { get; set; }
  }
}

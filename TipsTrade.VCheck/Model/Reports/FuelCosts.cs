using Newtonsoft.Json;
using System.Collections.Generic;

namespace TipsTrade.VCheck.Model.Reports {
  /// <summary>The estimated fuel costs of the vehicle.</summary>
  public class FuelCosts {
    /// <summary>The fuel consumption values.</summary>
    [JsonProperty("fuel_consumption")]
    public FuelConsumptionValues FuelConsumption { get; set; }

    /// <summary>The fuel prices.</summary>
    [JsonProperty("fuel_price")]
    public Dictionary<string, float> FuelPrice { get; set; }

    /// <summary>The estimated yearly fuel cost for a range of mileages.</summary>
    [JsonProperty("yearly_fuel_cost")]
    public Dictionary<int, int> YearlyFuelCost { get; set; }
  }

  /// <summary>The fuel consumption values.</summary>
  public class FuelConsumption {
    /// <summary>The fuel consumption in miles per gallon.</summary>
    [JsonProperty("mpg")]
    public float? Mpg { get; set; }

    /// <summary>The fuel consumption per kilometre.</summary>
    [JsonProperty("lkm")]
    public float? PerKm { get; set; }
  }

  /// <summary>The fuel consumption values.</summary>
  public class FuelConsumptionValues {
    /// <summary>The combined fuel consumption.</summary>
    [JsonProperty("combined")]
    public FuelConsumption Combined { get; set; }

    /// <summary>The extra-urban fuel consumption.</summary>
    [JsonProperty("extra_urban")]
    public FuelConsumption ExtraUrban { get; set; }

    /// <summary>The cold urban fuel consumption.</summary>
    [JsonProperty("urban_cold")]
    public FuelConsumption UrbanCold { get; set; }
  }
}

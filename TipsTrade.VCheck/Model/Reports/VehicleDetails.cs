using Newtonsoft.Json;
using System;

namespace TipsTrade.VCheck.Model.Reports {
  /// <summary>The vehicle registration details.</summary>
  public class VehicleDetails : IMakeModel, IVin, IVrm {
    /// <summary>The body type of the vehicle.</summary>
    [JsonProperty("body")]
    public string Body { get; set; }

    /// <summary>The CO2 emissions (g/km)</summary>
    [JsonProperty("co2")]
    public float? Co2 { get; set; }

    /// <summary>The exterior colour of the vehicle.</summary>
    [JsonProperty("colour")]
    public string Colour { get; set; }

    /// <summary>The date on which the vehicle was first registered.</summary>
    [JsonProperty("first_registered")]
    public DateTime? FirstRegistered { get; set; }

    /// <summary>The date on which the vehicle was first registered in the UK.</summary>
    [JsonProperty("first_registered_uk")]
    public DateTime? FirstRegisteredUK { get; set; }

    /// <summary>The engine number of the vehicle.</summary>
    [JsonProperty("engine_number")]
    public string EngineNumber { get; set; }

    /// <summary>The engine size (cc) of the vehicle.</summary>
    [JsonProperty("engine_size")]
    public string EngineSize { get; set; }

    /// <summary>The fuel type of the vehicle.</summary>
    [JsonProperty("fuel_type")]
    public string FuelType { get; set; }

    /// <summary>The make of the vehicle.</summary>
    [JsonProperty("make")]
    public string Make { get; set; }

    /// <summary>The model of the vehicle.</summary>
    [JsonProperty("Model")]
    public string Model { get; set; }

    /// <summary>The maximum power (bhp) of the vehicle.</summary>
    [JsonProperty("power_bhp")]
    public float? PowerBhp { get; set; }

    /// <summary>The number of seats in the vehicle.</summary>
    [JsonProperty("seats")]
    public int? Seats { get; set; }

    /// <summary>The transmission type of the vehicle.</summary>
    [JsonProperty("transmission")]
    public string Transmission { get; set; }

    /// <summary>The type of the vehicle.</summary>
    [JsonProperty("vehicle_type")]
    public string VehicleType { get; set; }

    /// <summary>The VIN of the vehicle.</summary>
    [JsonProperty("vin")]
    public string Vin { get; set; }

    /// <summary>The last 5 characters of the VIN of the vehicle.</summary>
    [JsonProperty("vin_last_5")]
    public string VinLast5 { get; set; }

    /// <summary>The VRM of the vehicle.</summary>
    [JsonProperty("vrm")]
    public string Vrm { get; set; }

    /// <summary>The year of the vehicle.</summary>
    [JsonProperty("year")]
    public int? Year { get; set; }
  }
}

using Newtonsoft.Json;
using System;

namespace TipsTrade.VCheck.Model.Reports.History {
  /// <summary>A salvage auction record.</summary>
  public class SalvageAuction : IMakeModel, IVin, IVrm {
    /// <summary>The salvage category.</summary>
    [JsonProperty("category")]
    public string Category { get; set; }

    /// <summary>The salvage description.</summary>
    [JsonProperty("description")]
    public string Description { get; set; }

    /// <summary>The drive type of the vehicle.</summary>
    [JsonProperty("drive")]
    public string Drive { get; set; }

    /// <summary>The engine capacity in CC of the vehicle.</summary>
    [JsonProperty("engine_cc")]
    public int EngineCC { get; set; }

    /// <summary>The fuel type of the vehicle.</summary>
    [JsonProperty("Fuel")]
    public string Fuel { get; set; }

    /// <summary>The number of images available.</summary>
    [JsonProperty("images_count")]
    public int ImagesCount { get; set; }

    /// <summary>The location of the salvage.</summary>
    [JsonProperty("location")]
    public string Location { get; set; }

    /// <summary>The make of the vehicle.</summary>
    [JsonProperty("make")]
    public string Make { get; set; }

    /// <summary>The mileage reading.</summary>
    [JsonProperty("mileage")]
    public int Mileage { get; set; }

    /// <summary>The model of the vehicle.</summary>
    [JsonProperty("Model")]
    public string Model { get; set; }

    /// <summary>The retail value of the vehicle.</summary>
    [JsonProperty("retail_value")]
    public int? RetailValue { get; set; }

    /// <summary>The date on which the vehicle was sold.</summary>
    [JsonProperty("sale_date")]
    public DateTime? SaleDate { get; set; }

    /// <summary>The transmission type of the vehicle.</summary>
    [JsonProperty("transmission")]
    public string Transmission { get; set; }

    /// <summary>The URL where the VCheck record can be viewed.</summary>
    [JsonProperty("url")]
    public string Url { get; set; }

    /// <summary>The VIN of the vehicle.</summary>
    [JsonProperty("vin")]
    public string Vin { get; set; }

    /// <summary>The VRM of the vehicle.</summary>
    [JsonProperty("vrm")]
    public string Vrm { get; set; }

    /// <summary>The year of the vehicle.</summary>
    [JsonProperty("year")]
    public int Year { get; set; }
  }
}

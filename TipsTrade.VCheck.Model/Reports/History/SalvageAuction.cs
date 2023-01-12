using Newtonsoft.Json;
using System;
using System.Text.Json.Serialization;

namespace TipsTrade.VCheck.Model.Reports.History {
  /// <summary>A salvage auction record.</summary>
  public class SalvageAuction : IMakeModel, IVin, IVrm {
    /// <summary>The salvage category.</summary>
    [JsonProperty("category"), JsonPropertyName("category")]
    public string Category { get; set; }

    /// <summary>The salvage description.</summary>
    [JsonProperty("description"), JsonPropertyName("description")]
    public string Description { get; set; }

    /// <summary>The drive type of the vehicle.</summary>
    [JsonProperty("drive"), JsonPropertyName("drive")]
    public string Drive { get; set; }

    /// <summary>The engine capacity in CC of the vehicle.</summary>
    [JsonProperty("engine"), JsonPropertyName("engine")]
    public int? Engine { get; set; }

    /// <summary>The fuel type of the vehicle.</summary>
    [JsonProperty("fuel"), JsonPropertyName("fuel")]
    public string Fuel { get; set; }

    /// <summary>The number of images available.</summary>
    [JsonProperty("images_count"), JsonPropertyName("images_count")]
    public int ImagesCount { get; set; }

    /// <summary>The location of the salvage.</summary>
    [JsonProperty("location"), JsonPropertyName("location")]
    public string Location { get; set; }

    /// <summary>The make of the vehicle.</summary>
    [JsonProperty("make"), JsonPropertyName("make")]
    public string Make { get; set; }

    /// <summary>The mileage reading.</summary>
    [JsonProperty("mileage"), JsonPropertyName("mileage")]
    public int? Mileage { get; set; }

    /// <summary>The model of the vehicle.</summary>
    [JsonProperty("model"), JsonPropertyName("model")]
    public string Model { get; set; }

    /// <summary>The retail value of the vehicle.</summary>
    [JsonProperty("retail_value"), JsonPropertyName("retail_value")]
    public int? RetailValue { get; set; }

    /// <summary>The date on which the vehicle was sold.</summary>
    [JsonProperty("sale_date"), JsonPropertyName("sale_date")]
    public DateTime? SaleDate { get; set; }

    /// <summary>The transmission type of the vehicle.</summary>
    [JsonProperty("transmission"), JsonPropertyName("transmission")]
    public string Transmission { get; set; }

    /// <summary>The URL where the VCheck record can be viewed.</summary>
    [JsonProperty("url"), JsonPropertyName("url")]
    public string Url { get; set; }

    /// <summary>The VIN of the vehicle.</summary>
    [JsonProperty("vin"), JsonPropertyName("vin")]
    public string Vin { get; set; }

    /// <summary>The VRM of the vehicle.</summary>
    [JsonProperty("vrm"), JsonPropertyName("vrm")]
    public string Vrm { get; set; }

    /// <summary>The year of the vehicle.</summary>
    [JsonProperty("year"), JsonPropertyName("year")]
    public int Year { get; set; }
  }
}

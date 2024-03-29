﻿using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace TipsTrade.VCheck.Model.Reports.Technical {
  /// <summary>The technical specification of a vehicle.</summary>
  public class TechnicalSpecification  {
    /// <summary>The physicl dimensions of the vehicle.</summary>
    [JsonProperty("dimensions"), JsonPropertyName("dimensions")]
    public Dimensions Dimensions { get; set; }

    /// <summary>The engine data for the vehicle.</summary>
    [JsonProperty("engine"), JsonPropertyName("engine")]
    public Engine Engine { get; set; }

    /// <summary>The general information for the vehicle.</summary>
    [JsonProperty("general"), JsonPropertyName("general")]
    public General General { get; set; }

    /// <summary>The performance data of the vehicle.</summary>
    [JsonProperty("performance"), JsonPropertyName("performance")]
    public Permformance Permformance { get; set; }
  }
}

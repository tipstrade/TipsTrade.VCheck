﻿using Newtonsoft.Json;

namespace TipsTrade.VCheck.Model.Reports {
  /// <summary>The vehicle valuation.</summary>
  public class Valuation {
    /// <summary>A flag indicating whether the valuation is available.</summary>
    [JsonProperty("is_available")]
    public bool IsAvailable { get; set; }
  }
}

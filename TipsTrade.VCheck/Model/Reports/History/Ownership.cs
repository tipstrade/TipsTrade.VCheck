using Newtonsoft.Json;
using System;

namespace TipsTrade.VCheck.Model.Reports {
  /// <summary>A vehicle ownership record.</summary>
  public class Ownership {
    /// <summary>The keeper number.</summary>
    [JsonProperty("keeper_number")]
    public int KeeperNumber { get; set; }

    /// <summary>The length of time tha the keeper had the vehicle.</summary>
    [JsonProperty("ownership_length")]
    public string OwnershipLength { get; set; }

    /// <summary>The date on which the vehicle was purchased.</summary>
    [JsonProperty("purchase_date")]
    public DateTime? PurchaseDate { get; set; }
  }
}

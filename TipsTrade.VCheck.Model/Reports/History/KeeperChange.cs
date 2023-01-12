using Newtonsoft.Json;
using System;
using System.Text.Json.Serialization;

namespace TipsTrade.VCheck.Model.Reports.History {
  /// <summary>A keeper change record.</summary>
  public class KeeperChange {
    /// <summary>The keeper number.</summary>
    [JsonProperty("keeper_number"), JsonPropertyName("keeper_number")]
    public int KeeperNumber { get; set; }

    /// <summary>The length of time tha the keeper had the vehicle.</summary>
    [JsonProperty("ownership_length"), JsonPropertyName("ownership_length")]
    public string OwnershipLength { get; set; }

    /// <summary>The date on which the vehicle was purchased.</summary>
    [JsonProperty("purchase_date"), JsonPropertyName("purchase_date")]
    public DateTime? PurchaseDate { get; set; }

    /// <summary>Returns a string that represents the current object.</summary>
    public override string ToString() {
      return $"Keeper #{KeeperNumber} for {OwnershipLength} since {PurchaseDate?.ToString("d") ?? "unknown"}";
    }
  }
}

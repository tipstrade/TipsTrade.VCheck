using Newtonsoft.Json;
using System;

namespace TipsTrade.VCheck.Model.Reports {
  /// <summary>A vehice write-off record.</summary>
  public class WriteOff {
    /// <summary>The date on which the entry was created.</summary>
    [JsonProperty("entry_date")]
    public DateTime? EntryDate { get; set; }

    /// <summary>The date on which the loss occurred.</summary>
    [JsonProperty("loss_date")]
    public DateTime? LossDate { get; set; }

    /// <summary>The type of loss that occurred.</summary>
    [JsonProperty("loss_type")]
    public string LossType { get; set; }

    /// <summary>Returns a string that represents the current object.</summary>
    public override string ToString() {
      return $"Written off as {LossType} on ${EntryDate?.ToString("d") ?? "unknown"}";
    }
  }
}

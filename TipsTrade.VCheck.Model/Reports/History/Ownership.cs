using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TipsTrade.VCheck.Model.Reports.History {
  /// <summary>A vehicle ownership record.</summary>
  public class Ownership {
    /// <summary>The list of keeper changes.</summary>
    [JsonProperty("keeper_changes"), JsonPropertyName("keeper_changes")]
    public IEnumerable<KeeperChange> KeeperChanges { get; set; }

    /// <summary>The number of previous keepers.</summary>
    [JsonProperty("previous_keepers"), JsonPropertyName("previous_keepers")]
    public int PreviousKeepers { get; set; }
  }
}

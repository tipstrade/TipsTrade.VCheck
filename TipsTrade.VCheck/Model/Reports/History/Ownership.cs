using Newtonsoft.Json;
using System.Collections.Generic;

namespace TipsTrade.VCheck.Model.Reports.History {
  /// <summary>A vehicle ownership record.</summary>
  public class Ownership {
    /// <summary>The list of keeper changes.</summary>
    [JsonProperty("keeper_changes")]
    public IEnumerable<KeeperChange> KeeperChanges { get; set; }

    /// <summary>The number of previous keepers.</summary>
    [JsonProperty("previous_keepers")]
    public int PreviousKeepers { get; set; }
  }
}

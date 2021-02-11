using Newtonsoft.Json;
using System.Collections.Generic;

namespace TipsTrade.VCheck.Model.Reports.History {
  /// <summary>A generic result that contains a list.</summary>
  /// <typeparam name="T">The type of result.</typeparam>
  public class ResultList<T> {
    /// <summary>The number of results.</summary>
    [JsonProperty("count")]
    public int Count { get; set; }

    /// <summary>The list of results.</summary>
    [JsonProperty("results")]
    public IEnumerable<T> Results { get; set; }
  }
}

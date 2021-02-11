using Newtonsoft.Json;
using System.Collections.Generic;

namespace TipsTrade.VCheck.Model {
  /// <summary>A generic list response from the API.</summary>
  /// <typeparam name="T">The type of object in the <see cref="Results"/> property.</typeparam>
  internal class ResponseList<T> where T : new() {
    /// <summary>The number of records returned.</summary>
    [JsonProperty("count")]
    public int Count { get; set; }

    /// <summary>The list of results.</summary>
    [JsonProperty("results")]
    public IEnumerable<T> Results { get; set; }
  }
}

using Newtonsoft.Json;

namespace TipsTrade.VCheck.Model.Reports {
  /// <summary>An MOT failure or advisory comment.</summary>
  public class MotComment {
    /// <summary>A flag indicating whether the comment was dangerous.</summary>
    [JsonProperty("dangerous")]
    public bool IsDangerous { get; set; }

    /// <summary>The comment text.</summary>
    [JsonProperty("text")]
    public string Text { get; set; }

    /// <summary>The type of comment.</summary>
    [JsonProperty("type")]
    public string Type { get; set; }
  }
}

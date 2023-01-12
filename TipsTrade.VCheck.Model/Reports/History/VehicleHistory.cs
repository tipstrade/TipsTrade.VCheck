using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace TipsTrade.VCheck.Model.Reports.History {
  /// <summary>The vehicle history.</summary>
  public class VehicleHistory {
    /// <summary>The colour changes that have been recorded for the vehicle.</summary>
    [JsonProperty("colour_changes"), JsonPropertyName("colour_changes")]
    public ColourChanges ColourChanges { get; set; }

    /// <summary>The vehicle ancestory of the vehicle.</summary>
    [JsonProperty("vehicle_ancestry"), JsonPropertyName("vehicle_ancestry")]
    public ResultList<VehicleAncestory> Ancestory { get; set; }

    /// <summary>A list of finance agreements on the vehicle.</summary>
    [JsonProperty("finance"), JsonPropertyName("finance")]
    public ResultList<Finance> Finance { get; set; }

    /// <summary>The export status.</summary>
    [JsonProperty("export"), JsonPropertyName("export")]
    public Export Export { get; set; }

    /// <summary>The import status.</summary>
    [JsonProperty("import"), JsonPropertyName("import")]
    public Import Import { get; set; }

    /// <summary>The list of mileage records.</summary>
    [JsonProperty("mileage_records"), JsonPropertyName("mileage_records")]
    public ResultList<MileageRecord> MileageRecords { get; set; }

    /// <summary>The ownership status.</summary>
    [JsonProperty("ownership"), JsonPropertyName("ownership")]
    public Ownership Ownership { get; set; }

    /// <summary>The list of salvage records.</summary>
    [JsonProperty("salvage_auctions"), JsonPropertyName("salvage_auctions")]
    public ResultList<SalvageAuction> SalvageAuctions { get; set; }

    /// <summary>The export status.</summary>
    [JsonProperty("scarapped"), JsonPropertyName("scarapped")]
    public Scrapped Scrapped { get; set; }

    /// <summary>Any recorded thefts of the vehicle.</summary>
    [JsonProperty("stolen"), JsonPropertyName("stolen")]
    public Stolen Stolen { get; set; }

    /// <summary>The list of VRM changes of the vehicle.</summary>
    [JsonProperty("number_plates"), JsonPropertyName("number_plates")]
    public ResultList<VrmChange> VrmChanges { get; set; }

    /// <summary>The list of write-off records on the vehicle.</summary>
    [JsonProperty("written_off"), JsonPropertyName("written_off")]
    public ResultList<WriteOff> WrittenOff { get; set; }

    /// <summary>The list of user submitted changes.</summary>
    [JsonProperty("user_submits"), JsonPropertyName("user_submits")]
    public ResultList<UserSubmit> UserSubmits { get; set; }
  }
}

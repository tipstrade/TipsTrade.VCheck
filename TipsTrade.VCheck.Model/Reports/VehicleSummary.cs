using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace TipsTrade.VCheck.Model.Reports {
  /// <summary>The vehicle summary.</summary>
  public class VehicleSummary {
    /// <summary>A flag indicating whether fuel running cost is available.</summary>
    [JsonProperty("has_fuel_running_costs"), JsonPropertyName("has_fuel_running_costs")]
    public bool HasFuelRunningCosts { get; set; }

    /// <summary>A flag indicating whether mileage issues are available.</summary>
    [JsonProperty("has_mileage_issues"), JsonPropertyName("has_mileage_issues")]
    public bool HasMileageIssues { get; set; }

    /// <summary>A flag indicating whether MOT history is available.</summary>
    [JsonProperty("has_mot_history"), JsonPropertyName("has_mot_history")]
    public bool HasMotHistory { get; set; }

    /// <summary>A flag indicating whether VED costs are available.</summary>
    [JsonProperty("has_road_tax_costs"), JsonPropertyName("has_road_tax_costs")]
    public bool HasVedCosts { get; set; }

    /// <summary>A flag indicating whether salvage auction data is available.</summary>
    [JsonProperty("has_salvage_auctions"), JsonPropertyName("has_salvage_auctions")]
    public bool HasSalvageAuctions { get; set; }

    /// <summary>A flag indicating whether the vehicle has mileage issues.</summary>
    [JsonProperty("has_summary_issues"), JsonPropertyName("has_summary_issues")]
    public bool HasSummaryIssues { get; set; }

    /// <summary>A flag indicating whether the vehicle technical specification is available.</summary>
    [JsonProperty("has_technical_specification"), JsonPropertyName("has_technical_specification")]
    public bool HasTechnicalSpecification { get; set; }

    /// <summary>A flag indicating whether an user data has been submitted.</summary>
    [JsonProperty("has_user_submits"), JsonPropertyName("has_user_submits")]
    public bool HasUserSubmits { get; set; }

    /// <summary>A flag indicating whether the vehicle ancestory is available.</summary>
    [JsonProperty("has_vehicle_ancestry"), JsonPropertyName("has_vehicle_ancestry")]
    public bool HasVehicleAncestory { get; set; }

    /// <summary>A flag indicating whether the vehicle has been exported.</summary>
    [JsonProperty("is_export"), JsonPropertyName("is_export")]
    public bool IsExport { get; set; }

    /// <summary>A flag indicating whether the vehicle has been imported.</summary>
    [JsonProperty("is_import"), JsonPropertyName("is_import")]
    public bool IsImport { get; set; }

    /// <summary>A flag indicating whether the vehicle's MOT is valid.</summary>
    [JsonProperty("is_mot_valid"), JsonPropertyName("is_mot_valid")]
    public bool IsMotValid { get; set; }

    /// <summary>A flag indicating whether the vehicle has been scrapped.</summary>
    [JsonProperty("is_scrapped"), JsonPropertyName("is_scrapped")]
    public bool IsScrapped { get; set; }

    /// <summary>A flag indicating whether ultra-low emission zone charges are payable.</summary>
    [JsonProperty("is_ulez_payable"), JsonPropertyName("is_ulez_payable")]
    public bool IsUlezPayable { get; set; }

    /// <summary>A flag indicating whether the vehicle's VED is valid.</summary>
    [JsonProperty("is_road_tax_valid"), JsonPropertyName("is_road_tax_valid")]
    public bool IsVedValid { get; set; }

    /// <summary>The number of previous keepers.</summary>
    [JsonProperty("previous_keepers"), JsonPropertyName("previous_keepers")]
    public bool PreviousKeepers { get; set; }

    /// <summary>The number of VRM changes.</summary>
    [JsonProperty("number_plate_changes"), JsonPropertyName("number_plate_changes")]
    public int VrmChanges { get; set; }
  }
}

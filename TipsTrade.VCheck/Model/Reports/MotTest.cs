using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace TipsTrade.VCheck.Model.Reports {
  /// <summary>An MOT test result.</summary>
  public class MotTest {
    /// <summary>The list of MOT test comments.</summary>
    [JsonProperty("comments")]
    public IEnumerable<MotComment> Comments { get; set; }

    /// <summary>The date one which the MOT test was completed.</summary>
    [JsonProperty("completed_date")]
    public DateTime? CompletedDate { get; set; }

    /// <summary>The date one which the MOT test expires.</summary>
    [JsonProperty("expiry_date")]
    public DateTime? ExpiryDate { get; set; }

    /// <summary>The MOT test number.</summary>
    [JsonProperty("mot_test_number")]
    public string MotTestNumber { get; set; }

    /// <summary>The description of the odometer reading.</summary>
    [JsonProperty("odometer_result_type")]
    public string OdometerResultType { get; set; }

    /// <summary>The distance units on the odometer.</summary>
    [JsonProperty("odometer_unit")]
    public string OdometerUnit { get; set; }

    /// <summary>The value on the odometer at the time of the test.</summary>
    [JsonProperty("odometer_value")]
    public int? OdometerValue { get; set; }

    /// <summary>The MOT test result.</summary>
    [JsonProperty("test_result")]
    public string TestResult { get; set; }
  }
}

﻿using Newtonsoft.Json;
using System;

namespace TipsTrade.VCheck.Model.Reports {
  /// <summary>A vehicle VRM change record.</summary>
  public class VrmChange : IVrm {
    /// <summary>The date on which the VRM was assigned.</summary>
    [JsonProperty("assignment_date")]
    public DateTime? AssignmentDate { get; set; }

    /// <summary>The VRM of the vehicle.</summary>
    [JsonProperty("vrm")]
    public string Vrm { get; set; }

    /// <summary>Returns a string that represents the current object.</summary>
    public override string ToString() {
      return $"VRM changed to {Vrm} on {AssignmentDate?.ToString("d") ?? "unknown"}";
    }
  }
}

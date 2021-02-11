using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using TipsTrade.VCheck.Model.Reports;

namespace Tests {
  public class Mocks {
    /// <summary>A collection of VRM VIN pairs.</summary>
    public Dictionary<string, string> Vrms { get; set; }

    /// <summary>A list of invalid report references.</summary>
    public IEnumerable<string> Invalid { get; set; }

    /// <summary>A list of valid report references.</summary>
    public IEnumerable<string> Valid { get; set; }

    public static string GetReportJson(string id) {
      var name = Path.Combine("Mocks", $"{id}.json");

      using (var fs = new FileStream(name, FileMode.Open, FileAccess.Read)) {
        using (var reader = new StreamReader(fs)) {
          return reader.ReadToEnd();
        }
      }
    }

    private static T GetReport<T>(string id) where T : new() {
      return JsonConvert.DeserializeObject<T>(GetReportJson(id));
    }

    public static Report GetReport(string id) {
      return GetReport<Report>(id);
    }

    public static JObject GetReportObject(string id) {
      return GetReport<JObject>(id);
    }
  }
}

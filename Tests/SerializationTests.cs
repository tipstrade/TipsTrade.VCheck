using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using TipsTrade.VCheck.Model.Reports;

namespace Tests {
  public class SerializationTests : TestBase {
    private void AssertAreEqual<T>(JObject expected, string path, T actual) {
      Assert.AreEqual(expected.SelectToken(path).Value<T>(), actual);
    }

    [Test(Description = "Report should deserialize.")]
    public void DeserializeReportSucceeds() {
      var id = Mocks.Valid.First();
      var expected = Mocks.GetReportObject(id);
      var actual = Mocks.GetReport(id);

      Assert.NotNull(actual);
      Assert.NotNull(actual.Mot);
      Assert.NotNull(actual.Ved);
      Assert.NotNull(actual.VehicleDetails);
      Assert.NotNull(actual.VehicleHistory);
      Assert.NotNull(actual.FuelCosts);
      Assert.NotNull(actual.TechnicalSpecification);
      Assert.NotNull(actual.Ulez);
      Assert.NotNull(actual.Summary);
      Assert.NotNull(actual.CheckDetails);

      AssertAreEqual(expected, "check_details.check_type", actual.CheckDetails.CheckType);
      AssertAreEqual(expected, "check_details.check_date", actual.CheckDetails.CheckDate);
      AssertAreEqual(expected, "check_details.check_reference", actual.CheckDetails.CheckReference);
      AssertAreEqual(expected, "check_details.user", actual.CheckDetails.User);
      AssertAreEqual(expected, "check_details.url", actual.CheckDetails.Url);
    }

    [Test(Description = "All reports in the custom path should deserialize.")]
    public void DeserializeReportsSucceeds() {
      var customPath = Configuration["CustomMocksPath"];
      var path = customPath == null ? null : new DirectoryInfo(customPath);

      if (path == null || !path.Exists) {
        Assert.Inconclusive("Custom mocks directory has not be provided, or does not exist.");
      }

      foreach (var file in path.GetFiles()) {
        using (var reader = new StreamReader(file.OpenRead())) {
          var json = reader.ReadToEnd();

          var report = JsonConvert.DeserializeObject<Report>(json);
        }
      }
    }
  }
}

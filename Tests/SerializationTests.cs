using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System.IO;
using System.Linq;
using TipsTrade.VCheck.Model.Reports;

namespace Tests {
  public class SerializationTests : VCheckFixture<DummyCredentialsProvider> {
    private static void AssertAreEqual<T>(JObject expected, string path, T actual) {
      Assert.That(actual, Is.EqualTo(expected.SelectToken(path).Value<T>()));
    }

    [Test(Description = "Unserializable should deserialize.")]
    public void DeserializeUnserializableSucceeds() {
      var actual = Mocks.GetReport("Unserializable");

      Assert.That(actual, Is.Not.Null);
    }

    [Test(Description = "Report should deserialize.")]
    public void DeserializeReportSucceeds() {
      var id = Mocks.Valid.First();
      var expected = Mocks.GetReportObject(id);
      var actual = Mocks.GetReport(id);

      Assert.That(actual, Is.Not.Null);
      Assert.That(actual.Mot, Is.Not.Null);
      Assert.That(actual.Ved, Is.Not.Null);
      Assert.That(actual.VehicleDetails, Is.Not.Null);
      Assert.That(actual.VehicleHistory, Is.Not.Null);
      Assert.That(actual.FuelCosts, Is.Not.Null);
      Assert.That(actual.TechnicalSpecification, Is.Not.Null);
      Assert.That(actual.Ulez, Is.Not.Null);
      Assert.That(actual.Summary, Is.Not.Null);
      Assert.That(actual.CheckDetails, Is.Not.Null);

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
        using var reader = new StreamReader(file.OpenRead());
        var json = reader.ReadToEnd();

        var report = JsonConvert.DeserializeObject<Report>(json);

        Assert.That(report, Is.Not.Null);
      }
    }
  }
}

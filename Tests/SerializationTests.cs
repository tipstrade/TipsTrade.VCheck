using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using System.IO;
using System.Linq;
using TipsTrade.VCheck.Model.Reports;

namespace Tests {
  public class SerializationTests {
    private IConfiguration Configuration { get; set; }
    private TestData TestData { get; set; }

    [OneTimeSetUp]
    public void OneTimeSetUp() {
      Configuration = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json")
        .Build();

      TestData = Configuration.GetSection("TestData").Get<TestData>() ?? throw new InvalidOperationException("No TestData available");
    }

    private static void AssertAreEqual<T>(JObject? expected, string path, T? actual) {
      var selected = expected?.SelectToken(path);
      T? expectedValue = selected == null ? default : selected.Value<T>();

      Assert.That(actual, Is.EqualTo(expectedValue));
    }

    [Test(Description = "Unserializable should deserialize.")]
    public void DeserializeUnserializableSucceeds() {
      var actual = TestData.GetReport("Unserializable");

      Assert.That(actual, Is.Not.Null);

      // Previous keepers used to be a boolean, but now is an int. This test ensures that the converter correctly converts the boolean value to an int.
      Assert.That(actual?.Summary?.PreviousKeepers, Is.EqualTo(1));
    }

    [Test(Description = "Report should deserialize.")]
    public void DeserializeReportSucceeds() {
      var id = TestData.Valid.First();
      var expected = TestData.GetReportObject(id);
      var actual = TestData.GetReport(id);

      Assert.That(actual, Is.Not.Null);
      Assert.That(actual?.Mot, Is.Not.Null);
      Assert.That(actual?.Ved, Is.Not.Null);
      Assert.That(actual?.VehicleDetails, Is.Not.Null);
      Assert.That(actual?.VehicleHistory, Is.Not.Null);
      Assert.That(actual?.FuelCosts, Is.Not.Null);
      Assert.That(actual?.TechnicalSpecification, Is.Not.Null);
      Assert.That(actual?.Ulez, Is.Not.Null);
      Assert.That(actual?.Summary, Is.Not.Null);
      Assert.That(actual?.CheckDetails, Is.Not.Null);

      AssertAreEqual(expected, "check_details.check_type", actual?.CheckDetails?.CheckType);
      AssertAreEqual(expected, "check_details.check_date", actual?.CheckDetails?.CheckDate);
      AssertAreEqual(expected, "check_details.check_reference", actual?.CheckDetails?.CheckReference);
      AssertAreEqual(expected, "check_details.user", actual?.CheckDetails?.User);
      AssertAreEqual(expected, "check_details.url", actual?.CheckDetails?.Url);
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

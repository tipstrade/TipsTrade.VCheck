using System.Text.Json;
using NUnit.Framework;
using TipsTrade.VCheck.Model.Reports;

namespace Tests.JsonConverterTests {
  [TestFixture]
  public class JsonSerializationSystemTextJsonTests {
    [Test]
    public void Deserialize_Stj_PreviousKeepers_NumberProducesSameInt() {
      var json = @"{ ""previous_keepers"": 5 }";

      var stj = JsonSerializer.Deserialize<VehicleSummary>(json);

      Assert.That(stj, Is.Not.Null);
      Assert.That(stj?.PreviousKeepers, Is.EqualTo(5));
    }

    [Test]
    public void Deserialize_Stj_PreviousKeepers_NumericStringParsesToInt() {
      var json = @"{ ""previous_keepers"": ""42"" }";

      var stj = JsonSerializer.Deserialize<VehicleSummary>(json);

      Assert.That(stj, Is.Not.Null);
      Assert.That(stj?.PreviousKeepers, Is.EqualTo(42));
    }

    [Test]
    public void Deserialize_Stj_PreviousKeepers_Boolean() {
      var jsonTrue = @"{ ""previous_keepers"": true }";
      var jsonFalse = @"{ ""previous_keepers"": false }";

      var stjTrue = JsonSerializer.Deserialize<VehicleSummary>(jsonTrue);
      var stjFalse = JsonSerializer.Deserialize<VehicleSummary>(jsonFalse);

      Assert.That(stjTrue?.PreviousKeepers, Is.EqualTo(1));
      Assert.That(stjFalse?.PreviousKeepers, Is.EqualTo(0));
    }

    [Test]
    public void Deserialize_Stj_PreviousKeepers_InvalidStringThrows() {
      Assert.Throws<JsonException>(() => JsonSerializer.Deserialize<VehicleSummary>(@"{ ""previous_keepers"": ""invalid"" }"));
    }

    [Test]
    public void Deserialize_Stj_PreviousKeepers_NullThrows() {
      Assert.Throws<JsonException>(() => JsonSerializer.Deserialize<VehicleSummary>(@"{ ""previous_keepers"": null }"));
    }

    [Test]
    public void Serialize_Stj_PreviousKeepers_WritesNumberToken() {
      var summary = new VehicleSummary { PreviousKeepers = 7 };

      var stjJson = JsonSerializer.Serialize(summary);

      using var doc = JsonDocument.Parse(stjJson);
      var root = doc.RootElement;
      Assert.That(root.GetProperty("previous_keepers").ValueKind, Is.EqualTo(JsonValueKind.Number));
      Assert.That(root.GetProperty("previous_keepers").GetInt32(), Is.EqualTo(7));
    }
  }
}
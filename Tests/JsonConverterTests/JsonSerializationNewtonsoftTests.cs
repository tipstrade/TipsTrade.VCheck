using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using TipsTrade.VCheck.Model.Reports;

namespace Tests.JsonConverterTests {
  [TestFixture]
  public class JsonSerializationNewtonsoftTests {
    [Test]
    public void Deserialize_Ns_PreviousKeepers_NumberProducesSameInt() {
      var json = @"{ ""previous_keepers"": 5 }";

      var ns = JsonConvert.DeserializeObject<VehicleSummary>(json);

      Assert.That(ns, Is.Not.Null);
      Assert.That(ns?.PreviousKeepers, Is.EqualTo(5));
    }

    [Test]
    public void Deserialize_Ns_PreviousKeepers_NumericStringParsesToInt() {
      var json = @"{ ""previous_keepers"": ""42"" }";

      var ns = JsonConvert.DeserializeObject<VehicleSummary>(json);

      Assert.That(ns, Is.Not.Null);
      Assert.That(ns?.PreviousKeepers, Is.EqualTo(42));
    }

    [Test]
    public void Deserialize_Ns_PreviousKeepers_Boolean() {
      var jsonTrue = @"{ ""previous_keepers"": true }";
      var jsonFalse = @"{ ""previous_keepers"": false }";

      var nsTrue = JsonConvert.DeserializeObject<VehicleSummary>(jsonTrue);
      var nsFalse = JsonConvert.DeserializeObject<VehicleSummary>(jsonFalse);

      Assert.That(nsTrue?.PreviousKeepers, Is.EqualTo(1));
      Assert.That(nsFalse?.PreviousKeepers, Is.EqualTo(0));
    }

    [Test]
    public void Deserialize_Ns_PreviousKeepers_InvalidStringThrows() {
      Assert.Throws<JsonSerializationException>(() => JsonConvert.DeserializeObject<VehicleSummary>(@"{ ""previous_keepers"": ""invalid"" }"));
    }

    [Test]
    public void Deserialize_Ns_PreviousKeepers_NullThrows() {
      Assert.Throws<JsonSerializationException>(() => JsonConvert.DeserializeObject<VehicleSummary>(@"{ ""previous_keepers"": null }"));
    }

    [Test]
    public void Serialize_Ns_PreviousKeepers_WritesNumberToken() {
      var summary = new VehicleSummary { PreviousKeepers = 7 };

      var nsJson = JsonConvert.SerializeObject(summary);

      var nsJObj = JObject.Parse(nsJson);
      Assert.That(nsJObj["previous_keepers"]?.Type, Is.EqualTo(JTokenType.Integer));
      Assert.That(nsJObj["previous_keepers"]?.Value<int>(), Is.EqualTo(7));
    }
  }
}
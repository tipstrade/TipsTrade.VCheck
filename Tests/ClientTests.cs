using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Tests.Providers;
using TipsTrade.VCheck;

namespace Tests {
  public class ClientTests : VCheckFixture<CredentialsProvider> {
    #region Properties
    private VCheckClient Client { get; set; }
    #endregion

    [SetUp]
    public void Setup() {
      Client = ServiceProvider
        .CreateScope()
        .ServiceProvider
        .GetRequiredService<VCheckService>()
        .Client;
    }

    [Test(Description = "The API version is correct.")]
    public void ApiVersion() {
      Assert.That(VCheckClient.ApiVersion, Is.EqualTo(Mocks.Version));
    }

    [Test(Description = "CreateReportByVinAsync succeeds for valid VIN.")]
    [Ignore("Ignored as it costs money.")]
    public async Task CreateReportByVinAsyncSucceeds() {
      var (vrm, vin) = Mocks.Vrms.First();
      var actual = await Client.CreateReportByVinAsync(vin, CheckType.Initial);

      Assert.That(actual, Is.Not.Null);
      Assert.That(actual.VehicleDetails.Vrm, Is.EqualTo(vrm));
      Assert.That(actual.VehicleDetails.Vin, Is.EqualTo(vin));
    }

    [Test(Description = "CreateReportByVrmAsync succeeds for valid VRM.")]
    [Ignore("Ignored as it costs money.")]
    public async Task CreateReportByVrmAsyncSucceeds() {
      var (vrm, vin) = Mocks.Vrms.First();
      var actual = await Client.CreateReportByVrmAsync(vrm, CheckType.Initial);

      Assert.That(actual, Is.Not.Null);
      Assert.That(actual.VehicleDetails.Vrm, Is.EqualTo(vrm));
      Assert.That(actual.VehicleDetails.Vin, Is.EqualTo(vin));
    }

    [Test(Description = "CreateReportByVinAsync throws for blank or null VIN.")]
    public void CreateReportByVinAsyncThrowsForVm() {
      ArgumentException ex;

      ex = Assert.ThrowsAsync<ArgumentNullException>(() => Client.CreateReportByVinAsync(Vrms.Null, CheckType.Initial));
      Assert.That(ex.ParamName, Is.EqualTo("vin"));

      ex = Assert.ThrowsAsync<ArgumentException>(() => Client.CreateReportByVinAsync(Vrms.Empty, CheckType.Initial));
      Assert.That(ex.ParamName, Is.EqualTo("vin"));

      ex = Assert.ThrowsAsync<ArgumentException>(() => Client.CreateReportByVinAsync(Vrms.Whitespace, CheckType.Initial));
      Assert.That(ex.ParamName, Is.EqualTo("vin"));
    }

    [Test(Description = "CreateReportByVrmAsync throws for blank or null VRM.")]
    public void CreateReportByVrmAsyncThrows() {
      ArgumentException ex;

      ex = Assert.ThrowsAsync<ArgumentNullException>(() => Client.CreateReportByVrmAsync(null, CheckType.Initial));
      Assert.That(ex.ParamName, Is.EqualTo("vrm"));

      ex = Assert.ThrowsAsync<ArgumentException>(() => Client.CreateReportByVrmAsync(" ", CheckType.Initial));
      Assert.That(ex.ParamName, Is.EqualTo("vrm"));

      ex = Assert.ThrowsAsync<ArgumentException>(() => Client.CreateReportByVrmAsync("", CheckType.Initial));
      Assert.That(ex.ParamName, Is.EqualTo("vrm"));
    }

    //[Test(Description = "Endpoint throws ApiException for an invalid API key.")]
    //public void EndpointInvalidApiKeyThrows() {
    //  var ex = Assert.ThrowsAsync<ApiException>(() => Client.ViewReportAsync(Mocks.Valid.First()));
    //  Assert.AreEqual(HttpStatusCode.Unauthorized, ex.StatusCode);
    //  Assert.NotNull(ex.Error);
    //  Assert.NotNull(ex.Error.Detail);
    //}

    //[Test(Description = "Endpoint throws TaskCanceledException when timing out.")]
    //public void EndpointTimeoutThrows() {
    //  Client.Timeout = new TimeSpan(1);

    //  var ex = Assert.ThrowsAsync<TaskCanceledException>(() => Client.ViewReportAsync(Mocks.Invalid.First()));
    //}

    [Test(Description = "ViewReportAsync succeeds for valid ID.")]
    public async Task ViewReportAsyncSucceeds() {
      var id = Mocks.Valid.First();
      var actual = await Client.ViewReportAsync(id);

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
    }

    [Test(Description = "ViewReportAsync throws ApiException for invalid ID.")]
    public void ViewReportAsyncThrows() {
      var ex = Assert.ThrowsAsync<ApiException>(() => Client.ViewReportAsync(Mocks.Invalid.First()));

      Assert.That(ex.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
      Assert.That(ex.Error, Is.Not.Null);
      Assert.That(ex.Error.Detail, Is.Not.Null);
    }
  }
}

﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using TipsTrade.VCheck;

namespace Tests {
  public class ClientTests : TestBase {
    #region Properties
    private VCheckClient Client { get; set; }
    #endregion

    [SetUp]
    public void Setup() {
      Client = new VCheckClient(ApiKey);
    }

    [Test(Description = "The API version is correct.")]
    public void ApiVersion() {
      Assert.AreEqual("2.1", VCheckClient.ApiVersion);
    }

    [Test(Description = "The constructor throws ArgumentNullException.")]
    public void ClientConstructorThrows() {
      Assert.Throws<ArgumentNullException>(() => new VCheckClient(null));
    }

    [Test(Description = "CreateReportAsync succeeds for valid VRM.")]
    [Ignore("Ignored as it costs money.")]
    public async Task CreateReportAsyncSucceeds() {
      var (vrm, vin) = Mocks.Vrms.First();
      var actual = await Client.CreateReportAsync(vrm, CheckType.Initial);

      Assert.NotNull(actual);
      Assert.AreEqual(vrm, actual.VehicleDetails.Vrm);
      Assert.AreEqual(vin, actual.VehicleDetails.Vin);
    }

    [Test(Description = "CreateReportByVinAsync succeeds for valid VIN.")]
    [Ignore("Ignored as it costs money.")]
    public async Task CreateReportByVinAsyncSucceeds() {
      var (vrm, vin) = Mocks.Vrms.First();
      var actual = await Client.CreateReportByVinAsync(vin, CheckType.Initial);

      Assert.NotNull(actual);
      Assert.AreEqual(vrm, actual.VehicleDetails.Vrm);
      Assert.AreEqual(vin, actual.VehicleDetails.Vin);
    }

    [Test(Description = "CreateReportByVrmAsync succeeds for valid VIN.")]
    [Ignore("Ignored as it costs money.")]
    public async Task CreateReportByVrmAsyncSucceeds() {
      var (vrm, vin) = Mocks.Vrms.First();
      var actual = await Client.CreateReportByVrmAsync(vrm, CheckType.Initial);

      Assert.NotNull(actual);
      Assert.AreEqual(vrm, actual.VehicleDetails.Vrm);
      Assert.AreEqual(vin, actual.VehicleDetails.Vin);
    }

    [Test(Description = "CreateReportAsync throws for blank or null VRM.")]
    public void CreateReportAsyncThrows() {
      Assert.ThrowsAsync<ArgumentNullException>(() => Client.CreateReportAsync(null, CheckType.Initial));
      Assert.ThrowsAsync<ArgumentException>(() => Client.CreateReportAsync(" ", CheckType.Initial));
      Assert.ThrowsAsync<ArgumentException>(() => Client.CreateReportAsync("", CheckType.Initial));
    }

    [Test(Description = "CreateReportByVinAsync throws for blank or null VIN.")]
    public void CreateReportByVinAsyncThrows() {
      Assert.ThrowsAsync<ArgumentNullException>(() => Client.CreateReportByVinAsync(null, CheckType.Initial));
      Assert.ThrowsAsync<ArgumentException>(() => Client.CreateReportByVinAsync(" ", CheckType.Initial));
      Assert.ThrowsAsync<ArgumentException>(() => Client.CreateReportByVinAsync("", CheckType.Initial));
    }

    [Test(Description = "CreateReportByVrmAsync throws for blank or null VRM.")]
    public void CreateReportByVrmAsyncThrows() {
      Assert.ThrowsAsync<ArgumentNullException>(() => Client.CreateReportByVrmAsync(null, CheckType.Initial));
      Assert.ThrowsAsync<ArgumentException>(() => Client.CreateReportByVrmAsync(" ", CheckType.Initial));
      Assert.ThrowsAsync<ArgumentException>(() => Client.CreateReportByVrmAsync("", CheckType.Initial));
    }

    [Test(Description = "Endpoint throws ApiException for an invalid API key.")]
    public void EndpointInvalidApiKeyThrows() {
      Client.ApiKey = "INVALID";

      var ex = Assert.ThrowsAsync<ApiException>(() => Client.ViewReportAsync(Mocks.Valid.First()));
      Assert.AreEqual(HttpStatusCode.Unauthorized, ex.StatusCode);
      Assert.NotNull(ex.Error);
      Assert.NotNull(ex.Error.Detail);
    }

    [Test(Description = "Endpoint throws TaskCanceledException when timing out.")]
    public void EndpointTimeoutThrows() {
      Client.Timeout = new TimeSpan(1);

      var ex = Assert.ThrowsAsync<TaskCanceledException>(() => Client.ViewReportAsync(Mocks.Invalid.First()));
    }

    [Test(Description = "ViewReportAsync succeeds for valid ID.")]
    public async Task ViewReportAsyncSucceeds() {
      var id = Mocks.Valid.First();
      var expected = JsonConvert.DeserializeObject(Mocks.GetReportJson(id)) as JObject;
      var actual = await Client.ViewReportAsync(id);

      Assert.NotNull(actual);
    }

    [Test(Description = "ViewReportAsync throws ApiException for invalid ID.")]
    public void ViewReportAsyncThrows() {
      var ex = Assert.ThrowsAsync<ApiException>(() => Client.ViewReportAsync(Mocks.Invalid.First()));

      Assert.AreEqual(HttpStatusCode.NotFound, ex.StatusCode);
      Assert.NotNull(ex.Error);
      Assert.NotNull(ex.Error.Detail);
    }
  }
}

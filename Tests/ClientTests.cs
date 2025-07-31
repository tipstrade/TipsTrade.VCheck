//using Microsoft.Extensions.DependencyInjection;
//using NUnit.Framework;
//using System;
//using System.Linq;
//using System.Net;
//using System.Runtime.Intrinsics.X86;
//using System.Threading.Tasks;
//using Tests.Providers;
//using TipsTrade.ApiClient.Core.Error;
//using TipsTrade.VCheck;

//namespace Tests {
//  public class ClientTests : VCheckFixture<CredentialsProvider> {
//    #region Properties
//    private VCheckClient Client { get; set; } = null!;
//    #endregion

//    [SetUp]
//    public void Setup() {
//      Client = ServiceProvider
//        .CreateScope()
//        .ServiceProvider
//        .GetRequiredService<VCheckService>()
//        .Client;
//    }

//    [Test(Description = "The API version is correct.")]
//    public void ApiVersion() {
//      Assert.That(VCheckClient.ApiVersion, Is.EqualTo(Mocks.Version));
//    }

//    [Test(Description = "CreateReportByVinAsync succeeds for valid VIN.")]
//    [Ignore("Ignored as it costs money.")]
//    public async Task CreateReportByVinAsync_Succeeds() {
//      var (vrm, vin) = Mocks.Vrms.First();
//      var actual = await Client.CreateReportByVinAsync(vin, CheckType.Initial);

//      Assert.That(actual, Is.Not.Null);
//      Assert.That(actual?.VehicleDetails?.Vrm, Is.EqualTo(vrm));
//      Assert.That(actual?.VehicleDetails?.Vin, Is.EqualTo(vin));
//    }

//    [Test(Description = "CreateReportByVrmAsync succeeds for valid VRM.")]
//    [Ignore("Ignored as it costs money.")]
//    public async Task CreateReportByVrmAsync_Succeeds() {
//      var (vrm, vin) = Mocks.Vrms.First();
//      var actual = await Client.CreateReportByVrmAsync(vrm, CheckType.Initial);

//      Assert.That(actual, Is.Not.Null);
//      Assert.That(actual?.VehicleDetails?.Vrm, Is.EqualTo(vrm));
//      Assert.That(actual?.VehicleDetails?.Vin, Is.EqualTo(vin));
//    }

//    [Test(Description = "CreateReportByVinAsync throws for blank or null VIN.")]
//    public void CreateReportByVinAsync_Throws() {
//      ArgumentException? ex;

//      ex = Assert.ThrowsAsync<ArgumentNullException>(() => Client.CreateReportByVinAsync(Vins.Null, CheckType.Initial));
//      Assert.That(ex?.ParamName, Is.EqualTo("vin"));

//      ex = Assert.ThrowsAsync<ArgumentException>(() => Client.CreateReportByVinAsync(Vins.Empty, CheckType.Initial));
//      Assert.That(ex?.ParamName, Is.EqualTo("vin"));

//      ex = Assert.ThrowsAsync<ArgumentException>(() => Client.CreateReportByVinAsync(Vins.Whitespace, CheckType.Initial));
//      Assert.That(ex?.ParamName, Is.EqualTo("vin"));
//    }

//    [Test(Description = "CreateReportByVrmAsync throws for blank or null VRM.")]
//    public void CreateReportByVrmAsync_Throws() {
//      ArgumentException? ex;

//      ex = Assert.ThrowsAsync<ArgumentNullException>(() => Client.CreateReportByVrmAsync(Vrms.Null, CheckType.Initial));
//      Assert.That(ex?.ParamName, Is.EqualTo("vrm"));

//      ex = Assert.ThrowsAsync<ArgumentException>(() => Client.CreateReportByVrmAsync(Vrms.Empty, CheckType.Initial));
//      Assert.That(ex?.ParamName, Is.EqualTo("vrm"));

//      ex = Assert.ThrowsAsync<ArgumentException>(() => Client.CreateReportByVrmAsync(Vrms.Whitespace, CheckType.Initial));
//      Assert.That(ex?.ParamName, Is.EqualTo("vrm"));
//    }

//    //[Test(Description = "Endpoint throws ApiException for an invalid API key.")]
//    //public void EndpointInvalidApiKeyThrows() {
//    //  var ex = Assert.ThrowsAsync<ApiException>(() => Client.ViewReportAsync(Mocks.Valid.First()));
//    //  Assert.AreEqual(HttpStatusCode.Unauthorized, ex.StatusCode);
//    //  Assert.NotNull(ex.Error);
//    //  Assert.NotNull(ex.Error.Detail);
//    //}

//    //[Test(Description = "Endpoint throws TaskCanceledException when timing out.")]
//    //public void EndpointTimeoutThrows() {
//    //  Client.Timeout = new TimeSpan(1);

//    //  var ex = Assert.ThrowsAsync<TaskCanceledException>(() => Client.ViewReportAsync(Mocks.Invalid.First()));
//    //}

//    [Test(Description = "ViewReportAsync succeeds for valid ID.")]
//    public async Task ViewReportAsync_Succeeds() {
//      var id = Mocks.Valid.First();
//      var actual = await Client.ViewReportAsync(id);

//      Assert.That(actual, Is.Not.Null);
//      Assert.That(actual?.Mot, Is.Not.Null);
//      Assert.That(actual?.Ved, Is.Not.Null);
//      Assert.That(actual?.VehicleDetails, Is.Not.Null);
//      Assert.That(actual?.VehicleHistory, Is.Not.Null);
//      Assert.That(actual?.FuelCosts, Is.Not.Null);
//      Assert.That(actual?.TechnicalSpecification, Is.Not.Null);
//      Assert.That(actual?.Ulez, Is.Not.Null);
//      Assert.That(actual?.Summary, Is.Not.Null);
//      Assert.That(actual?.CheckDetails, Is.Not.Null);
//    }

//    [Test(Description = "ViewReportAsync throws ApiException for invalid ID.")]
//    public void ViewReportAsync_Throws() {
//      var ex = Assert.ThrowsAsync<ApiException>(async () => await Client.ViewReportAsync(Mocks.Invalid.First()));
//      var error = ex?.GetError<ErrorResponse>();

//      Assert.That(ex?.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
//      Assert.That(error, Is.Not.Null);
//      Assert.That(error?.Detail, Is.Not.Null);
//    }
//  }
//}

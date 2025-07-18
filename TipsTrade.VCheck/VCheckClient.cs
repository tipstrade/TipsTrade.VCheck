using Microsoft.Extensions.Logging;
using RestSharp;
using RestSharp.Interceptors;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using TipsTrade.VCheck.Model.Reports;
using TipsTrade.VCheck.Model.Reports.History;

namespace TipsTrade.VCheck {
  /// <summary>
  /// A client for accessing the VCheck REST API.
  /// <para>See <see href="https://api.vcheck.uk/documentation/"/></para>
  /// </summary>
  public class VCheckClient {
    #region Fields
    /// <summary>The API version for which the <see cref="VCheckClient"/> was written.</summary>
    public static readonly string ApiVersion = "2.1";

    private static readonly string BaseUrl = "https://api.vcheck.uk/";

    private readonly RestClient restClient;
    private readonly ILogger? logger;
    #endregion

    #region Constructors
    /// <summary>Creates an instance of the <see cref="VCheckClient"/> class.</summary>
    public VCheckClient(
      ICredentialsProvider credentialsProvider,
      HttpClient? httpClient = null,
      ITennantProvider? tennantProvider = null,
      ILogger? logger = null
      ) {
      restClient = new RestClient(
        httpClient: httpClient ?? new HttpClient(),
        options: new RestClientOptions {
          BaseUrl = new Uri(BaseUrl),
          Interceptors = new List<Interceptor> { new ApiKeyInterceptor(credentialsProvider, logger, tennantProvider) }
        });
      this.logger = logger;
    }
    #endregion

    #region Methods
    private async Task<T?> ExecuteRequestAsync<T>(RestRequest request) where T : class {
      var resp = await restClient.ExecuteAsync<T>(request);

      if (!resp.IsSuccessful) {
        ErrorResponse? error = null;

        if (resp.Content != null) {
          try {
            error = JsonSerializer.Deserialize<ErrorResponse>(resp.Content);
          } catch (Exception ex) {
            logger?.LogError("Unable to parse ErrorResponse: {message}", ex.Message);
          }
        }

        var message = error?.Detail ??
          resp.ErrorMessage ??
          resp.ErrorException?.Message ??
          "The API returned an unexpected error.";

        throw new ApiException(message, resp.ErrorException) {
          StatusCode = resp.StatusCode,
          Error = error
        };
      }

      return resp.Data;
    }

    /// <summary>Gets a report.</summary>
    /// <param name="vin">The VIN of the vehicle.</param>
    /// <param name="checkType">The type of vheck to create.</param>
    public Task<Report?> CreateReportByVinAsync(string vin, CheckType checkType) {
      ValidateVin(ref vin);

      return CreateReportAsync(checkType, vin: vin);
    }

    /// <summary>Gets a report.</summary>
    /// <param name="vrm">The VRM of the vehicle.</param>
    /// <param name="checkType">The type of vheck to create.</param>
    public Task<Report?> CreateReportByVrmAsync(string vrm, CheckType checkType) {
      ValidateVrm(ref vrm);

      return CreateReportAsync(checkType, vrm: vrm);
    }

    /// <summary>Gets a report.</summary>
    /// <param name="checkType">The type of vheck to create.</param>
    /// <param name="vrm">The VRM of the vehicle.</param>
    /// <param name="vin">The VIN of the vehicle.</param>
    private Task<Report?> CreateReportAsync(CheckType checkType, string? vrm = null, string? vin = null) {
      var request = new RestRequest("/report/create")
         .AddQueryParameter("check_type", (int)checkType)
         ;

      if (vrm != null) {
        request.AddQueryParameter("vrm", vrm);
      } else if (vin != null) {
        request.AddQueryParameter("vin  ", vin);
      }

      return ExecuteRequestAsync<Report>(request);
    }

    /// <summary>Gets the salvage records for the vehicle.</summary>
    /// <param name="vrm">The VRM of the vehicle.</param>
    /// <param name="vin">The optioanal VIN of the vehicle.</param>
    public Task<IEnumerable<SalvageAuction>> GetSalvageRecordsAsync(string vrm, string? vin = null) {
      return GetSalvageRecordsAsync(new string[] { vrm }, vin);
    }

    /// <summary>Gets the salvage records for the vehicle.</summary>
    /// <param name="vrm">The list of VRMs of the vehicle.</param>
    /// <param name="vin">The optioanal VIN of the vehicle.</param>
    public Task<IEnumerable<SalvageAuction>> GetSalvageRecordsAsync(IEnumerable<string> vrm, string? vin = null) {
      throw new NotImplementedException();
    }

    /// <summary>Views an existing report.</summary>
    /// <param name="reference">The unique reference of the report.</param>
    public Task<Report?> ViewReportAsync(string reference) {
      var request = new RestRequest("/report/view").AddQueryParameter("reference", reference);

      return ExecuteRequestAsync<Report>(request);
    }
    #endregion

    #region Static methods
    internal static void ValidateVin(ref string vin) {
      vin = vin?.Replace(" ", "") ?? throw new ArgumentNullException(nameof(vin));

      if (vin == "") {
        throw new ArgumentException("VIN cannot be an empty string.", nameof(vin));
      }
    }

    internal static void ValidateVrm(ref string vrm) {
      vrm = vrm?.Replace(" ", "") ?? throw new ArgumentNullException(nameof(vrm));

      if (vrm == "") {
        throw new ArgumentException("VRM cannot be an empty string.", nameof(vrm));
      }
    }
    #endregion
  }
}

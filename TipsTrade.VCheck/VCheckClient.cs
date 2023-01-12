using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using TipsTrade.VCheck.Model.Reports;
using TipsTrade.VCheck.Model.Reports.History;

namespace TipsTrade.VCheck {
  /// <summary>
  /// A client for accessing the VCheck REST API.
  /// <para>See <see href="https://api.vcheck.uk/documentation/"/></para>
  /// </summary>
  public class VCheckClient {
    #region Fields
    private string apiKey;

    /// <summary>The API version for which the <see cref="VCheckClient"/> was written.</summary>
    public static readonly string ApiVersion = "2.1";

    private const string AuthorizationHeader = "authorization";

    private static readonly string BaseUrl = "https://api.vcheck.uk/";
    #endregion

    #region Properties
    /// <summary>The API key used for authentication.</summary>
    public string ApiKey {
      get {
        return apiKey;
      }
      set {
        apiKey = value ?? throw new ArgumentNullException(nameof(value), "value cannot be null");

        if (Client.DefaultRequestHeaders.Contains(AuthorizationHeader)) {
          Client.DefaultRequestHeaders.Remove(AuthorizationHeader);
        }

        Client.DefaultRequestHeaders.Add(AuthorizationHeader, $"Token {value}");
      }
    }

    private HttpClient Client { get; }

    /// <summary>The <see cref="TimeSpan"/> to wait before requests timeout.</summary>
    public TimeSpan Timeout {
      get => Client.Timeout;
      set => Client.Timeout = value;
    }
    #endregion

    #region Constructors
    /// <summary>Creates an instance of the <see cref="VCheckClient"/> class.</summary>
    /// <param name="apiKey">The API key used for authentication.</param>
    public VCheckClient(string apiKey) {
      if (apiKey == null) {
        throw new ArgumentNullException(nameof(apiKey), "value cannot be null");
      }

      Client = new HttpClient() {
        BaseAddress = new Uri(BaseUrl)
      };

      ApiKey = apiKey;
    }
    #endregion

    #region Methods
    private HttpRequestMessage BuildGetRequest(string endpoint, Dictionary<string, string> queryParams) {
      // The HttpClient and UriBuilders are an absolute pile of sh1t when it comes to querystrings
      // You either needs to include a tonne of extra packages or reinvent the wheel.

      var path = new System.Text.StringBuilder(BaseUrl.TrimEnd('/'));
      path.Append("/");
      path.Append(endpoint.TrimStart('/'));

      if (queryParams?.Keys.Any() == true) {
        path.Append("?");

        path.Append(string.Join(
          "&",
          queryParams.Select(item => $"{item.Key}={HttpUtility.UrlEncode(item.Value)}")
          ));
      }

      return new HttpRequestMessage(HttpMethod.Get, path.ToString());
    }

    private async Task<TResponse> ExecuteRequestAsync<TResponse>(HttpRequestMessage request) where TResponse : new() {
      var response = await Client.SendAsync(request);

      if (!response.IsSuccessStatusCode) {
        ErrorResponse error = null;

        try {
          error = JsonConvert.DeserializeObject<ErrorResponse>(await response.Content.ReadAsStringAsync());

        } catch { }

        var message = error?.Detail ?? "The VCheck API returned an error.";

        throw new ApiException(message) {
          Error = error,
          StatusCode = response.StatusCode
        };
      }

      var content = await response.Content.ReadAsStringAsync();

      return JsonConvert.DeserializeObject<TResponse>(content);
    }

    /// <summary>Gets a report.</summary>
    /// <param name="vrm">The VRM of the vehicle.</param>
    /// <param name="checkType">The type of vheck to create.</param>
    public Task<Report> CreateReportAsync(string vrm, CheckType checkType) {
      vrm = vrm?.Replace(" ", "") ?? throw new ArgumentNullException(nameof(vrm));

      if (vrm == "") {
        throw new ArgumentException(nameof(vrm), "VRM cannot be an empty string.");
      }

      var request = BuildGetRequest(
        "/report/create",
        new Dictionary<string, string> {
          {"vrm", vrm.Replace(" ", "") },
          {"check_type", $"{(int)checkType}" }
        });

      return ExecuteRequestAsync<Report>(request);
    }

    /// <summary>Gets the ancestory records for the vehicle.</summary>
    /// <param name="vrm">The VRM of the vehicle.</param>
    public Task<IEnumerable<VehicleAncestory>> GetAncestoryAsync(string vrm) {
      return GetAncestoryAsync(new string[] { vrm });
    }

    /// <summary>Gets the ancestory records for the vehicle.</summary>
    /// <param name="vrm">The list of VRMs of the vehicle.</param>
    public async Task<IEnumerable<VehicleAncestory>> GetAncestoryAsync(IEnumerable<string> vrm) {
      var request = BuildGetRequest(
        "/data//data/vehicle_ancestry",
        new Dictionary<string, string> {
          {"vrm", string.Join(",", vrm) },
        });

      var response = await ExecuteRequestAsync<ResponseList<VehicleAncestory>>(request);

      return response.Results;
    }

    /// <summary>Gets the salvage records for the vehicle.</summary>
    /// <param name="vrm">The VRM of the vehicle.</param>
    /// <param name="vin">The optioanal VIN of the vehicle.</param>
    public Task<IEnumerable<SalvageAuction>> GetSalvageRecordsAsync(string vrm, string vin = null) {
      return GetSalvageRecordsAsync(new string[] { vrm }, vin);
    }

    /// <summary>Gets the salvage records for the vehicle.</summary>
    /// <param name="vrm">The list of VRMs of the vehicle.</param>
    /// <param name="vin">The optioanal VIN of the vehicle.</param>
    public async Task<IEnumerable<SalvageAuction>> GetSalvageRecordsAsync(IEnumerable<string> vrm, string vin = null) {
      var request = BuildGetRequest(
        "/data/salvage",
        new Dictionary<string, string> {
          {"vrm", string.Join(",", vrm) },
          {"vin", vin }
        });

      var response = await ExecuteRequestAsync<ResponseList<SalvageAuction>>(request);

      return response.Results;
    }

    /// <summary>Views an existing report.</summary>
    /// <param name="reference">The unique reference of the report.</param>
    public Task<Report> ViewReportAsync(string reference) {
      var request = BuildGetRequest(
        "/report/view",
        new Dictionary<string, string> {
          { "reference", reference }
        });

      return ExecuteRequestAsync<Report>(request);
    }
    #endregion
  }
}

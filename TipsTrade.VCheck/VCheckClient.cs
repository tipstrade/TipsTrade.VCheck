using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Reflection;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using TipsTrade.ApiClient.Core.Caching;
using TipsTrade.ApiClient.Core.Error;
using TipsTrade.ApiClient.Core.Logging;
using TipsTrade.ApiClient.Core.Tenant;
using TipsTrade.VCheck.Model.Reports;
using TipsTrade.VCheck.Model.Reports.History;

namespace TipsTrade.VCheck {
  /// <summary>Represents options for the <see cref="VCheckClient"/>.</summary>
  public class VCheckClientOptions {
    /// <summary>
    /// The version of RestSharp used by the client.
    /// </summary>
    private static readonly string RestSharpVersion = $"{typeof(RestClient).Assembly.GetName().Version}";

    /// <summary>
    /// The version of the executing assembly.
    /// </summary>
    private static readonly string Version = $"{Assembly.GetExecutingAssembly().GetName().Version}";

    /// <summary>
    /// Gets or sets the timeout for API requests. Defaults to 15 seconds.
    /// </summary>
    public TimeSpan Timeout { get; set; } = TimeSpan.FromSeconds(15);

    /// <summary>
    /// Gets or sets the User-Agent string used in API requests.
    /// </summary>
    public string DefaultUserAgent { get; set; } = $"TipsTrade.VCheck/{Version} RestSharp/{RestSharpVersion} (+https://github.com/tipstrade/TipsTrade.VCheck)";
  }

  /// <summary>
  /// A client for accessing the VCheck REST API.
  /// <para>See <see href="https://api.vcheck.uk/documentation/"/></para>
  /// </summary>
  public class VCheckClient : IWithLogger {
    #region DI
    private ICacheProvider? CacheProvider { get; }
    public ILogger? Logger { get; }
    private ITenantProvider? TenantProvider { get; }
    #endregion

    #region Fields
    /// <summary>The API version for which the <see cref="VCheckClient"/> was written.</summary>
    public static readonly string ApiVersion = "2.1";

    private static readonly string BaseUrl = "https://api.vcheck.uk/";
    #endregion

    #region Properties
    private RestClient RestClient { get; }
    #endregion

    #region Constructors
    /// <summary>Creates an instance of the <see cref="VCheckClient"/> class.</summary>
    public VCheckClient(
      ICredentialProvider credentialsProvider,
      HttpClient? httpClient = null,
      ITenantProvider? tenantProvider = null,
      ICacheProvider? cacheProvider = null,
      ILogger? logger = null,
      IOptions<VCheckClientOptions>? options = null
      ) {
      CacheProvider = cacheProvider;
      Logger = logger;
      TenantProvider = tenantProvider;
      options ??= Options.Create(new VCheckClientOptions());

      RestClient = new RestClient(
        httpClient: httpClient ?? new HttpClient(),
        options: new RestClientOptions {
          BaseUrl = new Uri(BaseUrl),
          Interceptors = [new ApiKeyInterceptor(credentialsProvider, logger, tenantProvider)],
          Timeout = options.Value.Timeout,
          UserAgent = options.Value.DefaultUserAgent
        });
    }
    #endregion

    #region Private methods
    private async Task<T?> ExecuteRequestAsync<T>(RestRequest request, CancellationToken cancellationToken) where T : class {
      var resp = await RestClient.ExecuteAsync<T>(request, cancellationToken);

      if (!resp.IsSuccessful) {
        ErrorResponse? error = null;

        if (resp.Content != null) {
          try {
            error = JsonSerializer.Deserialize<ErrorResponse>(resp.Content);
          } catch (Exception ex) {
            Logger?.LogError("Unable to parse ErrorResponse: {message}", ex.Message);
          }
        }

        var message = error?.Detail ?? resp.ErrorMessage ?? resp.ErrorException?.Message;

        throw ApiException.FromHttpError(resp.StatusCode, message, innerException: resp.ErrorException, error: error);
      }

      return resp.Data;
    }

    private async Task<T> WrapCachingAsync<T>(string cacheKey, Func<Task<T?>> func, CancellationToken cancellationToken) {
      string? tenantId = null;

      if (CacheProvider != null) {
        tenantId = await TenantProvider.GetTenantOrThrowAsync(cancellationToken);

        var cached = await CacheProvider.TryGetFromCacheAsync<(string, string), T>((tenantId, cacheKey), cancellationToken);

        if (cached != null) {
          return cached;
        }
      }

      var response = await func();

      if (CacheProvider != null && tenantId != null && response != null) {
        await CacheProvider.TryAddToCacheAsync((tenantId, cacheKey), response, cancellationToken);
      }

      return response ?? throw new ApiException("No data was returned by the VCheck API.");
    }
    #endregion

    #region Methods
    /// <summary>Gets a report.</summary>
    /// <param name="vin">The VIN of the vehicle.</param>
    /// <param name="checkType">The type of vheck to create.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    public Task<Report?> CreateReportByVinAsync(string vin, CheckType checkType, CancellationToken cancellationToken = default) {
      ValidateVin(ref vin);

      return CreateReportAsync(checkType, vin: vin, cancellationToken: cancellationToken);
    }

    /// <summary>Gets a report.</summary>
    /// <param name="vrm">The VRM of the vehicle.</param>
    /// <param name="checkType">The type of vheck to create.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    public Task<Report?> CreateReportByVrmAsync(string vrm, CheckType checkType, CancellationToken cancellationToken = default) {
      ValidateVrm(ref vrm);

      return CreateReportAsync(checkType, vrm: vrm, cancellationToken: cancellationToken);
    }

    /// <summary>Gets a report.</summary>
    /// <param name="checkType">The type of vheck to create.</param>
    /// <param name="vrm">The VRM of the vehicle.</param>
    /// <param name="vin">The VIN of the vehicle.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    private async Task<Report?> CreateReportAsync(CheckType checkType, string? vrm = null, string? vin = null, CancellationToken cancellationToken = default) {
      var request = new RestRequest("/report/create")
         .AddQueryParameter("check_type", (int)checkType);

      if (vrm != null) {
        request.AddQueryParameter("vrm", vrm);
      } else if (vin != null) {
        request.AddQueryParameter("vin  ", vin);
      }

      return await WrapCachingAsync(
        $"report_create-{vin ?? vrm}",
        () => ExecuteRequestAsync<Report>(request, cancellationToken),
        cancellationToken
        );
    }

    /// <summary>Gets the salvage records for the vehicle.</summary>
    /// <param name="vrm">The VRM of the vehicle.</param>
    /// <param name="vin">The optioanal VIN of the vehicle.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    public Task<IEnumerable<SalvageAuction>> GetSalvageRecordsAsync(string vrm, string? vin = null, CancellationToken cancellationToken = default) {
      return GetSalvageRecordsAsync([vrm], vin);
    }

    /// <summary>Gets the salvage records for the vehicle.</summary>
    /// <param name="vrm">The list of VRMs of the vehicle.</param>
    /// <param name="vin">The optioanal VIN of the vehicle.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    public Task<IEnumerable<SalvageAuction>> GetSalvageRecordsAsync(IEnumerable<string> vrm, string? vin = null, CancellationToken cancellationToken = default) {
      throw new NotImplementedException();
    }

    /// <summary>Views an existing report.</summary>
    /// <param name="reference">The unique reference of the report.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    public async Task<Report> ViewReportAsync(string reference, CancellationToken cancellationToken = default) {
      var request = new RestRequest("/report/view").AddQueryParameter("reference", reference);

      return await WrapCachingAsync(
        $"report_view-{reference}",
        () => ExecuteRequestAsync<Report>(request, cancellationToken),
        cancellationToken
        );
    }
    #endregion

    #region Static methods
    internal static void ValidateVin(ref string vin) {
      vin = vin?.Replace(" ", "")?.ToUpper() ?? throw new ArgumentNullException(nameof(vin));

      if (vin == "") {
        throw new ArgumentException("VIN cannot be an empty string.", nameof(vin));
      }
    }

    internal static void ValidateVrm(ref string vrm) {
      vrm = vrm?.Replace(" ", "")?.ToUpper() ?? throw new ArgumentNullException(nameof(vrm));

      if (vrm == "") {
        throw new ArgumentException("VRM cannot be an empty string.", nameof(vrm));
      }
    }
    #endregion
  }
}

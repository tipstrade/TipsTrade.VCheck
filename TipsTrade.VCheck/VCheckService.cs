using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Reflection;

namespace TipsTrade.VCheck {
  /// <summary>Represents options for the <see cref="VCheckService"/>.</summary>
  public class VCheckServiceOptions {
    private static string Version = $"{Assembly.GetExecutingAssembly().GetName().Version}";

    /// <summary>The default timeout.</summary>
    public TimeSpan DefaultTimeout { get; set; } = TimeSpan.FromSeconds(15);

    /// <summary>The default User Agent string.</summary>
    public string DefaultUserAgent { get; set; } = $"TipsTrade.VCheck/{Version} (+https://github.com/tipstrade/TipsTrade.VCheck)";
  }

  /// <summary>The service which provides access to the <see cref="VCheckClient"/>.</summary>
  public class VCheckService {
    /// <summary>The <see cref="VCheckClient"/>.</summary>
    public VCheckClient Client { get; }

    /// <summary>Creates an instance of the <see cref="VCheckService"/> class.</summary>
    public VCheckService(
      ICredentialsProvider credentialsProvider,
      HttpClient httpClient,
      ITennantProvider? tennantProvider = null,
      ILogger? logger = null
      ) {
      Client = new VCheckClient(
        credentialsProvider: credentialsProvider,
        httpClient: httpClient,
        tennantProvider: tennantProvider,
        logger: logger
        );
    }
  }
}

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;

namespace TipsTrade.VCheck {
  /// <summary>Defines methods for configuring the VCheck services.</summary>
  public static class ServiceExtensions {
    /// <summary>Adds a scoped <see cref="VCheckService"/>.</summary>
    public static IServiceCollection AddVCheckService<T>(this IServiceCollection services, Action<VCheckServiceOptions>? options = null)
      where T : class, ICredentialProvider {
      if (options != null) {
        services.Configure(options);
      }

      services.AddHttpClient<VCheckService>((sp, http) => {
        var options = sp.GetRequiredService<IOptions<VCheckServiceOptions>>().Value;

        http.DefaultRequestHeaders.UserAgent.Clear();
        http.DefaultRequestHeaders.UserAgent.ParseAdd(options.DefaultUserAgent);
        http.Timeout = options.DefaultTimeout;
      });

      services.AddScoped<ICredentialProvider, T>();

      return services;
    }

    /// <summary>Adds the scoped <see cref="ITenantProvider"/> class for providing tenant IDs.</summary>
    public static IServiceCollection AddVCheckTenants<T>(this IServiceCollection services) where T : class, ITenantProvider {
      return services.AddScoped<ITenantProvider, T>();
    }
  }
}

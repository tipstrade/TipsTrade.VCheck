using Microsoft.Extensions.DependencyInjection;
using System;

namespace TipsTrade.VCheck {
  /// <summary>
  /// Provides extension methods for registering VCheck client services with the dependency injection container.
  /// </summary>
  public static class ServiceExtensions {
    /// <summary>
    /// Registers the <see cref="VCheckClient"/> and a credential provider with the dependency injection container.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the credential provider to register. Must implement <see cref="ICredentialProvider"/>.
    /// </typeparam>
    /// <param name="services">The service collection to add the services to.</param>
    /// <param name="options">
    /// An optional delegate to configure <see cref="VCheckClientOptions"/>.
    /// </param>
    /// <returns>The updated <see cref="IServiceCollection"/>.</returns>
    public static IServiceCollection AddVCheckClient<T>(this IServiceCollection services, Action<VCheckClientOptions>? options = null)
      where T : class, ICredentialProvider {
      if (options != null) {
        services.Configure(options);
      }

      services.AddHttpClient<VCheckClient>();
      services.AddScoped<ICredentialProvider, T>();

      return services;
    }

    /// <summary>
    /// Registers a cache provider for the VCheck client with the dependency injection container.
    /// </summary>
    /// <typeparam name="TCacheProvider">
    /// The type of the cache provider to register. Must implement <see cref="ICacheProvider"/>.
    /// </typeparam>
    /// <param name="services">The service collection to add the services to.</param>
    /// <returns>The updated <see cref="IServiceCollection"/>.</returns>
    public static IServiceCollection AddVCheckClientCache<TCacheProvider>(this IServiceCollection services) where TCacheProvider : class, ICacheProvider {
      services.AddScoped<ICacheProvider, TCacheProvider>();

      return services;
    }

    /// <summary>
    /// Registers a tenant provider for the VCheck client with the dependency injection container.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the tenant provider to register. Must implement <see cref="ITenantProvider"/>.
    /// </typeparam>
    /// <param name="services">The service collection to add the services to.</param>
    /// <returns>The updated <see cref="IServiceCollection"/>.</returns>
    public static IServiceCollection AddVCheckClientTenants<T>(this IServiceCollection services) where T : class, ITenantProvider {
      return services.AddScoped<ITenantProvider, T>();
    }
  }
}

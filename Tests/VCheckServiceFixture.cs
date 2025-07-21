using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;
using TipsTrade.VCheck;

namespace Tests {
  public class VCheckFixture<T> where T : class, ICredentialProvider {
    protected IConfiguration Configuration { get; private set; } = null!;
    protected IServiceProvider ServiceProvider { get; private set; } = null!;
    protected Mocks Mocks => Configuration.GetSection("Mocks")?.Get<Mocks>() ?? throw new InvalidOperationException("Couldn't get Mocks section");

    [OneTimeSetUp]
    public void OneTimeSetUp() {
      Configuration = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json")
        .AddUserSecrets<Mocks>()
        .Build();

      var services = new ServiceCollection();

      services.AddSingleton(Configuration);

      services.AddHttpClient();
      services.AddOptions();
      services.AddVCheckService<T>();
      services.AddVCheckTenants<Providers.TenantProvider>();

      ServiceProvider = services.BuildServiceProvider();
    }
  }
}

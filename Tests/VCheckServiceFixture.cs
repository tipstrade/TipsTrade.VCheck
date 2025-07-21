using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;
using TipsTrade.VCheck;

namespace Tests {
  public class VCheckFixture<T> where T : class, ICredentialsProvider {
    protected IConfiguration Configuration { get; private set; }
    protected IServiceProvider ServiceProvider { get; private set; }
    protected Mocks Mocks => Configuration.GetSection("Mocks").Get<Mocks>();

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
      services.AddVCheckTennants<Providers.TennantProvider>();

      ServiceProvider = services.BuildServiceProvider();
    }
  }
}

using Microsoft.Extensions.Configuration;

namespace Tests {
  public  class TestBase {
    protected string ApiKey => Configuration["ApiKey"];

    protected IConfiguration Configuration { get; private set; }

    protected Mocks Mocks => Configuration.GetSection("Mocks").Get<Mocks>();

    public TestBase() {
      Configuration = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json")
        .AddUserSecrets<TestBase>()
        .Build();
    }
  }
}

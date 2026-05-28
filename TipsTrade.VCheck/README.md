# TipsTrade.VCheck

[![NuGet](https://img.shields.io/nuget/v/TipsTrade.VCheck)](https://www.nuget.org/packages/TipsTrade.VCheck)
[![License](https://img.shields.io/github/license/tipstrade/TipsTrade.VCheck)](https://github.com/tipstrade/TipsTrade.VCheck/blob/develop/LICENSE)

A .NET client library for querying the [VCheck REST API](https://api.vcheck.uk/documentation/), providing strongly typed access to vehicle check reports.

The package major version follows the .NET target version (e.g. 8.x.x targets net8.0).

## Installation

```
dotnet add package TipsTrade.VCheck
```

## Getting Started

### 1. Implement `ICredentialProvider`

You must implement `ICredentialProvider` to supply an API key to the client:

```csharp
using TipsTrade.VCheck;

public class MyCredentialProvider : ICredentialProvider {
  public Task<ApiKeyCredential> GetCredentialAsync(string key, CancellationToken cancellationToken = default) {
	return Task.FromResult(new ApiKeyCredential("your-api-key"));
  }
}
```

### 2. Register Services

Use the provided extension methods to register the client with the .NET dependency injection container:

```csharp
services.AddVCheckClient<MyCredentialProvider>(options => {
  options.Timeout = TimeSpan.FromSeconds(30);
});

// Optional: add caching support
services.AddVCheckClientCache<MyCacheProvider>();

// Optional: add multi-tenant support
services.AddVCheckClientTenants<MyTenantProvider>();
```

### 3. Use the Client

Inject `VCheckClient` and call the API:

```csharp
public class MyService(VCheckClient client) {
  public async Task<Report?> GetReportAsync(string vrm) {
	return await client.CreateReportByVrmAsync(vrm, CheckType.Full);
  }

  public async Task<Report> ViewExistingReportAsync(string reference) {
	return await client.ViewReportAsync(reference);
  }
}
```

## Check Types

| Value | Description |
|-------|-------------|
| `CheckType.Initial` | An initial check |
| `CheckType.Basic` | A basic check |
| `CheckType.Full` | A full check |

## API Methods

| Method | Description |
|--------|-------------|
| `CreateReportByVrmAsync(vrm, checkType)` | Creates a new report by vehicle registration mark (VRM) |
| `CreateReportByVinAsync(vin, checkType)` | Creates a new report by vehicle identification number (VIN) |
| `ViewReportAsync(reference)` | Views an existing report by its unique reference |

## Optional Providers

| Interface | Description |
|-----------|-------------|
| `ICredentialProvider` | **Required.** Supplies the API key for authentication |
| `ICacheProvider` | Optional. Caches API responses keyed by `(TenantId, Key)` |
| `ITenantProvider` | Optional. Resolves the current tenant ID for multi-tenant scenarios |

## Targets

Targets `net8` and `net481` (.NET Framework 4.8.1).

## License

[MIT](https://github.com/tipstrade/TipsTrade.VCheck/blob/develop/LICENSE)

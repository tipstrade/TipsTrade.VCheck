# TipsTrade.VCheck

A .NET client library for querying the [VCheck REST API](https://api.vcheck.uk/documentation/), providing strongly typed access to vehicle check reports including MOT history, ULEZ status, vehicle history, valuations, and more.

The package major version follows the .NET target version (e.g. 8.x.x targets net8.0).

## Packages

| Package | Version | Description |
|---------|---------|-------------|
| [`TipsTrade.VCheck`](#tipstradevcheck-1) | [![NuGet](https://img.shields.io/nuget/v/TipsTrade.VCheck)](https://www.nuget.org/packages/TipsTrade.VCheck) | HTTP client and DI integration for the VCheck API |
| [`TipsTrade.VCheck.Model`](#tipstradevcheckmodel) | [![NuGet](https://img.shields.io/nuget/v/TipsTrade.VCheck.Model)](https://www.nuget.org/packages/TipsTrade.VCheck.Model) | Strongly typed models for VCheck API responses |

---

## TipsTrade.VCheck

[![NuGet](https://img.shields.io/nuget/v/TipsTrade.VCheck)](https://www.nuget.org/packages/TipsTrade.VCheck)

### Installation

```
dotnet add package TipsTrade.VCheck
```

### Getting Started

#### 1. Implement `ICredentialProvider`

You must implement `ICredentialProvider` to supply an API key to the client:

```csharp
using TipsTrade.VCheck;

public class MyCredentialProvider : ICredentialProvider {
  public Task<ApiKeyCredential> GetCredentialAsync(string key, CancellationToken cancellationToken = default) {
    return Task.FromResult(new ApiKeyCredential("your-api-key"));
  }
}
```

#### 2. Register Services

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

#### 3. Use the Client

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

### Check Types

| Value | Description |
|-------|-------------|
| `CheckType.Initial` | An initial check |
| `CheckType.Basic` | A basic check |
| `CheckType.Full` | A full check |

### API Methods

| Method | Description |
|--------|-------------|
| `CreateReportByVrmAsync(vrm, checkType)` | Creates a new report by vehicle registration mark (VRM) |
| `CreateReportByVinAsync(vin, checkType)` | Creates a new report by vehicle identification number (VIN) |
| `ViewReportAsync(reference)` | Views an existing report by its unique reference |

### Optional Providers

| Interface | Description |
|-----------|-------------|
| `ICredentialProvider` | **Required.** Supplies the API key for authentication |
| `ICacheProvider` | Optional. Caches API responses keyed by `(TenantId, Key)` |
| `ITenantProvider` | Optional. Resolves the current tenant ID for multi-tenant scenarios |

---

## TipsTrade.VCheck.Model

[![NuGet](https://img.shields.io/nuget/v/TipsTrade.VCheck.Model)](https://www.nuget.org/packages/TipsTrade.VCheck.Model)

Strongly typed models representing the VCheck API response schema. Supports both `Newtonsoft.Json` and `System.Text.Json` serialization.

### Installation

```
dotnet add package TipsTrade.VCheck.Model
```

### Models

#### Top-level

| Type | Description |
|------|-------------|
| `Report` | The full vehicle check report |
| `CheckDetails` | Details about the check performed |
| `VehicleSummary` | Summary information for the vehicle |
| `VehicleDetails` | Detailed vehicle information |

#### History

| Type | Description |
|------|-------------|
| `VehicleHistory` | Aggregated vehicle history |
| `VehicleAncestory` | Vehicle ancestry information |
| `ColourChanges` | History of colour changes |
| `Export` | Export history records |
| `Finance` | Outstanding finance records |
| `Import` | Import history records |
| `KeeperChange` | Keeper change records |
| `MileageRecord` | Mileage history records |
| `Ownership` | Ownership history |
| `SalvageAuction` | Salvage auction records |
| `Scrapped` | Scrapped status records |
| `Stolen` | Stolen status records |
| `UserSubmit` | User-submitted data |
| `VrmChange` | VRM change history |
| `WriteOff` | Write-off records |

#### Technical

| Type | Description |
|------|-------------|
| `TechnicalSpecification` | Full technical specification |
| `Dimensions` | Vehicle dimensions |
| `Engine` | Engine specification |
| `General` | General technical data |
| `Performance` | Performance data |

#### Other

| Type | Description |
|------|-------------|
| `Mot` | MOT information |
| `MotTest` | Individual MOT test result |
| `MotComment` | MOT advisory or failure comment |
| `Ulez` | Ultra-low emission zone (London) status |
| `Valuation` | Vehicle valuation |
| `Ved` | Vehicle excise duty (road tax) information |
| `VedRate` | VED rate details |
| `FuelCosts` | Estimated fuel cost information |

---

## Targets

Both packages target `net8` and `net481` (.NET Framework 4.8.1).

## License

[MIT](LICENSE)

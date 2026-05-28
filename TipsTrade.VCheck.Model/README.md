# TipsTrade.VCheck.Model

[![NuGet](https://img.shields.io/nuget/v/TipsTrade.VCheck.Model)](https://www.nuget.org/packages/TipsTrade.VCheck.Model)
[![License](https://img.shields.io/github/license/tipstrade/TipsTrade.VCheck)](https://github.com/tipstrade/TipsTrade.VCheck/blob/develop/LICENSE)

Strongly typed models for [VCheck API](https://api.vcheck.uk/documentation/) responses. Supports both `Newtonsoft.Json` and `System.Text.Json` serialization.

This package is a dependency of [`TipsTrade.VCheck`](https://www.nuget.org/packages/TipsTrade.VCheck) and can also be referenced directly if you only need the model types.

The package major version follows the .NET target version (e.g. 8.x.x targets net8.0).

## Installation

```
dotnet add package TipsTrade.VCheck.Model
```

## Models

### Top-level

| Type | Description |
|------|-------------|
| `Report` | The full vehicle check report |
| `CheckDetails` | Details about the check performed |
| `VehicleSummary` | Summary information for the vehicle |
| `VehicleDetails` | Detailed vehicle information |

### History

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

### Technical

| Type | Description |
|------|-------------|
| `TechnicalSpecification` | Full technical specification |
| `Dimensions` | Vehicle dimensions |
| `Engine` | Engine specification |
| `General` | General technical data |
| `Performance` | Performance data |

### Other

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

## Serialization

All models are decorated with both `[JsonProperty]` (Newtonsoft.Json) and `[JsonPropertyName]` (System.Text.Json) attributes, so they work with either serializer out of the box.

## Targets

Targets `net8` and `net481` (.NET Framework 4.8.1).

## License

[MIT](https://github.com/tipstrade/TipsTrade.VCheck/blob/develop/LICENSE)

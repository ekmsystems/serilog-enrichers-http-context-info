# Serilog.Enrichers.HttpContextInfo

Enrich Serilog log events with properties from the current HttpContext.

[![Build status](https://ci.appveyor.com/api/projects/status/l60gff79t9hs6vqo?svg=true)](https://ci.appveyor.com/project/mrstebo/serilog-enrichers-http-context-info)
[![NuGet Version](http://img.shields.io/nuget/v/Serilog.Enrichers.HttpContextInfo.svg?style=flat)](https://www.nuget.org/packages/Serilog.Enrichers.HttpContextInfo/)

To use the enricher, first install the NuGet package:

```powershell
Install-Package Serilog.Enrichers.HttpContextInfo
```

Then, apply the enricher to you `LoggerConfiguration`:

```csharp
Log.Logger = new LoggerConfiguration()
    .Enrich.WithUrl()
    // ...other configuration...
    .CreateLogger();
```

The `WithUrl()` enricher will add a `Url` property to produced events.

### Included enrichers

The package includes:

 * `WithUrl()` - adds the `Url` from the current HttpContext.
 * `WithRawUrl()` - adds the `RawUrl` from the current HttpContext.

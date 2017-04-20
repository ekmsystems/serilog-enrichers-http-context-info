# Serilog.Enrichers.HttpContextInfo

Enrich Serilog log events with properties from the current HttpContext.

[![Build status](https://ci.appveyor.com/api/projects/status/s9yu6rmpts96rk6f/branch/master?svg=true)](https://ci.appveyor.com/project/mrstebo/serilog-enrichers-http-context-info/branch/master)
[![Coverage Status](https://coveralls.io/repos/github/mrstebo/serilog-enrichers-http-context-info/badge.svg?branch=master)](https://coveralls.io/github/mrstebo/serilog-enrichers-http-context-info?branch=master)
[![NuGet](http://img.shields.io/nuget/v/Serilog.Enrichers.HttpContextInfo.svg?style=flat)](https://www.nuget.org/packages/Serilog.Enrichers.HttpContextInfo/)

To use the enricher, first install the NuGet package:

```powershell
Install-Package Serilog.Enrichers.HttpContextInfo
```

Then, apply the enricher to your `LoggerConfiguration`:

```csharp
Log.Logger = new LoggerConfiguration()
    .Enrich.WithRequest()
    // ...other configuration...
    .CreateLogger();
```

The `WithRequest()` enricher will add the current `HttpRequest` properties to produced events.

### Included enrichers

The package includes:
 * `WithRequest()` - adds the `HttpRequest` from the current HttpContext.
 * `WithResponse()` - adds the `HttpResponse` from the current HttpContext.

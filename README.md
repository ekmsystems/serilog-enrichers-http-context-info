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
 * `WithAnonymousId()` - adds the `AnonymousId` from the current HttpContext.
 * `WithApplicationPath()` - adds the `ApplicationPath` from the current HttpContext.
 * `WithContentEncoding()` - adds the `ContentEncoding` from the current HttpContext.
 * `WithContentLength()` - adds the `ContentLength` from the current HttpContext.
 * `WithContentType()` - adds the `ContentType` from the current HttpContext.
 * `WithCurrentExecutionFilePath()` - adds the `CurrentExecutionFilePath` from the current HttpContext.
 * `WithCurrentExecutionFilePathExtension()` - adds the `CurrentExecutionFilePathExtension` from the current HttpContext.
 * `WithFilePath()` - adds the `FilePath` from the current HttpContext.
 * `WithUrl()` - adds the `Url` from the current HttpContext.
 * `WithRawUrl()` - adds the `RawUrl` from the current HttpContext.

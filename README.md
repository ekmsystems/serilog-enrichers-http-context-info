# Serilog.Enrichers.HttpContextInfo

Enrich Serilog log events with properties from the current HttpContext.

[![Build status](https://ci.appveyor.com/api/projects/status/l60gff79t9hs6vqo?svg=true)](https://ci.appveyor.com/project/mrstebo/serilog-enrichers-http-context-info)
[![Coverage Status](https://coveralls.io/repos/github/mrstebo/serilog-enrichers-http-context-info/badge.svg?branch=master)](https://coveralls.io/github/mrstebo/serilog-enrichers-http-context-info?branch=master)
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
 * `WithHttpMethod()` - adds the `HttpMethod` from the current HttpContext.
 * `WithIsAuthenticated()` - adds the `IsAuthenticated` from the current HttpContext.
 * `WithIsLocal()` - adds the `IsLocal` from the current HttpContext.
 * `WithIsSecure()` - adds the `IsSecure` from the current HttpContext.
 * `WithPath()` - adds the `Path` from the current HttpContext.
 * `WithPathInfo()` - adds the `PathInfo` from the current HttpContext.
 * `WithPhysicalApplicationPath()` - adds the `PhysicalApplicationPath` from the current HttpContext.
 * `WithPhysicalPath()` - adds the `PhysicalPath` from the current HttpContext.
 * `WithRawUrl()` - adds the `RawUrl` from the current HttpContext.
 * `WithRequestType()` - adds the `RequestType` from the current HttpContext.
 * `WithTotalBytes()` - adds the `TotalBytes` from the current HttpContext.
 * `WithUrl()` - adds the `Url` from the current HttpContext.
 * `WithUrlReferrer()` - adds the `UrlReferrer` from the current HttpContext.
 * `WithUserAgent()` - adds the `UserAgent` from the current HttpContext.
 * `WithUserHostAddress()` - adds the `UserHostAddress` from the current HttpContext.
 * `WithUserHostName()` - adds the `UserHostName` from the current HttpContext.

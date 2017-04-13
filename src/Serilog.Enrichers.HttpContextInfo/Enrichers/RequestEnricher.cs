using System;
using Serilog.Core;
using Serilog.Events;
using Serilog.Providers;

namespace Serilog.Enrichers
{
    public class RequestEnricher : ILogEventEnricher
    {
        private readonly IHttpRequestProvider _httpRequestProvider;

        public RequestEnricher()
            : this(new HttpRequestProvider())
        {
        }

        internal RequestEnricher(IHttpRequestProvider httpRequestProvider)
        {
            _httpRequestProvider = httpRequestProvider;
        }

        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            var httpRequest = _httpRequestProvider.GetCurrentRequest();

            if (httpRequest == null)
                return;

            propertyFactory
                .CreateProperty("AnonymousID", new ScalarValue(httpRequest.AnonymousID))
                .AddIfAbsent(logEvent);
            propertyFactory
                .CreateProperty("ApplicationPath", new ScalarValue(httpRequest.ApplicationPath))
                .AddIfAbsent(logEvent);
            propertyFactory
                .CreateProperty("ContentEncoding", new ScalarValue(httpRequest.ContentEncoding))
                .AddIfAbsent(logEvent);
            propertyFactory
                .CreateProperty("ContentLength", new ScalarValue(httpRequest.ContentLength))
                .AddIfAbsent(logEvent);
            propertyFactory
                .CreateProperty("ContentType", new ScalarValue(httpRequest.ContentType))
                .AddIfAbsent(logEvent);
            propertyFactory
                .CreateProperty("CurrentExecutionFilePath", new ScalarValue(httpRequest.CurrentExecutionFilePath))
                .AddIfAbsent(logEvent);
            propertyFactory
                .CreateProperty("CurrentExecutionFilePathExtension",
                    new ScalarValue(httpRequest.CurrentExecutionFilePathExtension))
                .AddIfAbsent(logEvent);
            propertyFactory
                .CreateProperty("FilePath", new ScalarValue(httpRequest.FilePath))
                .AddIfAbsent(logEvent);
            propertyFactory
                .CreateProperty("HttpMethod", new ScalarValue(httpRequest.HttpMethod))
                .AddIfAbsent(logEvent);
            propertyFactory
                .CreateProperty("IsAuthenticated", new ScalarValue(httpRequest.IsAuthenticated))
                .AddIfAbsent(logEvent);
            propertyFactory
                .CreateProperty("IsLocal", new ScalarValue(httpRequest.IsLocal))
                .AddIfAbsent(logEvent);
            propertyFactory
                .CreateProperty("IsSecureConnection", new ScalarValue(httpRequest.IsSecureConnection))
                .AddIfAbsent(logEvent);
            propertyFactory
                .CreateProperty("Path", new ScalarValue(httpRequest.Path))
                .AddIfAbsent(logEvent);
            propertyFactory
                .CreateProperty("PathInfo", new ScalarValue(httpRequest.PathInfo))
                .AddIfAbsent(logEvent);
            propertyFactory
                .CreateProperty("PhysicalApplicationPath", new ScalarValue(httpRequest.PhysicalApplicationPath))
                .AddIfAbsent(logEvent);
            propertyFactory
                .CreateProperty("PhysicalPath", new ScalarValue(httpRequest.PhysicalPath))
                .AddIfAbsent(logEvent);
            propertyFactory
                .CreateProperty("RawUrl", new ScalarValue(httpRequest.RawUrl))
                .AddIfAbsent(logEvent);
            propertyFactory
                .CreateProperty("RequestType", new ScalarValue(httpRequest.RequestType))
                .AddIfAbsent(logEvent);
            propertyFactory
                .CreateProperty("TotalBytes", new ScalarValue(httpRequest.TotalBytes))
                .AddIfAbsent(logEvent);
            propertyFactory
                .CreateProperty("Url", new ScalarValue(Convert.ToString(httpRequest.Url)))
                .AddIfAbsent(logEvent);
            propertyFactory
                .CreateProperty("UrlReferrer", new ScalarValue(Convert.ToString(httpRequest.UrlReferrer)))
                .AddIfAbsent(logEvent);
            propertyFactory
                .CreateProperty("UserAgent", new ScalarValue(httpRequest.UserAgent))
                .AddIfAbsent(logEvent);
            propertyFactory
                .CreateProperty("UserHostAddress", new ScalarValue(httpRequest.UserHostAddress))
                .AddIfAbsent(logEvent);
            propertyFactory
                .CreateProperty("UserHostName", new ScalarValue(httpRequest.UserHostName))
                .AddIfAbsent(logEvent);
        }
    }
}
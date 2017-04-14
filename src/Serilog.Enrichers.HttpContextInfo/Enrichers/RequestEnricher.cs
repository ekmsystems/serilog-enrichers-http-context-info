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
                .CreateProperty("Request.AnonymousID", new ScalarValue(httpRequest.AnonymousID))
                .AddIfAbsent(logEvent);
            propertyFactory
                .CreateProperty("Request.ApplicationPath", new ScalarValue(httpRequest.ApplicationPath))
                .AddIfAbsent(logEvent);
            propertyFactory
                .CreateProperty("Request.ContentEncoding", new ScalarValue(httpRequest.ContentEncoding))
                .AddIfAbsent(logEvent);
            propertyFactory
                .CreateProperty("Request.ContentLength", new ScalarValue(httpRequest.ContentLength))
                .AddIfAbsent(logEvent);
            propertyFactory
                .CreateProperty("Request.ContentType", new ScalarValue(httpRequest.ContentType))
                .AddIfAbsent(logEvent);
            propertyFactory
                .CreateProperty("Request.CurrentExecutionFilePath", new ScalarValue(httpRequest.CurrentExecutionFilePath))
                .AddIfAbsent(logEvent);
            propertyFactory
                .CreateProperty("Request.CurrentExecutionFilePathExtension",
                    new ScalarValue(httpRequest.CurrentExecutionFilePathExtension))
                .AddIfAbsent(logEvent);
            propertyFactory
                .CreateProperty("Request.FilePath", new ScalarValue(httpRequest.FilePath))
                .AddIfAbsent(logEvent);
            propertyFactory
                .CreateProperty("Request.HttpMethod", new ScalarValue(httpRequest.HttpMethod))
                .AddIfAbsent(logEvent);
            propertyFactory
                .CreateProperty("Request.IsAuthenticated", new ScalarValue(httpRequest.IsAuthenticated))
                .AddIfAbsent(logEvent);
            propertyFactory
                .CreateProperty("Request.IsLocal", new ScalarValue(httpRequest.IsLocal))
                .AddIfAbsent(logEvent);
            propertyFactory
                .CreateProperty("Request.IsSecureConnection", new ScalarValue(httpRequest.IsSecureConnection))
                .AddIfAbsent(logEvent);
            propertyFactory
                .CreateProperty("Request.Path", new ScalarValue(httpRequest.Path))
                .AddIfAbsent(logEvent);
            propertyFactory
                .CreateProperty("Request.PathInfo", new ScalarValue(httpRequest.PathInfo))
                .AddIfAbsent(logEvent);
            propertyFactory
                .CreateProperty("Request.PhysicalApplicationPath", new ScalarValue(httpRequest.PhysicalApplicationPath))
                .AddIfAbsent(logEvent);
            propertyFactory
                .CreateProperty("Request.PhysicalPath", new ScalarValue(httpRequest.PhysicalPath))
                .AddIfAbsent(logEvent);
            propertyFactory
                .CreateProperty("Request.RawUrl", new ScalarValue(httpRequest.RawUrl))
                .AddIfAbsent(logEvent);
            propertyFactory
                .CreateProperty("Request.RequestType", new ScalarValue(httpRequest.RequestType))
                .AddIfAbsent(logEvent);
            propertyFactory
                .CreateProperty("Request.TotalBytes", new ScalarValue(httpRequest.TotalBytes))
                .AddIfAbsent(logEvent);
            propertyFactory
                .CreateProperty("Request.Url", new ScalarValue(Convert.ToString(httpRequest.Url)))
                .AddIfAbsent(logEvent);
            propertyFactory
                .CreateProperty("Request.UrlReferrer", new ScalarValue(Convert.ToString(httpRequest.UrlReferrer)))
                .AddIfAbsent(logEvent);
            propertyFactory
                .CreateProperty("Request.UserAgent", new ScalarValue(httpRequest.UserAgent))
                .AddIfAbsent(logEvent);
            propertyFactory
                .CreateProperty("Request.UserHostAddress", new ScalarValue(httpRequest.UserHostAddress))
                .AddIfAbsent(logEvent);
            propertyFactory
                .CreateProperty("Request.UserHostName", new ScalarValue(httpRequest.UserHostName))
                .AddIfAbsent(logEvent);
        }
    }
}
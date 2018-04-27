using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using Serilog.Converters;
using Serilog.Core;
using Serilog.Events;
using Microsoft.AspNetCore.Http;
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

        public RequestEnricher(IHttpRequestProvider httpRequestProvider)
        {
            _httpRequestProvider = httpRequestProvider;
        }

        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            var httpRequest = _httpRequestProvider.GetRequest();

            if (httpRequest == null)
                return;

            propertyFactory
                .CreateProperty("Request.PathBase", new ScalarValue(httpRequest.PathBase))
                .AddIfAbsent(logEvent);
            propertyFactory
                .CreateProperty("Request.Path", new ScalarValue(httpRequest.Path))
                .AddIfAbsent(logEvent);
            propertyFactory
                .CreateProperty("Request.ContentLength", new ScalarValue(httpRequest.ContentLength))
                .AddIfAbsent(logEvent);
            propertyFactory
                .CreateProperty("Request.ContentType", new ScalarValue(httpRequest.ContentType))
                .AddIfAbsent(logEvent);
            propertyFactory
                .CreateProperty("Request.Method", new ScalarValue(httpRequest.Method))
                .AddIfAbsent(logEvent);
            propertyFactory
                .CreateProperty("Request.IsAuthenticated", new ScalarValue(httpRequest.IsAuthenticated))
                .AddIfAbsent(logEvent);
            propertyFactory
                .CreateProperty("Request.Protocol", new ScalarValue(httpRequest.Protocol))
                .AddIfAbsent(logEvent);
            propertyFactory
                .CreateProperty("Request.IsHttps", new ScalarValue(httpRequest.IsHttps))
                .AddIfAbsent(logEvent);
            propertyFactory
                .CreateProperty("Request.Scheme", new ScalarValue(httpRequest.Scheme))
                .AddIfAbsent(logEvent);
            propertyFactory
                .CreateProperty("Request.QueryString", new ScalarValue(Convert.ToString(httpRequest.QueryString)))
                .AddIfAbsent(logEvent);
            propertyFactory
                .CreateProperty("Request.Host", new ScalarValue(Convert.ToString(httpRequest.Host)))
                .AddIfAbsent(logEvent);

            foreach (var property in ExtractLogEventProperties(httpRequest.Cookies, "Request.Cookies", propertyFactory))
                property.AddIfAbsent(logEvent);
            
            foreach (var property in ExtractLogEventProperties(httpRequest.Files, "Request.Files", propertyFactory))
                property.AddIfAbsent(logEvent);

            foreach (var property in ExtractLogEventProperties(httpRequest.Form, "Request.Form", propertyFactory))
                property.AddIfAbsent(logEvent);

            foreach (var property in ExtractLogEventProperties(httpRequest.Headers, "Request.Headers", propertyFactory))
                property.AddIfAbsent(logEvent);
        }

        private static IEnumerable<LogEventProperty> ExtractLogEventProperties(
            IFormCollection collection,
            string propertyName,
            ILogEventPropertyFactory propertyFactory)
        {
            var converter = new FormCollectionLogEventPropertyConverter(propertyFactory, propertyName);
            return converter.Convert(collection);
        }

        private static IEnumerable<LogEventProperty> ExtractLogEventProperties(
            IHeaderDictionary collection,
            string propertyName,
            ILogEventPropertyFactory propertyFactory)
        {
            var converter = new HeaderDictionaryLogEventPropertyConverter(propertyFactory, propertyName);
            return converter.Convert(collection);
        }

        private static IEnumerable<LogEventProperty> ExtractLogEventProperties(
            IRequestCookieCollection collection,
            string propertyName,
            ILogEventPropertyFactory propertyFactory)
        {
            var converter = new RequestCookieCollectionLogEventPropertyConverter(propertyFactory, propertyName);
            return converter.Convert(collection);
        }

        private static IEnumerable<LogEventProperty> ExtractLogEventProperties(
            IFormFileCollectionWrapper collection,
            string propertyName,
            ILogEventPropertyFactory propertyFactory)
        {
            var converter = new FormFileCollectionWrapperLogEventPropertyConverter(propertyFactory, propertyName);
            return converter.Convert(collection);
        }
    }
}
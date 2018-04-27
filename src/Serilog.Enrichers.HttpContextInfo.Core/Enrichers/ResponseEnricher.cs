using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web;
using Microsoft.AspNetCore.Http;
using Serilog.Converters;
using Serilog.Core;
using Serilog.Events;
using Serilog.Providers;

namespace Serilog.Enrichers
{
    public class ResponseEnricher : ILogEventEnricher
    {
        private readonly IHttpResponseProvider _httpResponseProvider;

        public ResponseEnricher()
            : this(new HttpResponseProvider())
        {
        }

        public ResponseEnricher(IHttpResponseProvider httpResponseProvider)
        {
            _httpResponseProvider = httpResponseProvider;
        }

        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            var httpResponse = _httpResponseProvider.GetResponse();

            if (httpResponse == null)
                return;

            propertyFactory
                .CreateProperty("Response.ContentType", new ScalarValue(httpResponse.ContentType))
                .AddIfAbsent(logEvent);
            propertyFactory
                .CreateProperty("Response.StatusCode", new ScalarValue(httpResponse.StatusCode))
                .AddIfAbsent(logEvent);

            foreach (var property in ExtractLogEventProperties(httpResponse.Headers, "Response.Headers", propertyFactory))
                property.AddIfAbsent(logEvent);
        }

        private static IEnumerable<LogEventProperty> ExtractLogEventProperties(
            IHeaderDictionary collection,
            string propertyName,
            ILogEventPropertyFactory propertyFactory)
        {
            var converter = new HeaderDictionaryLogEventPropertyConverter(propertyFactory, propertyName);
            return converter.Convert(collection);
        }
        
    }
}

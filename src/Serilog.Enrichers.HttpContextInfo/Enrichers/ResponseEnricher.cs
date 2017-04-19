using System.Collections.Generic;
using System.Collections.Specialized;
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

        internal ResponseEnricher(IHttpResponseProvider httpResponseProvider)
        {
            _httpResponseProvider = httpResponseProvider;
        }

        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            var httpResponse = _httpResponseProvider.GetResponse();

            if (httpResponse == null)
                return;

            propertyFactory
                .CreateProperty("Response.Status", new ScalarValue(httpResponse.Status))
                .AddIfAbsent(logEvent);
            propertyFactory
                .CreateProperty("Response.StatusCode", new ScalarValue(httpResponse.StatusCode))
                .AddIfAbsent(logEvent);

            foreach (var property in ExtractLogEventProperties(httpResponse.Headers, "Response.Headers", propertyFactory))
                property.AddIfAbsent(logEvent);
        }

        private static IEnumerable<LogEventProperty> ExtractLogEventProperties(
            NameValueCollection collection,
            string propertyName,
            ILogEventPropertyFactory propertyFactory)
        {
            var converter = new NameValueCollectionLogEventPropertyConverter(propertyFactory, propertyName);
            return converter.Convert(collection);
        }
    }
}

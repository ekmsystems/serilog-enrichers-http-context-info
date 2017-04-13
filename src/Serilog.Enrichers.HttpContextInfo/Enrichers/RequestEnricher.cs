using Serilog.Core;
using Serilog.Events;

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
        }
    }
}

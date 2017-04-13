using Serilog.Core;
using Serilog.Events;

namespace Serilog.Enrichers
{
    public class ContentLengthEnricher : ILogEventEnricher
    {
        private readonly IHttpContextProvider _httpContextProvider;

        public ContentLengthEnricher()
            : this(new HttpContextProvider())
        {
        }

        internal ContentLengthEnricher(IHttpContextProvider httpContextProvider)
        {
            _httpContextProvider = httpContextProvider;
        }

        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            var httpContext = _httpContextProvider.GetCurrentContext();

            if (httpContext == null)
                return;

            propertyFactory
                .CreateProperty("ContentLength", new ScalarValue(httpContext.Request.ContentLength))
                .AddIfAbsent(logEvent);
        }
    }
}
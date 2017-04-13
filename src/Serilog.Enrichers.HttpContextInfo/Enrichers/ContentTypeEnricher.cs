using Serilog.Core;
using Serilog.Events;

namespace Serilog.Enrichers
{
    public class ContentTypeEnricher : ILogEventEnricher
    {
        private readonly IHttpContextProvider _httpContextProvider;

        public ContentTypeEnricher()
            : this(new HttpContextProvider())
        {
        }

        internal ContentTypeEnricher(IHttpContextProvider httpContextProvider)
        {
            _httpContextProvider = httpContextProvider;
        }

        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            var httpContext = _httpContextProvider.GetCurrentContext();

            if (httpContext == null)
                return;

            propertyFactory
                .CreateProperty("ContentType", new ScalarValue(httpContext.Request.ContentType))
                .AddIfAbsent(logEvent);
        }
    }
}
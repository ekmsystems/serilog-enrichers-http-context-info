using System;
using Serilog.Core;
using Serilog.Events;

namespace Serilog.Enrichers
{
    public class ContentEncodingEnricher : ILogEventEnricher
    {
        private readonly IHttpContextProvider _httpContextProvider;

        public ContentEncodingEnricher()
            : this(new HttpContextProvider())
        {
        }

        internal ContentEncodingEnricher(IHttpContextProvider httpContextProvider)
        {
            _httpContextProvider = httpContextProvider;
        }

        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            if (logEvent == null) throw new ArgumentNullException(nameof(logEvent));

            var httpContext = _httpContextProvider.GetCurrentContext();

            if (httpContext == null)
                return;

            propertyFactory
                .CreateProperty("ContentEncoding", new ScalarValue(httpContext.Request.ContentEncoding))
                .AddIfAbsent(logEvent);
        }
    }
}
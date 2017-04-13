using System;
using Serilog.Core;
using Serilog.Events;

namespace Serilog.Enrichers
{
    public class AnonymousIdEnricher : ILogEventEnricher
    {
        private readonly IHttpContextProvider _httpContextProvider;

        public AnonymousIdEnricher()
            : this(new HttpContextProvider())
        {
        }

        internal AnonymousIdEnricher(IHttpContextProvider httpContextProvider)
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
                .CreateProperty("AnonymousID", new ScalarValue(httpContext.Request.AnonymousID))
                .AddIfAbsent(logEvent);
        }
    }
}

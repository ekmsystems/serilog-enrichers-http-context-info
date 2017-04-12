using System;
using System.Web;
using Serilog.Core;
using Serilog.Events;

namespace Serilog.Enrichers
{
    public class AnonymousIdEnricher : ILogEventEnricher
    {
        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            if (logEvent == null) throw new ArgumentNullException(nameof(logEvent));

            if (HttpContext.Current == null)
                return;

            propertyFactory
                .CreateProperty("AnonymousID", new ScalarValue(HttpContext.Current.Request.AnonymousID))
                .AddIfAbsent(logEvent);
        }
    }
}

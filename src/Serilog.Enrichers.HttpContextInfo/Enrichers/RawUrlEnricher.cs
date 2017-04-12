using System;
using System.Web;
using Serilog.Core;
using Serilog.Events;

namespace Serilog.Enrichers
{
    public class RawUrlEnricher : ILogEventEnricher
    {
        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            if (logEvent == null) throw new ArgumentNullException(nameof(logEvent));

            if (HttpContext.Current == null)
                return;

            propertyFactory
                .CreateProperty("RawUrl", new ScalarValue(HttpContext.Current.Request.RawUrl))
                .AddIfAbsent(logEvent);
        }
    }
}

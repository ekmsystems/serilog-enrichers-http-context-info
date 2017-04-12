using System;
using System.Web;
using Serilog.Core;
using Serilog.Events;

namespace Serilog.Enrichers
{
    public class CurrentExecutionFilePathExtensionEnricher : ILogEventEnricher
    {
        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            if (logEvent == null) throw new ArgumentNullException(nameof(logEvent));

            if (HttpContext.Current == null)
                return;

            propertyFactory
                .CreateProperty("CurrentExecutionFilePathExtension", new ScalarValue(HttpContext.Current.Request.CurrentExecutionFilePathExtension))
                .AddIfAbsent(logEvent);
        }
    }
}

using System;
using Serilog.Core;
using Serilog.Events;

namespace Serilog.Enrichers
{
    public class FilePathEnricher : ILogEventEnricher
    {
        private readonly IHttpContextProvider _httpContextProvider;

        public FilePathEnricher()
            : this(new HttpContextProvider())
        {
        }

        internal FilePathEnricher(IHttpContextProvider httpContextProvider)
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
                .CreateProperty("FilePath", new ScalarValue(httpContext.Request.FilePath))
                .AddIfAbsent(logEvent);
        }
    }
}
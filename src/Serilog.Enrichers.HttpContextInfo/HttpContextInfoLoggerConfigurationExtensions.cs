using System;
using Serilog.Configuration;
using Serilog.Enrichers;

namespace Serilog
{
    public static class HttpContextInfoLoggerConfigurationExtensions
    {
        public static LoggerConfiguration WithUrl(this LoggerEnrichmentConfiguration enrichmentConfiguration)
        {
            if (enrichmentConfiguration == null) throw new ArgumentNullException(nameof(enrichmentConfiguration));
            return enrichmentConfiguration.With<UrlEnricher>();
        }
    }
}

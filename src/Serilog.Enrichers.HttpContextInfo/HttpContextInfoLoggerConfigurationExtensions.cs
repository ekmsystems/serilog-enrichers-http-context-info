using System;
using Serilog.Configuration;
using Serilog.Enrichers;

namespace Serilog
{
    public static class HttpContextInfoLoggerConfigurationExtensions
    {
        public static LoggerConfiguration WithAnonymousId(
            this LoggerEnrichmentConfiguration enrichmentConfiguration)
        {
            if (enrichmentConfiguration == null) throw new ArgumentNullException(nameof(enrichmentConfiguration));
            return enrichmentConfiguration.With(new AnonymousIdEnricher());
        }

        public static LoggerConfiguration WithApplicationPath(
            this LoggerEnrichmentConfiguration enrichmentConfiguration)
        {
            if (enrichmentConfiguration == null) throw new ArgumentNullException(nameof(enrichmentConfiguration));
            return enrichmentConfiguration.With(new ApplicationPathEnricher());
        }
        
        public static LoggerConfiguration WithContentEncoding(
            this LoggerEnrichmentConfiguration enrichmentConfiguration)
        {
            if (enrichmentConfiguration == null) throw new ArgumentNullException(nameof(enrichmentConfiguration));
            return enrichmentConfiguration.With(new ContentEncodingEnricher());
        }

        public static LoggerConfiguration WithContentLength(
            this LoggerEnrichmentConfiguration enrichmentConfiguration)
        {
            if (enrichmentConfiguration == null) throw new ArgumentNullException(nameof(enrichmentConfiguration));
            return enrichmentConfiguration.With(new ContentLengthEnricher());
        }

        public static LoggerConfiguration WithContentType(
            this LoggerEnrichmentConfiguration enrichmentConfiguration)
        {
            if (enrichmentConfiguration == null) throw new ArgumentNullException(nameof(enrichmentConfiguration));
            return enrichmentConfiguration.With(new ContentTypeEnricher());
        }

        public static LoggerConfiguration WithCurrentExecutionFilePath(
            this LoggerEnrichmentConfiguration enrichmentConfiguration)
        {
            if (enrichmentConfiguration == null) throw new ArgumentNullException(nameof(enrichmentConfiguration));
            return enrichmentConfiguration.With(new CurrentExecutionFilePathEnricher());
        }

        public static LoggerConfiguration WithCurrentExecutionFilePathExtension(
            this LoggerEnrichmentConfiguration enrichmentConfiguration)
        {
            if (enrichmentConfiguration == null) throw new ArgumentNullException(nameof(enrichmentConfiguration));
            return enrichmentConfiguration.With(new CurrentExecutionFilePathExtensionEnricher());
        }

        public static LoggerConfiguration WithFilePath(
            this LoggerEnrichmentConfiguration enrichmentConfiguration)
        {
            if (enrichmentConfiguration == null) throw new ArgumentNullException(nameof(enrichmentConfiguration));
            return enrichmentConfiguration.With(new FilePathEnricher());
        }

        public static LoggerConfiguration WithUrl(
            this LoggerEnrichmentConfiguration enrichmentConfiguration)
        {
            if (enrichmentConfiguration == null) throw new ArgumentNullException(nameof(enrichmentConfiguration));
            return enrichmentConfiguration.With(new UrlEnricher());
        }

        public static LoggerConfiguration WithRawUrl(
            this LoggerEnrichmentConfiguration enrichmentConfiguration)
        {
            if (enrichmentConfiguration == null) throw new ArgumentNullException(nameof(enrichmentConfiguration));
            return enrichmentConfiguration.With(new RawUrlEnricher());
        }
    }
}
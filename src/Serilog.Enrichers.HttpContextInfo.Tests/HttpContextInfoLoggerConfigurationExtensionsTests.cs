using System;
using NUnit.Framework;
using Serilog.Configuration;
using Serilog.Tests.Support;

// ReSharper disable AssignNullToNotNullAttribute

namespace Serilog.Tests
{
    [TestFixture]
    [Parallelizable]
    public class HttpContextInfoLoggerConfigurationExtensionsTests
    {
        [Test]
        public void WithAnonymousId_ThenLoggerIsCalled_ShouldNotThrowException()
        {
            var logger = new LoggerConfiguration()
                .Enrich.WithAnonymousId()
                .WriteTo.Sink(new DelegatingSink(e => { }))
                .CreateLogger();

            Assert.DoesNotThrow(() => logger.Information("LOG"));
        }

        [Test]
        public void WithAnonymousId_WhenLoggerEnrichmentConfigurationIsNull_ShouldThrowArgumentNullException()
        {
            LoggerEnrichmentConfiguration configuration = null;
            Assert.Throws<ArgumentNullException>(() => configuration.WithAnonymousId());
        }

        [Test]
        public void WithApplicationPath_ThenLoggerIsCalled_ShouldNotThrowException()
        {
            var logger = new LoggerConfiguration()
                .Enrich.WithApplicationPath()
                .WriteTo.Sink(new DelegatingSink(e => { }))
                .CreateLogger();

            Assert.DoesNotThrow(() => logger.Information("LOG"));
        }

        [Test]
        public void WithApplicationPath_WhenLoggerEnrichmentConfigurationIsNull_ShouldThrowArgumentNullException()
        {
            LoggerEnrichmentConfiguration configuration = null;
            Assert.Throws<ArgumentNullException>(() => configuration.WithApplicationPath());
        }

        [Test]
        public void WithContentEncoding_ThenLoggerIsCalled_ShouldNotThrowException()
        {
            var logger = new LoggerConfiguration()
                .Enrich.WithContentEncoding()
                .WriteTo.Sink(new DelegatingSink(e => { }))
                .CreateLogger();

            Assert.DoesNotThrow(() => logger.Information("LOG"));
        }

        [Test]
        public void WithContentEncoding_WhenLoggerEnrichmentConfigurationIsNull_ShouldThrowArgumentNullException()
        {
            LoggerEnrichmentConfiguration configuration = null;
            Assert.Throws<ArgumentNullException>(() => configuration.WithContentEncoding());
        }

        [Test]
        public void WithContentLength_ThenLoggerIsCalled_ShouldNotThrowException()
        {
            var logger = new LoggerConfiguration()
                .Enrich.WithContentLength()
                .WriteTo.Sink(new DelegatingSink(e => { }))
                .CreateLogger();

            Assert.DoesNotThrow(() => logger.Information("LOG"));
        }

        [Test]
        public void WithContentLength_WhenLoggerEnrichmentConfigurationIsNull_ShouldThrowArgumentNullException()
        {
            LoggerEnrichmentConfiguration configuration = null;
            Assert.Throws<ArgumentNullException>(() => configuration.WithContentLength());
        }

        [Test]
        public void WithContentType_ThenLoggerIsCalled_ShouldNotThrowException()
        {
            var logger = new LoggerConfiguration()
                .Enrich.WithContentType()
                .WriteTo.Sink(new DelegatingSink(e => { }))
                .CreateLogger();

            Assert.DoesNotThrow(() => logger.Information("LOG"));
        }

        [Test]
        public void WithContentType_WhenLoggerEnrichmentConfigurationIsNull_ShouldThrowArgumentNullException()
        {
            LoggerEnrichmentConfiguration configuration = null;
            Assert.Throws<ArgumentNullException>(() => configuration.WithContentType());
        }

        [Test]
        public void WithCurrentExecutionFilePath_ThenLoggerIsCalled_ShouldNotThrowException()
        {
            var logger = new LoggerConfiguration()
                .Enrich.WithCurrentExecutionFilePath()
                .WriteTo.Sink(new DelegatingSink(e => { }))
                .CreateLogger();

            Assert.DoesNotThrow(() => logger.Information("LOG"));
        }

        [Test]
        public void
            WithCurrentExecutionFilePath_WhenLoggerEnrichmentConfigurationIsNull_ShouldThrowArgumentNullException()
        {
            LoggerEnrichmentConfiguration configuration = null;
            Assert.Throws<ArgumentNullException>(() => configuration.WithCurrentExecutionFilePath());
        }

        [Test]
        public void WithCurrentExecutionFilePathExtension_ThenLoggerIsCalled_ShouldNotThrowException()
        {
            var logger = new LoggerConfiguration()
                .Enrich.WithCurrentExecutionFilePathExtension()
                .WriteTo.Sink(new DelegatingSink(e => { }))
                .CreateLogger();

            Assert.DoesNotThrow(() => logger.Information("LOG"));
        }

        [Test]
        public void
            WithCurrentExecutionFilePathExtension_WhenLoggerEnrichmentConfigurationIsNull_ShouldThrowArgumentNullException
            ()
        {
            LoggerEnrichmentConfiguration configuration = null;
            Assert.Throws<ArgumentNullException>(() => configuration.WithCurrentExecutionFilePathExtension());
        }

        [Test]
        public void WithFilePath_ThenLoggerIsCalled_ShouldNotThrowException()
        {
            var logger = new LoggerConfiguration()
                .Enrich.WithFilePath()
                .WriteTo.Sink(new DelegatingSink(e => { }))
                .CreateLogger();

            Assert.DoesNotThrow(() => logger.Information("LOG"));
        }

        [Test]
        public void WithFilePath_WhenLoggerEnrichmentConfigurationIsNull_ShouldThrowArgumentNullException()
        {
            LoggerEnrichmentConfiguration configuration = null;
            Assert.Throws<ArgumentNullException>(() => configuration.WithFilePath());
        }

        [Test]
        public void WithHttpMethod_ThenLoggerIsCalled_ShouldNotThrowException()
        {
            var logger = new LoggerConfiguration()
                .Enrich.WithHttpMethod()
                .WriteTo.Sink(new DelegatingSink(e => { }))
                .CreateLogger();

            Assert.DoesNotThrow(() => logger.Information("LOG"));
        }

        [Test]
        public void WithHttpMethod_WhenLoggerEnrichmentConfigurationIsNull_ShouldThrowArgumentNullException()
        {
            LoggerEnrichmentConfiguration configuration = null;
            Assert.Throws<ArgumentNullException>(() => configuration.WithHttpMethod());
        }

        [Test]
        public void WithIsAuthenticated_ThenLoggerIsCalled_ShouldNotThrowException()
        {
            var logger = new LoggerConfiguration()
                .Enrich.WithIsAuthenticated()
                .WriteTo.Sink(new DelegatingSink(e => { }))
                .CreateLogger();

            Assert.DoesNotThrow(() => logger.Information("LOG"));
        }

        [Test]
        public void WithIsAuthenticated_WhenLoggerEnrichmentConfigurationIsNull_ShouldThrowArgumentNullException()
        {
            LoggerEnrichmentConfiguration configuration = null;
            Assert.Throws<ArgumentNullException>(() => configuration.WithIsAuthenticated());
        }

        [Test]
        public void WithIsLocal_ThenLoggerIsCalled_ShouldNotThrowException()
        {
            var logger = new LoggerConfiguration()
                .Enrich.WithIsLocal()
                .WriteTo.Sink(new DelegatingSink(e => { }))
                .CreateLogger();

            Assert.DoesNotThrow(() => logger.Information("LOG"));
        }

        [Test]
        public void WithIsLocal_WhenLoggerEnrichmentConfigurationIsNull_ShouldThrowArgumentNullException()
        {
            LoggerEnrichmentConfiguration configuration = null;
            Assert.Throws<ArgumentNullException>(() => configuration.WithIsLocal());
        }

        [Test]
        public void WithIsSecureConnection_ThenLoggerIsCalled_ShouldNotThrowException()
        {
            var logger = new LoggerConfiguration()
                .Enrich.WithIsSecureConnection()
                .WriteTo.Sink(new DelegatingSink(e => { }))
                .CreateLogger();

            Assert.DoesNotThrow(() => logger.Information("LOG"));
        }

        [Test]
        public void WithIsSecureConnection_WhenLoggerEnrichmentConfigurationIsNull_ShouldThrowArgumentNullException()
        {
            LoggerEnrichmentConfiguration configuration = null;
            Assert.Throws<ArgumentNullException>(() => configuration.WithIsSecureConnection());
        }

        [Test]
        public void WithPath_ThenLoggerIsCalled_ShouldNotThrowException()
        {
            var logger = new LoggerConfiguration()
                .Enrich.WithPath()
                .WriteTo.Sink(new DelegatingSink(e => { }))
                .CreateLogger();

            Assert.DoesNotThrow(() => logger.Information("LOG"));
        }

        [Test]
        public void WithPath_WhenLoggerEnrichmentConfigurationIsNull_ShouldThrowArgumentNullException()
        {
            LoggerEnrichmentConfiguration configuration = null;
            Assert.Throws<ArgumentNullException>(() => configuration.WithPath());
        }

        [Test]
        public void WithPathInfo_ThenLoggerIsCalled_ShouldNotThrowException()
        {
            var logger = new LoggerConfiguration()
                .Enrich.WithPathInfo()
                .WriteTo.Sink(new DelegatingSink(e => { }))
                .CreateLogger();

            Assert.DoesNotThrow(() => logger.Information("LOG"));
        }

        [Test]
        public void WithPathInfo_WhenLoggerEnrichmentConfigurationIsNull_ShouldThrowArgumentNullException()
        {
            LoggerEnrichmentConfiguration configuration = null;
            Assert.Throws<ArgumentNullException>(() => configuration.WithPathInfo());
        }

        [Test]
        public void WithPhysicalApplicationPath_ThenLoggerIsCalled_ShouldNotThrowException()
        {
            var logger = new LoggerConfiguration()
                .Enrich.WithPhysicalApplicationPath()
                .WriteTo.Sink(new DelegatingSink(e => { }))
                .CreateLogger();

            Assert.DoesNotThrow(() => logger.Information("LOG"));
        }

        [Test]
        public void WithPhysicalApplicationPath_WhenLoggerEnrichmentConfigurationIsNull_ShouldThrowArgumentNullException
            ()
        {
            LoggerEnrichmentConfiguration configuration = null;
            Assert.Throws<ArgumentNullException>(() => configuration.WithPhysicalApplicationPath());
        }

        [Test]
        public void WithPhysicalPath_ThenLoggerIsCalled_ShouldNotThrowException()
        {
            var logger = new LoggerConfiguration()
                .Enrich.WithPhysicalPath()
                .WriteTo.Sink(new DelegatingSink(e => { }))
                .CreateLogger();

            Assert.DoesNotThrow(() => logger.Information("LOG"));
        }

        [Test]
        public void WithPhysicalPath_WhenLoggerEnrichmentConfigurationIsNull_ShouldThrowArgumentNullException()
        {
            LoggerEnrichmentConfiguration configuration = null;
            Assert.Throws<ArgumentNullException>(() => configuration.WithPhysicalPath());
        }

        [Test]
        public void WithRawUrl_ThenLoggerIsCalled_ShouldNotThrowException()
        {
            var logger = new LoggerConfiguration()
                .Enrich.WithRawUrl()
                .WriteTo.Sink(new DelegatingSink(e => { }))
                .CreateLogger();

            Assert.DoesNotThrow(() => logger.Information("LOG"));
        }

        [Test]
        public void WithRawUrl_WhenLoggerEnrichmentConfigurationIsNull_ShouldThrowArgumentNullException()
        {
            LoggerEnrichmentConfiguration configuration = null;
            Assert.Throws<ArgumentNullException>(() => configuration.WithRawUrl());
        }

        [Test]
        public void WithRequestType_ThenLoggerIsCalled_ShouldNotThrowException()
        {
            var logger = new LoggerConfiguration()
                .Enrich.WithRequestType()
                .WriteTo.Sink(new DelegatingSink(e => { }))
                .CreateLogger();

            Assert.DoesNotThrow(() => logger.Information("LOG"));
        }

        [Test]
        public void WithRequestType_WhenLoggerEnrichmentConfigurationIsNull_ShouldThrowArgumentNullException()
        {
            LoggerEnrichmentConfiguration configuration = null;
            Assert.Throws<ArgumentNullException>(() => configuration.WithRequestType());
        }

        [Test]
        public void WithTotalBytes_ThenLoggerIsCalled_ShouldNotThrowException()
        {
            var logger = new LoggerConfiguration()
                .Enrich.WithTotalBytes()
                .WriteTo.Sink(new DelegatingSink(e => { }))
                .CreateLogger();

            Assert.DoesNotThrow(() => logger.Information("LOG"));
        }

        [Test]
        public void WithTotalBytes_WhenLoggerEnrichmentConfigurationIsNull_ShouldThrowArgumentNullException()
        {
            LoggerEnrichmentConfiguration configuration = null;
            Assert.Throws<ArgumentNullException>(() => configuration.WithTotalBytes());
        }

        [Test]
        public void WithUrl_ThenLoggerIsCalled_ShouldNotThrowException()
        {
            var logger = new LoggerConfiguration()
                .Enrich.WithUrl()
                .WriteTo.Sink(new DelegatingSink(e => { }))
                .CreateLogger();

            Assert.DoesNotThrow(() => logger.Information("LOG"));
        }

        [Test]
        public void WithUrl_WhenLoggerEnrichmentConfigurationIsNull_ShouldThrowArgumentNullException()
        {
            LoggerEnrichmentConfiguration configuration = null;
            Assert.Throws<ArgumentNullException>(() => configuration.WithUrl());
        }

        [Test]
        public void WithUrlReferrer_ThenLoggerIsCalled_ShouldNotThrowException()
        {
            var logger = new LoggerConfiguration()
                .Enrich.WithUrlReferrer()
                .WriteTo.Sink(new DelegatingSink(e => { }))
                .CreateLogger();

            Assert.DoesNotThrow(() => logger.Information("LOG"));
        }

        [Test]
        public void WithUrlReferrer_WhenLoggerEnrichmentConfigurationIsNull_ShouldThrowArgumentNullException()
        {
            LoggerEnrichmentConfiguration configuration = null;
            Assert.Throws<ArgumentNullException>(() => configuration.WithUrlReferrer());
        }

        [Test]
        public void WithUserAgent_ThenLoggerIsCalled_ShouldNotThrowException()
        {
            var logger = new LoggerConfiguration()
                .Enrich.WithUserAgent()
                .WriteTo.Sink(new DelegatingSink(e => { }))
                .CreateLogger();

            Assert.DoesNotThrow(() => logger.Information("LOG"));
        }

        [Test]
        public void WithUserAgent_WhenLoggerEnrichmentConfigurationIsNull_ShouldThrowArgumentNullException()
        {
            LoggerEnrichmentConfiguration configuration = null;
            Assert.Throws<ArgumentNullException>(() => configuration.WithUserAgent());
        }

        [Test]
        public void WithUserHostAddress_ThenLoggerIsCalled_ShouldNotThrowException()
        {
            var logger = new LoggerConfiguration()
                .Enrich.WithUserHostAddress()
                .WriteTo.Sink(new DelegatingSink(e => { }))
                .CreateLogger();

            Assert.DoesNotThrow(() => logger.Information("LOG"));
        }

        [Test]
        public void WithUserHostAddress_WhenLoggerEnrichmentConfigurationIsNull_ShouldThrowArgumentNullException()
        {
            LoggerEnrichmentConfiguration configuration = null;
            Assert.Throws<ArgumentNullException>(() => configuration.WithUserHostAddress());
        }

        [Test]
        public void WithUserHostName_ThenLoggerIsCalled_ShouldNotThrowException()
        {
            var logger = new LoggerConfiguration()
                .Enrich.WithUserHostName()
                .WriteTo.Sink(new DelegatingSink(e => { }))
                .CreateLogger();

            Assert.DoesNotThrow(() => logger.Information("LOG"));
        }

        [Test]
        public void WithUserHostName_WhenLoggerEnrichmentConfigurationIsNull_ShouldThrowArgumentNullException()
        {
            LoggerEnrichmentConfiguration configuration = null;
            Assert.Throws<ArgumentNullException>(() => configuration.WithUserHostName());
        }
    }
}
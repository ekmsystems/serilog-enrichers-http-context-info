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
        public void WithRequest_ThenLoggerIsCalled_ShouldNotThrowException()
        {
            var logger = new LoggerConfiguration()
                .Enrich.WithRequest()
                .WriteTo.Sink(new DelegatingSink(e => { }))
                .CreateLogger();

            Assert.DoesNotThrow(() => logger.Information("LOG"));
        }

        [Test]
        public void WithRequest_WhenLoggerEnrichmentConfigurationIsNull_ShouldThrowArgumentNullException()
        {
            LoggerEnrichmentConfiguration configuration = null;
            Assert.Throws<ArgumentNullException>(() => configuration.WithRequest());
        }
    }
}
﻿using System.IO;
using System.Web;
using NUnit.Framework;
using Serilog.Events;
using Serilog.Tests.Support;

namespace Serilog.Tests.Enrichers
{
    [TestFixture]
    [Parallelizable]
    public class ApplicationPathEnricherTests
    {
        [SetUp]
        public void SetUp()
        {
            _request = new HttpRequest("test", "https://serilog.net/my-app", "");
            _response = new HttpResponse(new StringWriter());
            HttpContext.Current = new HttpContext(_request, _response);
        }

        private HttpRequest _request;
        private HttpResponse _response;

        [Test]
        public void ShouldCreateApplicationPathProperty()
        {
            LogEvent evt = null;
            var log = new LoggerConfiguration()
                .Enrich.WithApplicationPath()
                .WriteTo.Sink(new DelegatingSink(e => evt = e))
                .CreateLogger();

            log.Information(@"Has a ApplicationPath property");

            Assert.NotNull(evt);
            Assert.NotNull((string) evt.Properties["ApplicationPath"].LiteralValue());
        }
    }
}
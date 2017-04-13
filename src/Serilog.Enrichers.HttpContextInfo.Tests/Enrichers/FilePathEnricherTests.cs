﻿using System.IO;
using System.Web;
using NUnit.Framework;
using Serilog.Events;
using Serilog.Tests.Support;

namespace Serilog.Tests.Enrichers
{
    [TestFixture]
    [Parallelizable]
    public class FilePathEnricherTests
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
        public void ShouldCreateFilePathProperty()
        {
            LogEvent evt = null;
            var log = new LoggerConfiguration()
                .Enrich.WithFilePath()
                .WriteTo.Sink(new DelegatingSink(e => evt = e))
                .CreateLogger();

            log.Information(@"Has a FilePath property");

            Assert.NotNull(evt);
            Assert.NotNull((string) evt.Properties["FilePath"].LiteralValue());
        }
    }
}
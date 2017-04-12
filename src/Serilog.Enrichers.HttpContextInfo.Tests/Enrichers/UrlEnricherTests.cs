using System.IO;
using System.Web;
using NUnit.Framework;
using Serilog.Events;
using Serilog.Tests.Support;

namespace Serilog.Tests.Enrichers
{
    [TestFixture]
    [Parallelizable]
    public class UrlEnricherTests
    {
        [SetUp]
        public void SetUp()
        {
            HttpContext.Current = new HttpContext(
                new HttpRequest("test", "https://serilog.net/", ""),
                new HttpResponse(new StringWriter()));
        }

        [Test]
        public void ShouldCreateUrlProperty()
        {
            LogEvent evt = null;
            var log = new LoggerConfiguration()
                .Enrich.WithUrl()
                .WriteTo.Sink(new DelegatingSink(e => evt = e))
                .CreateLogger();

            log.Information(@"Has a Url property");

            Assert.NotNull(evt);
            Assert.NotNull((string) evt.Properties["Url"].LiteralValue());
            Assert.AreEqual("\"https://serilog.net/\"", (string) evt.Properties["Url"].LiteralValue());
        }
    }
}

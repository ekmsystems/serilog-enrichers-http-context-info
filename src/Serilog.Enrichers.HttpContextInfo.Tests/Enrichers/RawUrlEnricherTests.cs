using System.IO;
using System.Web;
using NUnit.Framework;
using Serilog.Events;
using Serilog.Tests.Support;

namespace Serilog.Tests.Enrichers
{
    [TestFixture]
    [Parallelizable]
    public class RawUrlEnricherTests
    {
        [SetUp]
        public void SetUp()
        {
            HttpContext.Current = new HttpContext(
                new HttpRequest("test", "https://serilog.net/my-app", ""),
                new HttpResponse(new StringWriter()));
        }

        [Test]
        public void ShouldCreateRawUrlProperty()
        {
            LogEvent evt = null;
            var log = new LoggerConfiguration()
                .Enrich.WithRawUrl()
                .WriteTo.Sink(new DelegatingSink(e => evt = e))
                .CreateLogger();

            log.Information(@"Has a RawUrl property");

            Assert.NotNull(evt);
            Assert.NotNull((string) evt.Properties["RawUrl"].LiteralValue());
            Assert.AreEqual("\"/my-app\"", (string) evt.Properties["RawUrl"].LiteralValue());
        }
    }
}

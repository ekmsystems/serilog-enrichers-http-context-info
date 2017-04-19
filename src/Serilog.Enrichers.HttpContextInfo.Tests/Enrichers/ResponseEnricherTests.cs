using Moq;
using NUnit.Framework;
using Serilog.Enrichers;
using Serilog.Events;
using Serilog.Providers;
using Serilog.Tests.Support;

namespace Serilog.Tests.Enrichers
{
    [TestFixture]
    [Parallelizable]
    public class ResponseEnricherTests
    {
        [SetUp]
        public void SetUp()
        {
            _httpResponseProvider = new Mock<IHttpResponseProvider>();
            _httpResponseWrapper = new Mock<IHttpResponseWrapper>();
            _logger = new LoggerConfiguration()
                .Enrich.With(new ResponseEnricher(_httpResponseProvider.Object))
                .WriteTo.Sink(new DelegatingSink(e => _logEvent = e))
                .CreateLogger();

            _httpResponseProvider.Setup(x => x.GetResponse()).Returns(_httpResponseWrapper.Object);
        }

        private Mock<IHttpResponseProvider> _httpResponseProvider;
        private Mock<IHttpResponseWrapper> _httpResponseWrapper;
        private ILogger _logger;
        private LogEvent _logEvent;

        [Test]
        public void ShouldCreateResponseStatusProperty()
        {
            _httpResponseWrapper.SetupGet(x => x.Status).Returns("200 OK");

            _logger.Information(@"Has a Response.Status property");

            Assert.NotNull(_logEvent);
            Assert.IsTrue(_logEvent.Properties.ContainsKey("Response.Status"));
            Assert.AreEqual("\"200 OK\"", _logEvent.Properties["Response.Status"].LiteralValue());
        }

        [Test]
        public void ShouldCreateResponseStatusCodeProperty()
        {
            _httpResponseWrapper.SetupGet(x => x.StatusCode).Returns(200);

            _logger.Information(@"Has a Response.StatusCode property");

            Assert.NotNull(_logEvent);
            Assert.IsTrue(_logEvent.Properties.ContainsKey("Response.StatusCode"));
            Assert.AreEqual("200", _logEvent.Properties["Response.StatusCode"].LiteralValue());
        }
    }
}

using System.Text;
using Moq;
using NUnit.Framework;
using Serilog.Enrichers;
using Serilog.Events;
using Serilog.Tests.Support;

namespace Serilog.Tests.Enrichers
{
    [TestFixture]
    [Parallelizable]
    public class ContentEncodingEnricherTests
    {
        [SetUp]
        public void SetUp()
        {
            _httpContextProvider = new Mock<IHttpContextProvider>();
            _httpContextWrapper = new Mock<IHttpContextWrapper>();
            _httpRequestWrapper = new Mock<IHttpRequestWrapper>();
            _logger = new LoggerConfiguration()
                .Enrich.With(new ContentEncodingEnricher(_httpContextProvider.Object))
                .WriteTo.Sink(new DelegatingSink(e => _logEvent = e))
                .CreateLogger();

            _httpContextProvider.Setup(x => x.GetCurrentContext()).Returns(_httpContextWrapper.Object);
            _httpContextWrapper.SetupGet(x => x.Request).Returns(_httpRequestWrapper.Object);
        }

        private Mock<IHttpContextProvider> _httpContextProvider;
        private Mock<IHttpContextWrapper> _httpContextWrapper;
        private Mock<IHttpRequestWrapper> _httpRequestWrapper;
        private ILogger _logger;
        private LogEvent _logEvent;

        [Test]
        public void ShouldCreateContentEncodingProperty()
        {
            var expected = Encoding.UTF32;

            _httpRequestWrapper.SetupGet(x => x.ContentEncoding).Returns(expected);

            _logger.Information(@"Has a ContentEncoding property");

            Assert.NotNull(_logEvent);
            Assert.NotNull(_logEvent.Properties["ContentEncoding"].LiteralValue());
            Assert.AreEqual($"{expected}", _logEvent.Properties["ContentEncoding"].LiteralValue());
        }
    }
}
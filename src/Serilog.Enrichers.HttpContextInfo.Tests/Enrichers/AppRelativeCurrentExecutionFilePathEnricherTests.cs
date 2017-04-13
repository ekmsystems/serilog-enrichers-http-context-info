using Moq;
using NUnit.Framework;
using Serilog.Enrichers;
using Serilog.Events;
using Serilog.Tests.Support;

namespace Serilog.Tests.Enrichers
{
    [TestFixture]
    [Parallelizable]
    public class AppRelativeCurrentExecutionFilePathEnricherTests
    {
        [SetUp]
        public void SetUp()
        {
            _httpContextProvider = new Mock<IHttpContextProvider>();
            _httpContextWrapper = new Mock<IHttpContextWrapper>();
            _httpRequestWrapper = new Mock<IHttpRequestWrapper>();
            _logger = new LoggerConfiguration()
                .Enrich.With(new AppRelativeCurrentExecutionFilePathEnricher(_httpContextProvider.Object))
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
        public void ShouldCreateAppRelativeCurrentExecutionFilePathProperty()
        {
            _httpRequestWrapper.SetupGet(x => x.AppRelativeCurrentExecutionFilePath).Returns("SET");

            _logger.Information(@"Has a AppRelativeCurrentExecutionFilePath property");

            Assert.NotNull(_logEvent);
            Assert.NotNull(_logEvent.Properties["AppRelativeCurrentExecutionFilePath"].LiteralValue());
            Assert.AreEqual("\"SET\"", _logEvent.Properties["AppRelativeCurrentExecutionFilePath"].LiteralValue());
        }
    }
}
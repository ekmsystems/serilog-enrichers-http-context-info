using System.Collections.Specialized;
using System.Diagnostics.CodeAnalysis;
using System.Web;
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

        [Test]
        [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
        public void ShouldCreateResponseCookiesProperties()
        {
            var cookies = new HttpCookieCollection
            {
                new HttpCookie("test-1", "My First Cookie!"),
                new HttpCookie("test-2", "My Second Cookie!"),
                new HttpCookie("test-3", "My Third Cookie!")
            };

            _httpResponseWrapper.SetupGet(x => x.Cookies).Returns(cookies);

            _logger.Information(@"Has Response.Cookies properties");

            Assert.IsNotNull(_logEvent);
            Assert.IsTrue(_logEvent.Properties.ContainsKey("Response.Cookies[test-1].Name"));
            Assert.IsTrue(_logEvent.Properties.ContainsKey("Response.Cookies[test-2].Name"));
            Assert.IsTrue(_logEvent.Properties.ContainsKey("Response.Cookies[test-3].Name"));
            Assert.AreEqual(cookies["test-1"].Name,
                _logEvent.Properties["Response.Cookies[test-1].Name"].LiteralValue());
            Assert.AreEqual(cookies["test-1"].Value,
                _logEvent.Properties["Response.Cookies[test-1].Value"].LiteralValue());
            Assert.AreEqual(cookies["test-1"].Domain,
                _logEvent.Properties["Response.Cookies[test-1].Domain"].LiteralValue());
            Assert.AreEqual(cookies["test-1"].Expires.ToString("u"),
                _logEvent.Properties["Response.Cookies[test-1].Expires"].LiteralValue());
            Assert.AreEqual(cookies["test-1"].Path,
                _logEvent.Properties["Response.Cookies[test-1].Path"].LiteralValue());
            Assert.AreEqual(cookies["test-2"].Name,
                _logEvent.Properties["Response.Cookies[test-2].Name"].LiteralValue());
            Assert.AreEqual(cookies["test-2"].Value,
                _logEvent.Properties["Response.Cookies[test-2].Value"].LiteralValue());
            Assert.AreEqual(cookies["test-2"].Domain,
                _logEvent.Properties["Response.Cookies[test-2].Domain"].LiteralValue());
            Assert.AreEqual(cookies["test-2"].Expires.ToString("u"),
                _logEvent.Properties["Response.Cookies[test-2].Expires"].LiteralValue());
            Assert.AreEqual(cookies["test-2"].Path,
                _logEvent.Properties["Response.Cookies[test-2].Path"].LiteralValue());
            Assert.AreEqual(cookies["test-3"].Name,
                _logEvent.Properties["Response.Cookies[test-3].Name"].LiteralValue());
            Assert.AreEqual(cookies["test-3"].Value,
                _logEvent.Properties["Response.Cookies[test-3].Value"].LiteralValue());
            Assert.AreEqual(cookies["test-3"].Domain,
                _logEvent.Properties["Response.Cookies[test-3].Domain"].LiteralValue());
            Assert.AreEqual(cookies["test-3"].Expires.ToString("u"),
                _logEvent.Properties["Response.Cookies[test-3].Expires"].LiteralValue());
            Assert.AreEqual(cookies["test-3"].Path,
                _logEvent.Properties["Response.Cookies[test-3].Path"].LiteralValue());
        }

        [Test]
        public void ShouldCreateResponseHeadersProperties()
        {
            var headers = new NameValueCollection
            {
                {"Accept", "application/json"},
                {"Content-Type", "application/json"},
                {"User-Agent", "NUnit-Test"}
            };

            _httpResponseWrapper.SetupGet(x => x.Headers).Returns(headers);

            _logger.Information(@"Has Response.Headers properties");

            Assert.IsNotNull(_logEvent);
            Assert.IsTrue(_logEvent.Properties.ContainsKey("Response.Headers[Accept]"));
            Assert.IsTrue(_logEvent.Properties.ContainsKey("Response.Headers[Content-Type]"));
            Assert.IsTrue(_logEvent.Properties.ContainsKey("Response.Headers[User-Agent]"));
            Assert.AreEqual(headers["Accept"], _logEvent.Properties["Response.Headers[Accept]"].LiteralValue());
            Assert.AreEqual(headers["Content-Type"], _logEvent.Properties["Response.Headers[Content-Type]"].LiteralValue());
            Assert.AreEqual(headers["User-Agent"], _logEvent.Properties["Response.Headers[User-Agent]"].LiteralValue());
        }
    }
}

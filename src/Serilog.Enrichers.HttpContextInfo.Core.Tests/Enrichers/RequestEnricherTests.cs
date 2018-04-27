using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.Extensions.Primitives;
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
    public class RequestEnricherTests
    {
        [SetUp]
        public void SetUp()
        {
            _httpRequestProvider = new Mock<IHttpRequestProvider>();
            _httpRequestWrapper = new Mock<IHttpRequestWrapper>();
            _logger = new LoggerConfiguration()
                .Enrich.With(new RequestEnricher(_httpRequestProvider.Object))
                .WriteTo.Sink(new DelegatingSink(e => _logEvent = e))
                .CreateLogger();

            _httpRequestProvider.Setup(x => x.GetRequest()).Returns(_httpRequestWrapper.Object);
        }

        private Mock<IHttpRequestProvider> _httpRequestProvider;
        private Mock<IHttpRequestWrapper> _httpRequestWrapper;
        private ILogger _logger;
        private LogEvent _logEvent;

        private static Mock<IFormFileWrapper> CreateMockHttpPostedFile(
            string filename,
            int length,
            string contentType)
        {
            var mock = new Mock<IFormFileWrapper>();

            mock.SetupGet(x => x.FileName).Returns(filename);
            mock.SetupGet(x => x.Length).Returns(length);
            mock.SetupGet(x => x.ContentType).Returns(contentType);

            return mock;
        }

        [Test]
        public void ShouldCreateRequestPathBaseProperty()
        {
            _httpRequestWrapper.SetupGet(x => x.PathBase).Returns("SET");

            _logger.Information(@"Has a Request.PathBase property");

            Assert.NotNull(_logEvent);
            Assert.IsTrue(_logEvent.Properties.ContainsKey("Request.PathBase"));
            Assert.AreEqual("\"SET\"", _logEvent.Properties["Request.PathBase"].LiteralValue());
        }

        [Test]
        public void ShouldCreateRequestContentLengthProperty()
        {
            _httpRequestWrapper.SetupGet(x => x.ContentLength).Returns(123);

            _logger.Information(@"Has a Request.ContentLength property");

            Assert.NotNull(_logEvent);
            Assert.IsTrue(_logEvent.Properties.ContainsKey("Request.ContentLength"));
            Assert.AreEqual("123", _logEvent.Properties["Request.ContentLength"].LiteralValue());
        }

        [Test]
        public void ShouldCreateRequestContentTypeProperty()
        {
            _httpRequestWrapper.SetupGet(x => x.ContentType).Returns("SET");

            _logger.Information(@"Has a Request.ContentType property");

            Assert.NotNull(_logEvent);
            Assert.IsTrue(_logEvent.Properties.ContainsKey("Request.ContentType"));
            Assert.AreEqual("\"SET\"", _logEvent.Properties["Request.ContentType"].LiteralValue());
        }

        [Test]
        public void ShouldCreateRequestMethodProperty()
        {
            _httpRequestWrapper.SetupGet(x => x.Method).Returns("GET");

            _logger.Information(@"Has a Request.Method property");

            Assert.NotNull(_logEvent);
            Assert.IsTrue(_logEvent.Properties.ContainsKey("Request.Method"));
            Assert.AreEqual("\"GET\"", _logEvent.Properties["Request.Method"].LiteralValue());
        }

        [Test]
        public void ShouldCreateRequestIsAuthenticatedProperty()
        {
            _httpRequestWrapper.SetupGet(x => x.IsAuthenticated).Returns(true);

            _logger.Information(@"Has a Request.IsAuthenticated property");

            Assert.NotNull(_logEvent);
            Assert.IsTrue(_logEvent.Properties.ContainsKey("Request.IsAuthenticated"));
            Assert.AreEqual("True", _logEvent.Properties["Request.IsAuthenticated"].LiteralValue());
        }

        [Test]
        public void ShouldCreateRequestIsHttpsProperty()
        {
            _httpRequestWrapper.SetupGet(x => x.IsHttps).Returns(true);

            _logger.Information(@"Has a Request.IsSecureConnection property");

            Assert.NotNull(_logEvent);
            Assert.IsTrue(_logEvent.Properties.ContainsKey("Request.IsHttps"));
            Assert.AreEqual("True", _logEvent.Properties["Request.IsHttps"].LiteralValue());
        }

        [Test]
        public void ShouldCreateRequestPathProperty()
        {
            _httpRequestWrapper.SetupGet(x => x.Path).Returns("SET");

            _logger.Information(@"Has a Request.Path property");

            Assert.NotNull(_logEvent);
            Assert.IsTrue(_logEvent.Properties.ContainsKey("Request.Path"));
            Assert.AreEqual("\"SET\"", _logEvent.Properties["Request.Path"].LiteralValue());
        }

        [Test]
        public void ShouldCreateRequestUserHostAddressProperty()
        {
            _httpRequestWrapper.SetupGet(x => x.Host).Returns("SET");

            _logger.Information(@"Has a Request.UserHostAddress property");

            Assert.NotNull(_logEvent);
            Assert.IsTrue(_logEvent.Properties.ContainsKey("Request.Host"));
            Assert.AreEqual("\"SET\"", _logEvent.Properties["Request.Host"].LiteralValue());
        }

        [Test]
        public void ShouldCreateRequestFilesProperties()
        {
            var collection = new Mock<IFormFileCollectionWrapper>();
            var files = new[]
            {
                CreateMockHttpPostedFile("test1.aspx", 1, "content-type-1"),
                CreateMockHttpPostedFile("test2.aspx", 2, "content-type-2"),
                CreateMockHttpPostedFile("test3.aspx", 3, "content-type-3")
            };

            _httpRequestWrapper.SetupGet(x => x.Files).Returns(collection.Object);
            collection.SetupGet(x => x.AllKeys).Returns(files.Select(x => x.Object.FileName).ToArray());
            collection
                .Setup(x => x.Get(It.IsAny<string>()))
                .Returns((string key) => files.Single(x => x.Object.FileName == key).Object);

            _logger.Information(@"Has Request.Files properties");

            Assert.IsNotNull(_logEvent);
            Assert.IsTrue(_logEvent.Properties.ContainsKey("Request.Files[test1.aspx].FileName"));
            Assert.IsTrue(_logEvent.Properties.ContainsKey("Request.Files[test2.aspx].FileName"));
            Assert.IsTrue(_logEvent.Properties.ContainsKey("Request.Files[test3.aspx].FileName"));
            Assert.AreEqual("test1.aspx", _logEvent.Properties["Request.Files[test1.aspx].FileName"].LiteralValue());
            Assert.AreEqual(1, _logEvent.Properties["Request.Files[test1.aspx].Length"].LiteralValue());
            Assert.AreEqual("content-type-1", _logEvent.Properties["Request.Files[test1.aspx].ContentType"].LiteralValue());
            Assert.AreEqual("test2.aspx", _logEvent.Properties["Request.Files[test2.aspx].FileName"].LiteralValue());
            Assert.AreEqual(2, _logEvent.Properties["Request.Files[test2.aspx].Length"].LiteralValue());
            Assert.AreEqual("content-type-2", _logEvent.Properties["Request.Files[test2.aspx].ContentType"].LiteralValue());
            Assert.AreEqual("test3.aspx", _logEvent.Properties["Request.Files[test3.aspx].FileName"].LiteralValue());
            Assert.AreEqual(3, _logEvent.Properties["Request.Files[test3.aspx].Length"].LiteralValue());
            Assert.AreEqual("content-type-3", _logEvent.Properties["Request.Files[test3.aspx].ContentType"].LiteralValue());
        }

        [Test]
        public void ShouldCreateRequestFormProperties()
        {
            var form = new FormCollection(new Dictionary<string, StringValues>() {
                { "username", new StringValues("john_smith") },
                { "password", new StringValues("mega-secure-password") }
            });

            _httpRequestWrapper.SetupGet(x => x.Form).Returns(form);

            _logger.Information(@"Has Request.Form properties");

            Assert.IsNotNull(_logEvent);
            Assert.IsTrue(_logEvent.Properties.ContainsKey("Request.Form[username]"));
            Assert.IsTrue(_logEvent.Properties.ContainsKey("Request.Form[password]"));
            Assert.AreEqual(form["username"], _logEvent.Properties["Request.Form[username]"].LiteralValue());
            Assert.AreEqual(form["password"], _logEvent.Properties["Request.Form[password]"].LiteralValue());
        }

        [Test]
        public void ShouldCreateRequestHeadersProperties()
        {
            var headers = new HeaderDictionary(new Dictionary<string, StringValues> {
                { "Accept", "application/json" },
                { "Content-Type", "application/json" },
                { "User-Agent", "NUnit-Test" } });

            _httpRequestWrapper.SetupGet(x => x.Headers).Returns(headers);

            _logger.Information(@"Has Request.Headers properties");

            Assert.IsNotNull(_logEvent);
            Assert.IsTrue(_logEvent.Properties.ContainsKey("Request.Headers[Accept]"));
            Assert.IsTrue(_logEvent.Properties.ContainsKey("Request.Headers[Content-Type]"));
            Assert.IsTrue(_logEvent.Properties.ContainsKey("Request.Headers[User-Agent]"));
            Assert.AreEqual(headers["Accept"], _logEvent.Properties["Request.Headers[Accept]"].LiteralValue());
            Assert.AreEqual(headers["Content-Type"], _logEvent.Properties["Request.Headers[Content-Type]"].LiteralValue());
            Assert.AreEqual(headers["User-Agent"], _logEvent.Properties["Request.Headers[User-Agent]"].LiteralValue());
        }

        [Test]
        [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
        public void ShouldCreateRequestCookiesProperties()
        {
            var cookies = new RequestCookieCollection(new Dictionary<string, string> {
                { "test-1", "My First Cookie!" },{  "test-2", "My Second Cookie!" },{ "test-3", "My Third Cookie!" } });

            _httpRequestWrapper.SetupGet(x => x.Cookies).Returns(cookies);

            _logger.Information(@"Has Request.Cookies properties");

            Assert.IsNotNull(_logEvent);
            Assert.IsTrue(_logEvent.Properties.ContainsKey("Request.Cookies[test-1]"));
            Assert.IsTrue(_logEvent.Properties.ContainsKey("Request.Cookies[test-2]"));
            Assert.IsTrue(_logEvent.Properties.ContainsKey("Request.Cookies[test-3]"));
            Assert.AreEqual(cookies["test-1"],
                _logEvent.Properties["Request.Cookies[test-1]"].LiteralValue());
            Assert.AreEqual(cookies["test-2"],
                _logEvent.Properties["Request.Cookies[test-2]"].LiteralValue());
            Assert.AreEqual(cookies["test-3"],
                _logEvent.Properties["Request.Cookies[test-3]"].LiteralValue());
        }
    }
}
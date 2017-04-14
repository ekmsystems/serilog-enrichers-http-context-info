using System;
using System.Text;
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

            _httpRequestProvider.Setup(x => x.GetCurrentRequest()).Returns(_httpRequestWrapper.Object);
        }

        private Mock<IHttpRequestProvider> _httpRequestProvider;
        private Mock<IHttpRequestWrapper> _httpRequestWrapper;
        private ILogger _logger;
        private LogEvent _logEvent;

        [Test]
        public void ShouldCreateRequestAnonymousIDProperty()
        {
            _httpRequestWrapper.SetupGet(x => x.AnonymousID).Returns("SET");

            _logger.Information(@"Has a Request.AnonymousID property");

            Assert.NotNull(_logEvent);
            Assert.NotNull(_logEvent.Properties["Request.AnonymousID"].LiteralValue());
        }


        [Test]
        public void ShouldCreateRequestApplicationPathProperty()
        {
            _httpRequestWrapper.SetupGet(x => x.ApplicationPath).Returns("SET");

            _logger.Information(@"Has a Request.ApplicationPath property");

            Assert.NotNull(_logEvent);
            Assert.NotNull(_logEvent.Properties["Request.ApplicationPath"].LiteralValue());
        }

        [Test]
        public void ShouldCreateRequestContentEncodingProperty()
        {
            _httpRequestWrapper.SetupGet(x => x.ContentEncoding).Returns(Encoding.UTF32);

            _logger.Information(@"Has a Request.ContentEncoding property");

            Assert.NotNull(_logEvent);
            Assert.NotNull(_logEvent.Properties["Request.ContentEncoding"].LiteralValue());
        }


        [Test]
        public void ShouldCreateRequestContentLengthProperty()
        {
            _httpRequestWrapper.SetupGet(x => x.ContentLength).Returns(123);

            _logger.Information(@"Has a Request.ContentLength property");

            Assert.NotNull(_logEvent);
            Assert.NotNull(_logEvent.Properties["Request.ContentLength"].LiteralValue());
        }


        [Test]
        public void ShouldCreateRequestContentTypeProperty()
        {
            _httpRequestWrapper.SetupGet(x => x.ContentType).Returns("SET");

            _logger.Information(@"Has a Request.ContentType property");

            Assert.NotNull(_logEvent);
            Assert.NotNull(_logEvent.Properties["Request.ContentType"].LiteralValue());
        }


        [Test]
        public void ShouldCreateRequestCurrentExecutionFilePathExtensionProperty()
        {
            _httpRequestWrapper.SetupGet(x => x.CurrentExecutionFilePathExtension).Returns("SET");

            _logger.Information(@"Has a Request.CurrentExecutionFilePathExtension property");

            Assert.NotNull(_logEvent);
            Assert.NotNull(_logEvent.Properties["Request.CurrentExecutionFilePathExtension"].LiteralValue());
        }

        [Test]
        public void ShouldCreateRequestCurrentExecutionFilePathProperty()
        {
            _httpRequestWrapper.SetupGet(x => x.CurrentExecutionFilePath).Returns("SET");

            _logger.Information(@"Has a Request.CurrentExecutionFilePath property");

            Assert.NotNull(_logEvent);
            Assert.NotNull(_logEvent.Properties["Request.CurrentExecutionFilePath"].LiteralValue());
        }


        [Test]
        public void ShouldCreateRequestFilePathProperty()
        {
            _httpRequestWrapper.SetupGet(x => x.FilePath).Returns("SET");

            _logger.Information(@"Has a Request.FilePath property");

            Assert.NotNull(_logEvent);
            Assert.NotNull(_logEvent.Properties["Request.FilePath"].LiteralValue());
        }


        [Test]
        public void ShouldCreateRequestHttpMethodProperty()
        {
            _httpRequestWrapper.SetupGet(x => x.HttpMethod).Returns("GET");

            _logger.Information(@"Has a Request.HttpMethod property");

            Assert.NotNull(_logEvent);
            Assert.NotNull(_logEvent.Properties["Request.HttpMethod"].LiteralValue());
        }


        [Test]
        public void ShouldCreateRequestIsAuthenticatedProperty()
        {
            _httpRequestWrapper.SetupGet(x => x.IsAuthenticated).Returns(true);

            _logger.Information(@"Has a Request.IsAuthenticated property");

            Assert.NotNull(_logEvent);
            Assert.NotNull(_logEvent.Properties["Request.IsAuthenticated"].LiteralValue());
        }


        [Test]
        public void ShouldCreateRequestIsLocalProperty()
        {
            _httpRequestWrapper.SetupGet(x => x.IsLocal).Returns(true);

            _logger.Information(@"Has a Request.IsLocal property");

            Assert.NotNull(_logEvent);
            Assert.NotNull(_logEvent.Properties["Request.IsLocal"].LiteralValue());
        }


        [Test]
        public void ShouldCreateRequestIsSecureConnectionProperty()
        {
            _httpRequestWrapper.SetupGet(x => x.IsSecureConnection).Returns(true);

            _logger.Information(@"Has a Request.IsSecureConnection property");

            Assert.NotNull(_logEvent);
            Assert.NotNull(_logEvent.Properties["Request.IsSecureConnection"].LiteralValue());
        }


        [Test]
        public void ShouldCreateRequestPathInfoProperty()
        {
            _httpRequestWrapper.SetupGet(x => x.PathInfo).Returns("SET");

            _logger.Information(@"Has a Request.PathInfo property");

            Assert.NotNull(_logEvent);
            Assert.NotNull(_logEvent.Properties["Request.PathInfo"].LiteralValue());
        }


        [Test]
        public void ShouldCreateRequestPathProperty()
        {
            _httpRequestWrapper.SetupGet(x => x.Path).Returns("SET");

            _logger.Information(@"Has a Request.Path property");

            Assert.NotNull(_logEvent);
            Assert.NotNull(_logEvent.Properties["Request.Path"].LiteralValue());
        }


        [Test]
        public void ShouldCreateRequestPhysicalApplicationPathProperty()
        {
            _httpRequestWrapper.SetupGet(x => x.PhysicalApplicationPath).Returns("SET");

            _logger.Information(@"Has a Request.PhysicalApplicationPath property");

            Assert.NotNull(_logEvent);
            Assert.NotNull(_logEvent.Properties["Request.PhysicalApplicationPath"].LiteralValue());
        }


        [Test]
        public void ShouldCreateRequestPhysicalPathProperty()
        {
            _httpRequestWrapper.SetupGet(x => x.PhysicalPath).Returns("SET");

            _logger.Information(@"Has a Request.PhysicalPath property");

            Assert.NotNull(_logEvent);
            Assert.NotNull(_logEvent.Properties["Request.PhysicalPath"].LiteralValue());
        }


        [Test]
        public void ShouldCreateRequestRawUrlProperty()
        {
            _httpRequestWrapper.SetupGet(x => x.RawUrl).Returns("SET");

            _logger.Information(@"Has a Request.RawUrl property");

            Assert.NotNull(_logEvent);
            Assert.NotNull(_logEvent.Properties["Request.RawUrl"].LiteralValue());
        }


        [Test]
        public void ShouldCreateRequestRequestTypeProperty()
        {
            _httpRequestWrapper.SetupGet(x => x.RequestType).Returns("SET");

            _logger.Information(@"Has a Request.RequestType property");

            Assert.NotNull(_logEvent);
            Assert.NotNull(_logEvent.Properties["Request.RequestType"].LiteralValue());
        }


        [Test]
        public void ShouldCreateRequestTotalBytesProperty()
        {
            _httpRequestWrapper.SetupGet(x => x.TotalBytes).Returns(0);

            _logger.Information(@"Has a Request.TotalBytes property");

            Assert.NotNull(_logEvent);
            Assert.NotNull(_logEvent.Properties["Request.TotalBytes"].LiteralValue());
        }


        [Test]
        public void ShouldCreateRequestUrlProperty()
        {
            _httpRequestWrapper.SetupGet(x => x.Url).Returns(new Uri("http://serilog.net/"));

            _logger.Information(@"Has a Request.Url property");

            Assert.NotNull(_logEvent);
            Assert.NotNull(_logEvent.Properties["Request.Url"].LiteralValue());
        }


        [Test]
        public void ShouldCreateRequestUrlReferrerProperty()
        {
            _httpRequestWrapper.SetupGet(x => x.UrlReferrer).Returns(new Uri("http://serilog.net/"));

            _logger.Information(@"Has a Request.UrlReferrer property");

            Assert.NotNull(_logEvent);
            Assert.NotNull(_logEvent.Properties["Request.UrlReferrer"].LiteralValue());
        }


        [Test]
        public void ShouldCreateRequestUserAgentProperty()
        {
            _httpRequestWrapper.SetupGet(x => x.UserAgent).Returns("SET");

            _logger.Information(@"Has a Request.UserAgent property");

            Assert.NotNull(_logEvent);
            Assert.NotNull(_logEvent.Properties["Request.UserAgent"].LiteralValue());
        }


        [Test]
        public void ShouldCreateRequestUserHostAddressProperty()
        {
            _httpRequestWrapper.SetupGet(x => x.UserHostAddress).Returns("SET");

            _logger.Information(@"Has a Request.UserHostAddress property");

            Assert.NotNull(_logEvent);
            Assert.NotNull(_logEvent.Properties["Request.UserHostAddress"].LiteralValue());
        }


        [Test]
        public void ShouldCreateRequestUserHostNameProperty()
        {
            _httpRequestWrapper.SetupGet(x => x.UserHostName).Returns("SET");

            _logger.Information(@"Has a Request.UserHostName property");

            Assert.NotNull(_logEvent);
            Assert.NotNull(_logEvent.Properties["Request.UserHostName"].LiteralValue());
        }
    }
}
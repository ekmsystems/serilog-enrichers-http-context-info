using System;
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
        public void ShouldCreateAnonymousIDProperty()
        {
            _httpRequestWrapper.SetupGet(x => x.AnonymousID).Returns("SET");

            _logger.Information(@"Has a AnonymousID property");

            Assert.NotNull(_logEvent);
            Assert.NotNull(_logEvent.Properties["AnonymousID"].LiteralValue());
        }


        [Test]
        public void ShouldCreateApplicationPathProperty()
        {
            _httpRequestWrapper.SetupGet(x => x.ApplicationPath).Returns("SET");

            _logger.Information(@"Has a ApplicationPath property");

            Assert.NotNull(_logEvent);
            Assert.NotNull(_logEvent.Properties["ApplicationPath"].LiteralValue());
        }

        [Test]
        public void ShouldCreateContentEncodingProperty()
        {
            _httpRequestWrapper.SetupGet(x => x.ContentEncoding).Returns(Encoding.UTF32);

            _logger.Information(@"Has a ContentEncoding property");

            Assert.NotNull(_logEvent);
            Assert.NotNull(_logEvent.Properties["ContentEncoding"].LiteralValue());
        }


        [Test]
        public void ShouldCreateContentLengthProperty()
        {
            _httpRequestWrapper.SetupGet(x => x.ContentLength).Returns(123);

            _logger.Information(@"Has a ContentLength property");

            Assert.NotNull(_logEvent);
            Assert.NotNull(_logEvent.Properties["ContentLength"].LiteralValue());
        }


        [Test]
        public void ShouldCreateContentTypeProperty()
        {
            _httpRequestWrapper.SetupGet(x => x.ContentType).Returns("SET");

            _logger.Information(@"Has a ContentType property");

            Assert.NotNull(_logEvent);
            Assert.NotNull(_logEvent.Properties["ContentType"].LiteralValue());
        }


        [Test]
        public void ShouldCreateCurrentExecutionFilePathExtensionProperty()
        {
            _httpRequestWrapper.SetupGet(x => x.CurrentExecutionFilePathExtension).Returns("SET");

            _logger.Information(@"Has a CurrentExecutionFilePathExtension property");

            Assert.NotNull(_logEvent);
            Assert.NotNull(_logEvent.Properties["CurrentExecutionFilePathExtension"].LiteralValue());
        }

        [Test]
        public void ShouldCreateCurrentExecutionFilePathProperty()
        {
            _httpRequestWrapper.SetupGet(x => x.CurrentExecutionFilePath).Returns("SET");

            _logger.Information(@"Has a CurrentExecutionFilePath property");

            Assert.NotNull(_logEvent);
            Assert.NotNull(_logEvent.Properties["CurrentExecutionFilePath"].LiteralValue());
        }


        [Test]
        public void ShouldCreateFilePathProperty()
        {
            _httpRequestWrapper.SetupGet(x => x.FilePath).Returns("SET");

            _logger.Information(@"Has a FilePath property");

            Assert.NotNull(_logEvent);
            Assert.NotNull(_logEvent.Properties["FilePath"].LiteralValue());
        }


        [Test]
        public void ShouldCreateHttpMethodProperty()
        {
            _httpRequestWrapper.SetupGet(x => x.HttpMethod).Returns("GET");

            _logger.Information(@"Has a HttpMethod property");

            Assert.NotNull(_logEvent);
            Assert.NotNull(_logEvent.Properties["HttpMethod"].LiteralValue());
        }


        [Test]
        public void ShouldCreateIsAuthenticatedProperty()
        {
            _httpRequestWrapper.SetupGet(x => x.IsAuthenticated).Returns(true);

            _logger.Information(@"Has a IsAuthenticated property");

            Assert.NotNull(_logEvent);
            Assert.NotNull(_logEvent.Properties["IsAuthenticated"].LiteralValue());
        }


        [Test]
        public void ShouldCreateIsLocalProperty()
        {
            _httpRequestWrapper.SetupGet(x => x.IsLocal).Returns(true);

            _logger.Information(@"Has a IsLocal property");

            Assert.NotNull(_logEvent);
            Assert.NotNull(_logEvent.Properties["IsLocal"].LiteralValue());
        }


        [Test]
        public void ShouldCreateIsSecureConnectionProperty()
        {
            _httpRequestWrapper.SetupGet(x => x.IsSecureConnection).Returns(true);

            _logger.Information(@"Has a IsSecureConnection property");

            Assert.NotNull(_logEvent);
            Assert.NotNull(_logEvent.Properties["IsSecureConnection"].LiteralValue());
        }


        [Test]
        public void ShouldCreatePathInfoProperty()
        {
            _httpRequestWrapper.SetupGet(x => x.PathInfo).Returns("SET");

            _logger.Information(@"Has a PathInfo property");

            Assert.NotNull(_logEvent);
            Assert.NotNull(_logEvent.Properties["PathInfo"].LiteralValue());
        }


        [Test]
        public void ShouldCreatePathProperty()
        {
            _httpRequestWrapper.SetupGet(x => x.Path).Returns("SET");

            _logger.Information(@"Has a Path property");

            Assert.NotNull(_logEvent);
            Assert.NotNull(_logEvent.Properties["Path"].LiteralValue());
        }


        [Test]
        public void ShouldCreatePhysicalApplicationPathProperty()
        {
            _httpRequestWrapper.SetupGet(x => x.PhysicalApplicationPath).Returns("SET");

            _logger.Information(@"Has a PhysicalApplicationPath property");

            Assert.NotNull(_logEvent);
            Assert.NotNull(_logEvent.Properties["PhysicalApplicationPath"].LiteralValue());
        }


        [Test]
        public void ShouldCreatePhysicalPathProperty()
        {
            _httpRequestWrapper.SetupGet(x => x.PhysicalPath).Returns("SET");

            _logger.Information(@"Has a PhysicalPath property");

            Assert.NotNull(_logEvent);
            Assert.NotNull(_logEvent.Properties["PhysicalPath"].LiteralValue());
        }


        [Test]
        public void ShouldCreateRawUrlProperty()
        {
            _httpRequestWrapper.SetupGet(x => x.RawUrl).Returns("SET");

            _logger.Information(@"Has a RawUrl property");

            Assert.NotNull(_logEvent);
            Assert.NotNull(_logEvent.Properties["RawUrl"].LiteralValue());
        }


        [Test]
        public void ShouldCreateRequestTypeProperty()
        {
            _httpRequestWrapper.SetupGet(x => x.RequestType).Returns("SET");

            _logger.Information(@"Has a RequestType property");

            Assert.NotNull(_logEvent);
            Assert.NotNull(_logEvent.Properties["RequestType"].LiteralValue());
        }


        [Test]
        public void ShouldCreateTotalBytesProperty()
        {
            _httpRequestWrapper.SetupGet(x => x.TotalBytes).Returns(0);

            _logger.Information(@"Has a TotalBytes property");

            Assert.NotNull(_logEvent);
            Assert.NotNull(_logEvent.Properties["TotalBytes"].LiteralValue());
        }


        [Test]
        public void ShouldCreateUrlProperty()
        {
            _httpRequestWrapper.SetupGet(x => x.Url).Returns(new Uri("http://serilog.net/"));

            _logger.Information(@"Has a Url property");

            Assert.NotNull(_logEvent);
            Assert.NotNull(_logEvent.Properties["Url"].LiteralValue());
        }


        [Test]
        public void ShouldCreateUrlReferrerProperty()
        {
            _httpRequestWrapper.SetupGet(x => x.UrlReferrer).Returns(new Uri("http://serilog.net/"));

            _logger.Information(@"Has a UrlReferrer property");

            Assert.NotNull(_logEvent);
            Assert.NotNull(_logEvent.Properties["UrlReferrer"].LiteralValue());
        }


        [Test]
        public void ShouldCreateUserAgentProperty()
        {
            _httpRequestWrapper.SetupGet(x => x.UserAgent).Returns("SET");

            _logger.Information(@"Has a UserAgent property");

            Assert.NotNull(_logEvent);
            Assert.NotNull(_logEvent.Properties["UserAgent"].LiteralValue());
        }


        [Test]
        public void ShouldCreateUserHostAddressProperty()
        {
            _httpRequestWrapper.SetupGet(x => x.UserHostAddress).Returns("SET");

            _logger.Information(@"Has a UserHostAddress property");

            Assert.NotNull(_logEvent);
            Assert.NotNull(_logEvent.Properties["UserHostAddress"].LiteralValue());
        }


        [Test]
        public void ShouldCreateUserHostNameProperty()
        {
            _httpRequestWrapper.SetupGet(x => x.UserHostName).Returns("SET");

            _logger.Information(@"Has a UserHostName property");

            Assert.NotNull(_logEvent);
            Assert.NotNull(_logEvent.Properties["UserHostName"].LiteralValue());
        }
    }
}
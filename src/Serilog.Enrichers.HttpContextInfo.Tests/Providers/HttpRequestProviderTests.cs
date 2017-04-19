using System.IO;
using System.Web;
using NUnit.Framework;
using Serilog.Providers;

namespace Serilog.Tests.Providers
{
    [TestFixture]
    [Parallelizable]
    public class HttpRequestProviderTests
    {
        [SetUp]
        public void SetUp()
        {
            _httpRequestProvider = new HttpRequestProvider();
        }

        private IHttpRequestProvider _httpRequestProvider;

        [Test]
        public void GetRequest_ShouldReturnTheCurrentHttpContextRequest()
        {
            var request = new HttpRequest("test", "http://serilog.net/", "");
            var response = new HttpResponse(new StringWriter());
            HttpContext.Current = new HttpContext(request, response);

            var result = _httpRequestProvider.GetRequest();

            Assert.AreEqual("http://serilog.net/", result.Url.ToString());
        }
    }
}
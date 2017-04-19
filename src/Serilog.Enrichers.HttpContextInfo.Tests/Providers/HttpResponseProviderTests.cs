using System.IO;
using System.Web;
using NUnit.Framework;
using Serilog.Providers;

namespace Serilog.Tests.Providers
{
    [TestFixture]
    [Parallelizable]
    public class HttpResponseProviderTests
    {
        [SetUp]
        public void SetUp()
        {
            _httpResponseProvider = new HttpResponseProvider();
        }

        private IHttpResponseProvider _httpResponseProvider;

        [Test]
        public void GetResponse_ShouldReturnTheCurrentHttpContextRequest()
        {
            var request = new HttpRequest("test", "http://serilog.net/", "");
            var response = new HttpResponse(new StringWriter());
            HttpContext.Current = new HttpContext(request, response);

            response.StatusCode = 200;

            var result = _httpResponseProvider.GetResponse();

            Assert.AreEqual(200, result.StatusCode);
            Assert.AreEqual("200 OK", result.Status);
        }
    }
}
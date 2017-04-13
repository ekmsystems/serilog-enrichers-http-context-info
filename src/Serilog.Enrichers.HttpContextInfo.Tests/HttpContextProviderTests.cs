using System.IO;
using System.Text;
using System.Web;
using NUnit.Framework;

namespace Serilog.Tests
{
    [TestFixture]
    [Parallelizable]
    public class HttpContextProviderTests
    {
        [SetUp]
        public void SetUp()
        {
            _httpContextProvider = new HttpContextProvider();
        }

        private IHttpContextProvider _httpContextProvider;

        [Test]
        public void GetCurrentContextShouldReturnTheCurrentHttpContext()
        {
            var sb = new StringBuilder();
            var request = new HttpRequest("test", "http://serilog.net/", "");
            var response = new HttpResponse(new StringWriter(sb));
            HttpContext.Current = new HttpContext(request, response);

            var result = _httpContextProvider.GetCurrentContext();

            result.Response.Output.Write("Welcome to Aperture Science");

            Assert.AreEqual("http://serilog.net/", result.Request.Url.ToString());
            Assert.AreEqual("Welcome to Aperture Science", sb.ToString());
        }
    }
}

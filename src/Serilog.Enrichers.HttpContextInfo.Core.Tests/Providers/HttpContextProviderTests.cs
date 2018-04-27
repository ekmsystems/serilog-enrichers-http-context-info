using System;
using System.IO;
using System.Text;
using System.Web;
using Microsoft.AspNetCore.Http;
using Moq;
using NUnit.Framework;
using Serilog.Providers;

namespace Serilog.Tests.Providers
{
    [TestFixture]
    [Parallelizable]
    public class HttpContextProviderTests
    {
        [SetUp]
        public void SetUp()
        {
            var request = new Mock<HttpRequest>();
            request.SetupGet(r => r.Path).Returns("/test");
            var response = new Mock<HttpResponse>();
            var body = new MemoryStream(Encoding.Default.GetBytes("Welcome to Aperture Science"));
            response.SetupGet(r => r.Body).Returns(body);

            var httpContext = new Mock<HttpContext>();
            httpContext.SetupGet(h => h.Request).Returns(request.Object);
            httpContext.SetupGet(h => h.Response).Returns(response.Object);

            var httpContextAccessor = new Mock<IHttpContextAccessor>();
            httpContextAccessor.SetupGet(a => a.HttpContext).Returns(httpContext.Object);

            _httpContextProvider = new HttpContextProvider(httpContextAccessor.Object);
        }

        private IHttpContextProvider _httpContextProvider;

        [Test]
        public void GetCurrentContextShouldReturnTheCurrentHttpContext()
        {
            var result = _httpContextProvider.GetCurrentContext();

            Assert.AreEqual("/test", result.Request.Path);
            //Assert.AreEqual("Welcome to Aperture Science", result.Response.Bo);
        }
    }
}
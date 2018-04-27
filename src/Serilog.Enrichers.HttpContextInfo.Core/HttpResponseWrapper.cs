using Microsoft.AspNetCore.Http;
using System.Collections.Specialized;
using System.IO;
using System.Web;

namespace Serilog
{
    public interface IHttpResponseWrapper
    {
        string ContentType { get; }
        IResponseCookies Cookies { get; }
        IHeaderDictionary Headers { get; }
        int StatusCode { get; }
    }

    internal class HttpResponseWrapper : IHttpResponseWrapper
    {
        private readonly HttpResponse _httpResponse;

        public HttpResponseWrapper(HttpResponse httpResponse)
        {
            _httpResponse = httpResponse;
        }

        public string ContentType => _httpResponse.ContentType;
        public IResponseCookies Cookies => _httpResponse.Cookies;
        public IHeaderDictionary Headers => _httpResponse.Headers;
        public int StatusCode => _httpResponse.StatusCode;
    }
}
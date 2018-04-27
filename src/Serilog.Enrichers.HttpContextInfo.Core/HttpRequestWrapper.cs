using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Specialized;
using System.Text;
using System.Web;

namespace Serilog
{
    public interface IHttpRequestWrapper
    {
        string PathBase { get; }
        string Path { get; }
        long? ContentLength { get; }
        string ContentType { get; }
        IRequestCookieCollection Cookies { get; }
        IFormFileCollectionWrapper Files { get; }
        IFormCollection Form { get; }
        IHeaderDictionary Headers { get; }
        string Method { get; }
        bool IsAuthenticated { get; }
        bool IsHttps { get; }
        string Host { get; }
        string Protocol { get; }
        string Scheme { get; }
        string QueryString { get; }
    }

    internal class HttpRequestWrapper : IHttpRequestWrapper
    {
        private readonly HttpRequest _httpRequest;

        public HttpRequestWrapper(HttpRequest httpRequest)
        {
            _httpRequest = httpRequest;
        }

        public string PathBase => _httpRequest.PathBase;
        public string Path => _httpRequest.Path;
        public long? ContentLength => _httpRequest.ContentLength;
        public string ContentType => _httpRequest.ContentType;
        public IRequestCookieCollection Cookies => _httpRequest.Cookies;
        public IFormFileCollectionWrapper Files => new HttpFileCollectionWrapper(_httpRequest.Form.Files);
        public IFormCollection Form => _httpRequest.Form;
        public IHeaderDictionary Headers => _httpRequest.Headers;
        public string Method => _httpRequest.Method;
        public bool IsAuthenticated => _httpRequest.HttpContext.User.Identity.IsAuthenticated;
        public bool IsHttps => _httpRequest.IsHttps;
        public string Host => _httpRequest.Host.Host;
        public string Protocol => _httpRequest.Protocol;
        public string Scheme => _httpRequest.Scheme;
        public string QueryString => Convert.ToString(_httpRequest.QueryString);
    }
}
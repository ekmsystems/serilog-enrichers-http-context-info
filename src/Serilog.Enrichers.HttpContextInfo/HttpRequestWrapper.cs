using System;
using System.Collections.Specialized;
using System.Text;
using System.Web;

namespace Serilog
{
    public interface IHttpRequestWrapper
    {
        string[] AcceptTypes { get; }
        string AnonymousID { get; }
        string ApplicationPath { get; }
        Encoding ContentEncoding { get; }
        int ContentLength { get; }
        string ContentType { get; }
        IHttpFileCollectionWrapper Files { get; }
        NameValueCollection Form { get; }
        NameValueCollection Headers { get; }
        string HttpMethod { get; }
        bool IsAuthenticated { get; }
        bool IsLocal { get; }
        bool IsSecureConnection { get; }
        NameValueCollection Params { get; }
        string PhysicalApplicationPath { get; }
        string PhysicalPath { get; }
        string RawUrl { get; }
        string RequestType { get; }
        int TotalBytes { get; }
        Uri Url { get; }
        Uri UrlReferrer { get; }
        string UserAgent { get; }
        string UserHostAddress { get; }
        string UserHostName { get; }
    }

    internal class HttpRequestWrapper : IHttpRequestWrapper
    {
        private readonly HttpRequest _httpRequest;

        public HttpRequestWrapper(HttpRequest httpRequest)
        {
            _httpRequest = httpRequest;
        }

        public string[] AcceptTypes => _httpRequest.AcceptTypes;
        public string AnonymousID => _httpRequest.AnonymousID;
        public string ApplicationPath => _httpRequest.ApplicationPath;
        public Encoding ContentEncoding => _httpRequest.ContentEncoding;
        public int ContentLength => _httpRequest.ContentLength;
        public string ContentType => _httpRequest.ContentType;
        public IHttpFileCollectionWrapper Files => new HttpFileCollectionWrapper(_httpRequest.Files);
        public NameValueCollection Form => _httpRequest.Form;
        public NameValueCollection Headers => _httpRequest.Headers;
        public string HttpMethod => _httpRequest.HttpMethod;
        public bool IsAuthenticated => _httpRequest.IsAuthenticated;
        public bool IsLocal => _httpRequest.IsLocal;
        public bool IsSecureConnection => _httpRequest.IsSecureConnection;
        public NameValueCollection Params => _httpRequest.Params;
        public string PhysicalApplicationPath => _httpRequest.PhysicalApplicationPath;
        public string PhysicalPath => _httpRequest.PhysicalPath;
        public string RawUrl => _httpRequest.RawUrl;
        public string RequestType => _httpRequest.RequestType;
        public int TotalBytes => _httpRequest.TotalBytes;
        public Uri Url => _httpRequest.Url;
        public Uri UrlReferrer => _httpRequest.UrlReferrer;
        public string UserAgent => _httpRequest.UserAgent;
        public string UserHostAddress => _httpRequest.UserHostAddress;
        public string UserHostName => _httpRequest.UserHostName;
    }
}
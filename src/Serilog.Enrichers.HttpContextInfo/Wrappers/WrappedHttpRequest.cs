using System;
using System.Text;
using System.Web;

namespace Serilog.Wrappers
{
    internal class WrappedHttpRequest : IHttpRequestWrapper
    {
        private readonly HttpRequest _httpRequest;

        public WrappedHttpRequest(HttpRequest httpRequest)
        {
            _httpRequest = httpRequest;
        }

        public string AnonymousID => _httpRequest.AnonymousID;
        public string ApplicationPath => _httpRequest.ApplicationPath;
        public Encoding ContentEncoding => _httpRequest.ContentEncoding;
        public int ContentLength => _httpRequest.ContentLength;
        public string ContentType => _httpRequest.ContentType;
        public string CurrentExecutionFilePath => _httpRequest.CurrentExecutionFilePath;
        public string CurrentExecutionFilePathExtension => _httpRequest.CurrentExecutionFilePathExtension;
        public string FilePath => _httpRequest.FilePath;
        public string HttpMethod => _httpRequest.HttpMethod;
        public bool IsAuthenticated => _httpRequest.IsAuthenticated;
        public bool IsLocal => _httpRequest.IsLocal;
        public bool IsSecureConnection => _httpRequest.IsSecureConnection;
        public string Path => _httpRequest.Path;
        public string PathInfo => _httpRequest.PathInfo;
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
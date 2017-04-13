using System;
using System.Text;
using System.Web;

namespace Serilog
{
    public interface IHttpRequestWrapper
    {
        string AnonymousID { get; }
        string ApplicationPath { get; }
        string AppRelativeCurrentExecutionFilePath { get; }
        Encoding ContentEncoding { get; }
        int ContentLength { get; }
        string ContentType { get; }
        string CurrentExecutionFilePath { get; }
        string CurrentExecutionFilePathExtension { get; }
        string FilePath { get; }
        string RawUrl { get; }
        Uri Url { get; }
    }

    internal class HttpRequestWrapper : IHttpRequestWrapper
    {
        private readonly HttpRequest _httpRequest;

        public HttpRequestWrapper(HttpRequest httpRequest)
        {
            _httpRequest = httpRequest;
        }

        public string AnonymousID => _httpRequest.AnonymousID;
        public string ApplicationPath => _httpRequest.ApplicationPath;
        public string AppRelativeCurrentExecutionFilePath => _httpRequest.AppRelativeCurrentExecutionFilePath;
        public Encoding ContentEncoding => _httpRequest.ContentEncoding;
        public int ContentLength => _httpRequest.ContentLength;
        public string ContentType => _httpRequest.ContentType;
        public string CurrentExecutionFilePath => _httpRequest.CurrentExecutionFilePath;
        public string CurrentExecutionFilePathExtension => _httpRequest.CurrentExecutionFilePathExtension;
        public string FilePath => _httpRequest.FilePath;
        public string RawUrl => _httpRequest.RawUrl;
        public Uri Url => _httpRequest.Url;
    }
}
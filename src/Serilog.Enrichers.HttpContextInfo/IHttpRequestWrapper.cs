using System;
using System.Text;

namespace Serilog
{
    public interface IHttpRequestWrapper
    {
        string AnonymousID { get; }
        string ApplicationPath { get; }
        Encoding ContentEncoding { get; }
        int ContentLength { get; }
        string ContentType { get; }
        string CurrentExecutionFilePath { get; }
        string CurrentExecutionFilePathExtension { get; }
        string FilePath { get; }
        string HttpMethod { get; }
        bool IsAuthenticated { get; }
        bool IsLocal { get; }
        bool IsSecureConnection { get; }
        string Path { get; }
        string PathInfo { get; }
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
}
using System.Net;

using TerraCloud.Application.DTOs.Error;

namespace TerraCloud.Application.Exceptions
{
    public class MyApplicationException : Exception
    {
        public ErrorCode ErrorCode { get; set; }
        public string Describe { get; set; }
        public HttpStatusCode HttpStatusCode { get; set; }
        public MyApplicationException() : base($"Application error")
        {
            Describe = "Application error";
            ErrorCode = ErrorCode.ApplicationError;
            HttpStatusCode = HttpStatusCode.InternalServerError;
        }

        public MyApplicationException(string error, ErrorCode errorCode, HttpStatusCode httpStatusCode) : base(error)
        {
            Describe = error;
            ErrorCode = errorCode;
            HttpStatusCode = httpStatusCode;
        }
    }
}

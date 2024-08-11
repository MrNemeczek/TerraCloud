using System.Net;

namespace TerraCloud.Application.DTOs.Error
{
    public class ErrorResponse
    {
        public string Describe { get; set; }
        public ErrorCode ErrorCode { get; set; }
        public HttpStatusCode HttpStatusCode { get; set; }
    }
}

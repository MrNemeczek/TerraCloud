using System.Net;

using TerraCloud.Application.DTOs.Error;

namespace TerraCloud.Application.Exceptions.Auth
{
    public sealed class EmailExistsException : MyApplicationException
    {
        public EmailExistsException(string email) : base($"Email: {email} exists!", ErrorCode.EmailExists, HttpStatusCode.Conflict)
        {           
        }
    }
}

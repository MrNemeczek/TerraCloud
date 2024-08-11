using System.Net;

using TerraCloud.Application.DTOs.Error;

namespace TerraCloud.Application.Exceptions.Auth
{
    public sealed class LoginExistsException : MyApplicationException
    {
        public LoginExistsException(string login) : base($"Login: {login} exists!", ErrorCode.LoginExists, HttpStatusCode.Conflict)
        {            
        }
    }
}

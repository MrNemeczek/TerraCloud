namespace TerraCloud.Application.Exceptions.Auth
{
    public sealed class LoginExistsException : Exception
    {
        public LoginExistsException(string login) : base($"Login: {login} exists!")
        {            
        }
    }
}

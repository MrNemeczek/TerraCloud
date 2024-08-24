namespace TerraCloud.Application.Exceptions.Auth
{
    public sealed class LoginDeviceException : Exception
    {
        public LoginDeviceException(string uniqueCode) : base($"Login failed for device with unique code: {uniqueCode}")
        {
            
        }
    }
}

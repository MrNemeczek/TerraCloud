using TerraCloud.Application.DTOs.Auth.Requests;
using TerraCloud.Application.DTOs.Auth.Responses;

namespace TerraCloud.Application.Interfaces.Auth
{
    public interface ILoginService
    {
        /// <summary>
        /// Verify credentials
        /// </summary>
        /// <param name="login"></param>
        /// <returns>JWT Token</returns>
        Task<LoginResponse> Login(LoginRequest login);
        Task<LoginResponse> LoginDevice(LoginDeviceRequest login);
    }
}

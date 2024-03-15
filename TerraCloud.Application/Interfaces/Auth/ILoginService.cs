using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerraCloud.Application.DTO.Auth.Request;
using TerraCloud.Application.DTO.Auth.Response;

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
    }
}

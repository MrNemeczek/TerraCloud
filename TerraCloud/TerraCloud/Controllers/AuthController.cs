using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using TerraCloud.Application.DTO.Auth.Request;
using TerraCloud.Application.Interfaces.Auth;
using TerraCloud.Infrastructure.Auth;

namespace TerraCloud.Server.Controllers
{
    public class AuthController : Controller
    {
        private readonly ILoginService _loginService;    
        private readonly IRegistryService _registryService;

        public AuthController(ILoginService loginService, IRegistryService registryService)
        {
            _loginService = loginService;
            _registryService = registryService;

        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            string jwtToken = await _loginService.Login(loginRequest);
            if (jwtToken.IsNullOrEmpty())
            {
                return Unauthorized();
            }

            return Ok(new { token = jwtToken });
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterRequest registerRequest)
        {
            await _registryService.Registry(registerRequest);

            return Ok();
        }
    }
}

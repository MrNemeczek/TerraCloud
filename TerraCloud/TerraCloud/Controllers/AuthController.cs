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

        public AuthController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDtoRequest login)
        {
            string jwtToken = await _loginService.Login(login);
            if (jwtToken.IsNullOrEmpty())
            {
                return Unauthorized();
            }

            return Ok(new { token = jwtToken });
        }
    }
}

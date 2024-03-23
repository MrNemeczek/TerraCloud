using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using TerraCloud.Application.DTOs.Auth.Request;
using TerraCloud.Application.DTOs.Auth.Response;
using TerraCloud.Application.DTOs.Error;
using TerraCloud.Application.Exceptions.Auth;
using TerraCloud.Application.Interfaces.Auth;
using TerraCloud.Infrastructure.Auth;

namespace TerraCloud.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly ILoginService _loginService;    
        private readonly IRegistryService _registryService;

        public AuthController(ILoginService loginService, IRegistryService registryService)
        {
            _loginService = loginService;
            _registryService = registryService;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            LoginResponse loginResponse = await _loginService.Login(loginRequest);
            if (loginResponse is null)
            {
                return Unauthorized();
            }

            //return RedirectToAction("Index", "Home");
            return Ok(loginResponse);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest registerRequest)
        {
            // TODO: przenieść try...catch to tak jak bylo na szkoleniu
            try
            {
                await _registryService.Registry(registerRequest);
            }
            catch (LoginExistsException ex)
            {
                await Console.Out.WriteLineAsync(ex.ToString());

                var errorResponse = new ErrorResponse() 
                {
                    Describe = "Login exists!",
                    ErrorCode = ErrorCode.LoginExists
                };
                return Conflict(errorResponse);
            }
            catch(EmailExistsException ex)
            {
                await Console.Out.WriteLineAsync(ex.ToString());

                var errorResponse = new ErrorResponse()
                {
                    Describe = "Email exists!",
                    ErrorCode = ErrorCode.EmailExists
                };
                return Conflict(errorResponse);
            }

            return Ok();
        }
    }
}

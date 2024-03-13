﻿using Microsoft.AspNetCore.Mvc;
using TerraCloud.Application.DTO.Auth.Request;
using TerraCloud.Application.Interfaces.Application.Auth;

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
            bool result = await _loginService.Login(login);
            if (result)
            {

            }

            return Ok();
        }
    }
}
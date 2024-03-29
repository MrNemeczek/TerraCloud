﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TerraCloud.Application.DTOs.Auth.Request;
using TerraCloud.Application.Interfaces.Auth;
using TerraCloud.Persistence.Interfaces.Repository.User;
using TerraCloud.Domain.Models.User;
using TerraCloud.Infrastructure.Interfaces.Auth;
using AutoMapper;
using TerraCloud.Application.DTOs.Auth.Response;

namespace TerraCloud.Infrastructure.Auth
{
    internal class LoginService : ILoginService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordOperations _passwordOperations;
        private readonly IMapper _mapper;
        private readonly IJwtService _jwtService;

        public LoginService(IUserRepository userRepository, IPasswordOperations passwordOperations, IMapper mapper, IJwtService jwtService)
        {
            _userRepository = userRepository;
            _passwordOperations = passwordOperations;
            _mapper = mapper;
            _jwtService = jwtService;
        }

        public async Task<LoginResponse> Login(LoginRequest login)
        {
            User user = await _userRepository.GetUserByLogin(login.Login);
            if (user == null)
            {
                return null;
            }

            bool result = _passwordOperations.VerifyPassword(login.Password, user.Password, Convert.FromHexString(user.Salt));
            if (result)
            {
                var jwtUser = _mapper.Map<JwtUser>(user);

                string jwtToken = _jwtService.GenerateJWT(jwtUser);

                return new LoginResponse() { Token = jwtToken };
            }
            return null;            
        }
    }
}

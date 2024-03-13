using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using TerraCloud.Application.DTO.Auth;
using TerraCloud.Application.Interfaces.Application.Auth;
using TerraCloud.Application.Interfaces.Repository.User;
using TerraCloud.Domain.Models.User;
using TerraCloud.Infrastructure.Interfaces.Auth;

namespace TerraCloud.Infrastructure.Auth
{
    internal class LoginService : ILoginService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordOperations _passwordOperations;
        public LoginService(IUserRepository userRepository, IPasswordOperations passwordOperations)
        {
            _userRepository = userRepository;
            _passwordOperations = passwordOperations;
        }

        public async Task<bool> Login(LoginDto login)
        {
            User user = await _userRepository.GetUserByLogin(login.Login);

            if (user == null)
            {
                return false;
            }

            return _passwordOperations.VerifyPassword(login.Password, user.Password, Convert.FromHexString(user.Salt)) ? true : false;
        }
    }
}

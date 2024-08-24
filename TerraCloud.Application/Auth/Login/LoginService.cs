using AutoMapper;

using TerraCloud.Application.DTOs.Auth.Requests;
using TerraCloud.Application.Interfaces.Auth;
using TerraCloud.Persistence.Interfaces.Repository.User;
using TerraCloud.Domain.Models.User;
using TerraCloud.Infrastructure.Interfaces.Auth;
using TerraCloud.Application.DTOs.Auth.Responses;
using TerraCloud.Persistence.Interfaces.Repository.Device;
using TerraCloud.Application.Exceptions.Auth;

namespace TerraCloud.Infrastructure.Auth
{
    internal class LoginService : ILoginService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordOperations _passwordOperations;
        private readonly IMapper _mapper;
        private readonly IJwtService _jwtService;
        private readonly IDeviceRepository _deviceRepository;

        public LoginService(IUserRepository userRepository, IPasswordOperations passwordOperations, IMapper mapper, IJwtService jwtService, IDeviceRepository deviceRepository)
        {
            _userRepository = userRepository;
            _passwordOperations = passwordOperations;
            _mapper = mapper;
            _jwtService = jwtService;
            _deviceRepository = deviceRepository;
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

        public async Task<LoginResponse> LoginDevice(LoginDeviceRequest login)
        {
            var device = await _deviceRepository.GetDeviceByUniqueCode(login.UniqueCode);
            if (device == null)
            {
                throw new LoginDeviceException(login.UniqueCode);
            }

            var jwtDevice = _mapper.Map<JwtDevice>(device);
            string jwtToken = _jwtService.GenerateJWTForDevice(jwtDevice);

            return new LoginResponse() { Token = jwtToken };
        }
    }
}

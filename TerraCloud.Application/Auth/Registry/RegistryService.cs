using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerraCloud.Application.DTO.Auth.Request;
using TerraCloud.Application.Exceptions.Auth;
using TerraCloud.Application.Interfaces.Auth;
using TerraCloud.Domain.Models.User;
using TerraCloud.Infrastructure.Interfaces.Auth;
using TerraCloud.Persistence.Interfaces.Repository.Database;
using TerraCloud.Persistence.Interfaces.Repository.User;

namespace TerraCloud.Infrastructure.Auth.Registry
{
    internal class RegistryService : IRegistryService
    {
        private readonly IPasswordOperations _passwordOperations;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IDatabaseRepository _databaseRepository;

        public RegistryService(IPasswordOperations passwordOperations, IMapper mapper, IUserRepository userRepository, IDatabaseRepository databaseRepository)
        {
            _passwordOperations = passwordOperations;
            _mapper = mapper;
            _userRepository = userRepository;
            _databaseRepository = databaseRepository;
        }

        public async Task Registry(RegisterRequest registerRequest)
        {
            await CheckConflictExists(registerRequest.Login, registerRequest.Email);

            registerRequest.Password = _passwordOperations.GenerateHash(registerRequest.Password, out byte[] salt);

            var user = _mapper.Map<User>(registerRequest);
            user.Salt = Convert.ToHexString(salt);

            await _userRepository.AddUser(user);
            await _databaseRepository.SaveChangesAsync();
        }

        private async Task<bool> CheckConflictExists(string login, string email)
        {
            User user = await _userRepository.GetUserByEmailOrLogin(email, login);

            if (user?.Email == email)
            {
                throw new EmailExistsException(email);
            }
            if(user?.Login == login)
            {
                throw new LoginExistsException(login);
            }

            return false;
        }
    }
}

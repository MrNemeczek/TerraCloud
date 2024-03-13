using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerraCloud.Application.Interfaces.Repository.User;
using TerraCloud.Domain.Models.User;
using TerraCloud.Persistence.Contexts;

namespace TerraCloud.Persistence.Repositories
{
    internal class UserRepository : IUserRepository
    {
        private readonly TerraCloudContext _context;
        public UserRepository(TerraCloudContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserByLogin(string login)
        {
            User user = await _context.Users.FirstOrDefaultAsync(u => u.Login == login);

            return user;
        }
    }
}

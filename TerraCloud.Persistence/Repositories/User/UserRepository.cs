using Microsoft.EntityFrameworkCore;
using TerraCloud.Domain.Models.User;
using TerraCloud.Persistence.Contexts;
using TerraCloud.Persistence.Interfaces.Repository.User;

namespace TerraCloud.Persistence.Repositories.User
{
    public class UserRepository : IUserRepository
    {
        private readonly TerraCloudContext _context;
        public UserRepository(TerraCloudContext context)
        {
            _context = context;
        }

        public async Task AddUser(Domain.Models.User.User user)
        {
            await _context.Users.AddAsync(user);
        }

        public async Task<Domain.Models.User.User> GetUserByEmailOrLogin(string email, string login)
        {
            Domain.Models.User.User user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email || u.Login == login);

            return user;
        }

        public async Task<Domain.Models.User.User> GetUserByLogin(string login)
        {
            Domain.Models.User.User user = await _context.Users.FirstOrDefaultAsync(u => u.Login == login);

            return user;
        }
    }
}

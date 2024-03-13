using Microsoft.EntityFrameworkCore;
using TerraCloud.Domain.Models.User;
using TerraCloud.Persistence.Contexts;
using TerraCloud.Persistence.Interfaces.Repository.User;

namespace TerraCloud.Persistence.Repositories
{
    public class UserRepository : IUserRepository
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

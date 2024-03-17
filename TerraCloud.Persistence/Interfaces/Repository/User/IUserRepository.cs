using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerraCloud.Domain.Models.User;

namespace TerraCloud.Persistence.Interfaces.Repository.User
{
    public interface IUserRepository
    {
        Task<Domain.Models.User.User> GetUserByLogin(string login);
        Task<Domain.Models.User.User> GetUserByEmailOrLogin(string email, string login);
        Task AddUser(Domain.Models.User.User user);
    }
}

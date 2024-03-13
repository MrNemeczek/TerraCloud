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
    }
}

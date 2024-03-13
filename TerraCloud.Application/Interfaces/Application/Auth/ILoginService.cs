using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerraCloud.Application.DTO.Auth;

namespace TerraCloud.Application.Interfaces.Application.Auth
{
    public interface ILoginService
    {
        Task<bool> Login(LoginDto login);
    }
}

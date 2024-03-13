using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerraCloud.Application.DTO.Auth.Request;

namespace TerraCloud.Application.Interfaces.Application.Auth
{
    public interface ILoginService
    {
        Task<bool> Login(LoginDtoRequest login);
    }
}

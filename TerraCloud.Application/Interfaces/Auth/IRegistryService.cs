using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerraCloud.Application.DTO.Auth.Request;

namespace TerraCloud.Application.Interfaces.Auth
{
    public interface IRegistryService
    {
        Task Registry(RegisterRequest registerRequest);
    }
}

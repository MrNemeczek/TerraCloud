using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerraCloud.Infrastructure.Auth;

namespace TerraCloud.Infrastructure.Interfaces.Auth
{
    public interface IJwtService
    {
        string GenerateJWT(JwtUser jwtUser);
    }
}

using Microsoft.IdentityModel.Tokens;

using TerraCloud.Infrastructure.Auth;

namespace TerraCloud.Infrastructure.Interfaces.Auth
{
    public interface IJwtService
    {
        string GenerateJWT(JwtUser jwtUser);
        string GenerateJWTForDevice(JwtDevice jwtDevice);
        TokenValidationParameters GetValidationParameters();
    }
}

using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

using TerraCloud.Infrastructure.Interfaces.Auth;

namespace TerraCloud.Infrastructure.Auth
{
    internal class JwtService : IJwtService
    {
        private readonly IConfiguration _configuration;

        public JwtService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateJWT(JwtUser jwtUser)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim("name", jwtUser.Name),
                new Claim("lastname", jwtUser.Lastname),
                new Claim("email", jwtUser.Email),
                new Claim("guid", jwtUser.Id.ToString())
            };

            var token = new JwtSecurityToken(
              issuer: _configuration["Jwt:Issuer"],
              audience: _configuration["Jwt:Issuer"],
              claims: claims,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string GenerateJWTForDevice(JwtDevice jwtDevice)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim("uniquecode", jwtDevice.UniqueCode),
                new Claim("deviceguid", jwtDevice.Id.ToString())
            };

            var token = new JwtSecurityToken(
              issuer: _configuration["Jwt:Issuer"],
              audience: _configuration["Jwt:Issuer"],
              claims: claims,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public TokenValidationParameters GetValidationParameters()
        {
            string key = _configuration["Jwt:Key"] ?? "WygenerowanyDługiBezpiecznyKlucz";
            string validIssuer = _configuration["Jwt:Issuer"] ?? "Test.com";
            string validAudience = _configuration["Jwt:Issuer"] ?? "Test.com";// TODO: zmienic na Audience

            if (String.IsNullOrEmpty(key))
            {
                Console.WriteLine("jest null nie wiem czemu");
            }

            return new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = validIssuer,
                ValidAudience = validAudience,                
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
            };
        }
    }
}

using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

using TerraCloud.Infrastructure.Interfaces.Auth;

namespace TerraCloud.Infrastructure.Auth
{
    public class PersistentAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly IJwtService _jwtService;

        private ClaimsPrincipal anonymous = new(new ClaimsIdentity());

        public PersistentAuthenticationStateProvider(IJwtService jwtService) : base()
        {
            _jwtService = jwtService;
        }

        public async override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            // TODO: dodac sprawdzanie z local storage
            return await Task.FromResult(new AuthenticationState(anonymous));
        }

        public async Task UpdateAuthenticationState(string? token)
        {
            var identity = new ClaimsIdentity(new[]
            {
                new Claim("name", "name"),
                new Claim("lastname", "lastname")
            }, "authenticationType");

            var usertest = new ClaimsPrincipal(identity);

            var user = GetClaimsPrincipal(token);

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }

        private ClaimsPrincipal GetClaimsPrincipal(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var validationParameters = _jwtService.GetValidationParameters();

            try
            {
                ClaimsPrincipal principal = tokenHandler.ValidateToken(token, validationParameters, out var validatedToken);
                return principal;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Token validation failed: {ex.Message}");
                return null;
            }
        }
    }
}

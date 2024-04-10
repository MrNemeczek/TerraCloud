using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Blazored.LocalStorage;

using TerraCloud.Infrastructure.Interfaces.Auth;

namespace TerraCloud.Infrastructure.Auth
{
    public class PersistentAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly IJwtService _jwtService;
        private readonly ILocalStorageService _localStorageService;

        private ClaimsPrincipal anonymous = new(new ClaimsIdentity());

        public PersistentAuthenticationStateProvider(IJwtService jwtService, ILocalStorageService localStorageService) : base()
        {
            _jwtService = jwtService;
            _localStorageService = localStorageService;
        }

        public async override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            // TODO: dodac sprawdzanie z local storage
            //try
            //{
                string tokenJWT = await _localStorageService.GetItemAsStringAsync("jwt");
                if (!String.IsNullOrEmpty(tokenJWT))
                {
                    tokenJWT = tokenJWT.Trim('\"');
                    var user = GetClaimsPrincipal(tokenJWT);
                    AuthenticationState authState = new AuthenticationState(user);

                    NotifyAuthenticationStateChanged(Task.FromResult(authState));

                    return authState;
                }

                return await Task.FromResult(new AuthenticationState(anonymous));
            //}
            //catch (Exception)
            //{
            //    return await Task.FromResult(new AuthenticationState(anonymous));
            //}
        }

        public async Task UpdateAuthenticationState(string? token)
        {
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

using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;
using System.Security.Claims;

namespace TerraCloud.Client
{
    public class PersistentAuthenticationStateProvider : AuthenticationStateProvider
    {
        private ClaimsPrincipal anonymous = new(new ClaimsIdentity());
        public async override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            //var identity = new ClaimsIdentity(new[]
            //{
            //    new Claim("name", "name"),
            //    new Claim("lastname", "lastname"),
            //    // Dodaj inne potrzebne claimy
            //}, "authenticationType");

            //var user = new ClaimsPrincipal(identity);
            return await Task.FromResult(new AuthenticationState(anonymous));
        }

        public async Task UpdateAuthenticationState(string? token)
        {
            //ClaimsPrincipal claimsPrincipal = new();
            //if (!string.IsNullOrWhiteSpace(token))
            //{
            //    var userSession = Generics.GetClaimsFromToken(token);
            //    claimsPrincipal = Generics.SetClaimPrincipal(userSession);
            //}
            //else
            //{
            //    claimsPrincipal = anonymous;
            //}
            var identity = new ClaimsIdentity(new[]
            {
                new Claim("name", "name"),
                new Claim("lastname", "lastname"),
                // Dodaj inne potrzebne claimy
            }, "authenticationType");

            var user = new ClaimsPrincipal(identity);

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }
    }
}

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Radzen;

using TerraCloud.Application.DTOs.Auth.Request;
using TerraCloud.Application.DTOs.Auth.Response;
using TerraCloud.Client.Common;
using TerraCloud.Infrastructure.Auth;

namespace TerraCloud.Client.Pages.Auth
{
    public class LoginBase : ComponentBase
    {
        protected string defaultUsername = "string";
        protected string defaultPassword = "string";

        protected bool rememberMe = true;

        [Inject]
        private IApiRequest _apiRequest { get; set; } = default!;
        [Inject]
        private AuthenticationStateProvider AuthStateProvider { get; set; } = default!;
        [Inject]
        private NavigationManager NavManager { get; set; } = default!;

        protected async Task<bool> OnLogin(LoginArgs args, string name)
        {
            var loginRequest = new LoginRequest
            {
                Login = args.Username,
                Password = args.Password
            };

            var loginResponse = await _apiRequest.PostAsync<LoginResponse, LoginRequest>("Auth/Login", loginRequest);
            Console.WriteLine(loginResponse.Token);

            var customAuthStateProvider = (PersistentAuthenticationStateProvider)AuthStateProvider;
            await customAuthStateProvider.UpdateAuthenticationState(loginResponse.Token);
            NavManager.NavigateTo("/");

            return true;
        }

        protected bool OnRegister(string name)
        {
            Console.WriteLine($"{name} -> Register");

            return true;
        }

        protected bool OnResetPassword(string value, string name)
        {
            Console.WriteLine($"{name} -> ResetPassword for user: {value}");

            return true;
        }
    }
}

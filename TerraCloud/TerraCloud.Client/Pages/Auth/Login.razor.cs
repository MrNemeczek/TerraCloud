using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Radzen;

using TerraCloud.Application.DTOs.Auth.Requests;
using TerraCloud.Application.DTOs.Auth.Responses;
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
        private AuthenticationStateProvider _authStateProvider { get; set; } = default!;
        [Inject]
        private NavigationManager _navManager { get; set; } = default!;
        [Inject]
        private ILocalStorageService _localStorageService { get; set; } = default!;

        protected async Task<bool> OnLogin(LoginArgs args, string name)
        {
            var loginRequest = new LoginRequest
            {
                Login = args.Username,
                Password = args.Password
            };

            var loginResponse = await _apiRequest.PostAsync<LoginResponse, LoginRequest>("Auth/Login", loginRequest);

            await _localStorageService.SetItemAsync("jwt", loginResponse.Token);

            var customAuthStateProvider = (PersistentAuthenticationStateProvider)_authStateProvider;
            await customAuthStateProvider.UpdateAuthenticationState(loginResponse.Token);

            _navManager.NavigateTo("/");

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

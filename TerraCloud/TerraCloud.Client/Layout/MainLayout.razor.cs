using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

using TerraCloud.Infrastructure.Auth;

namespace TerraCloud.Client.Layout
{
    public class MainLayoutBase : LayoutComponentBase
    {
        [Inject]
        private ILocalStorageService _localStorageService { get; set; } = default!;
        [Inject]
        private AuthenticationStateProvider _authStateProvider { get; set; } = default!;
        [Inject]
        private NavigationManager _navManager { get; set; } = default!;
        protected async Task LogOutClick()
        {
            await _localStorageService.RemoveItemAsync("jwt");

            var customAuthStateProvider = (PersistentAuthenticationStateProvider)_authStateProvider;
            await customAuthStateProvider.UpdateAuthenticationState(null);

            _navManager.NavigateTo("/");
        }
        protected async Task SettingsClick()
        {
            _navManager.NavigateTo("settings");
        }
    }
}

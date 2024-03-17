using Microsoft.AspNetCore.Components;
using TerraCloud.Application.DTO.Auth.Request;
using TerraCloud.Client.Common;

namespace TerraCloud.Client.Pages.Auth
{
    public class RegistryBase : ComponentBase
    {
        protected RegisterRequest registerRequest { get; set; } = new RegisterRequest();

        protected bool popup;

        [Inject]
        private IApiRequest _apiRequest { get; set; } = default!;

        protected async Task OnRegister(RegisterRequest request)
        {
            var result = await _apiRequest.OnlyPostAsync("Auth/Register", request);
            if (!result)
            {
                // TODO: obsluga niepowodzenia
            }
        }
    }
}

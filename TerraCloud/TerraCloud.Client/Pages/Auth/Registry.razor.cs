using Microsoft.AspNetCore.Components;
using Radzen;

using TerraCloud.Application.DTOs.Auth.Requests;
using TerraCloud.Client.Common;

namespace TerraCloud.Client.Pages.Auth
{
    public class RegistryBase : ComponentBase
    {
        protected RegisterRequest registerRequest { get; set; } = new RegisterRequest();

        protected bool popup;

        [Inject]
        private IApiRequest _apiRequest { get; set; } = default!;
        [Inject]
        NotificationService _notificationService { get; set; } = default!;

        protected async Task OnRegister(RegisterRequest request)
        {
            if (!request.Password.Equals(request.ConfirmPassword))
            {
                _notificationService.Notify(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Error", Detail = "Password and Confirm Password are not the same", Duration = 5000 });
                
                return;
            }

            var result = await _apiRequest.OnlyPostAsync("Auth/Register", request);
            if (result is not null)
            {
                _notificationService.Notify(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Error", Detail = result.Describe, Duration = 5000});
            }
            else
            {
                _notificationService.Notify(new NotificationMessage { Severity = NotificationSeverity.Success, Summary = "Succes", Detail = "Account created", Duration = 5000 });
            }
        }
    }
}

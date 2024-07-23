using Microsoft.AspNetCore.Components;
using Radzen;

using TerraCloud.Application.DTOs.Device.Requests;
using TerraCloud.Client.Common;

namespace TerraCloud.Client.Pages.UserDevice
{
    public class DialogCreateBase : ComponentBase
    {
        protected AddUserDeviceRequest userDeviceRequest { get; set; } = new AddUserDeviceRequest();

        [Inject]
        private IApiRequest _apiRequest { get; set; } = default!;
        [Inject]
        NotificationService _notificationService { get; set; } = default!;

        protected async Task OnDeviceAdd(AddUserDeviceRequest request)
        {
            var result = await _apiRequest.OnlyPostAsync("Device/UserDevice", request);
            if (result is not null)
            {
                _notificationService.Notify(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Error", Detail = result.Describe, Duration = 5000 });
            }
            else
            {
                _notificationService.Notify(new NotificationMessage { Severity = NotificationSeverity.Success, Summary = "Succes", Detail = "Device created", Duration = 5000 });
            }
        }
    }
}

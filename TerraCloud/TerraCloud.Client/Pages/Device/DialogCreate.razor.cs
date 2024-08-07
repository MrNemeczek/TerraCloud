using Microsoft.AspNetCore.Components;
using Radzen;

using TerraCloud.Application.DTOs.Device.Requests;
using TerraCloud.Client.Common;

namespace TerraCloud.Client.Pages.Device
{
    public class DialogCreateBase : ComponentBase
    {
        protected AddDeviceRequest deviceRequest { get; set; } = new AddDeviceRequest();

        [Inject]
        private IApiRequest _apiRequest { get; set; } = default!;
        [Inject]
        NotificationService _notificationService { get; set; } = default!;
        [Inject]
        protected DialogService _dialogService { get; set; } = default!;

        protected async Task OnDeviceAdd(AddDeviceRequest request)
        {
            var result = await _apiRequest.OnlyPostAsync("Device",request);
            if (result is not null)
            {
                _notificationService.Notify(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Error", Detail = result.Describe, Duration = 5000 });
            }
            else
            {
                _notificationService.Notify(new NotificationMessage { Severity = NotificationSeverity.Success, Summary = "Succes", Detail = "Device created", Duration = 5000 });
                _dialogService.Close();
            }
        }
    }
}

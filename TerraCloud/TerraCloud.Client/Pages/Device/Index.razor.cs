using Microsoft.AspNetCore.Components;
using Radzen;

using TerraCloud.Application.DTOs.Device.Responses;
using TerraCloud.Client.Common;

namespace TerraCloud.Client.Pages.Device
{
    public class IndexBase : ComponentBase
    {
        protected IEnumerable<DeviceResponse> devices;

        [Inject]
        private IApiRequest _apiRequest { get; set; } = default!;
        [Inject]
        private DialogService _dialogService { get; set; } = default!;

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            devices = await _apiRequest.GetAsync<IEnumerable<DeviceResponse>>("Device");
        }

        public async Task AddDevice()
        {
            await _dialogService.OpenAsync<DialogCreate>(
                title: "Add Device",
                options: new DialogOptions() { Width = "700px", Height = "512px", Resizable = true, Draggable = true });
        }
    }
}

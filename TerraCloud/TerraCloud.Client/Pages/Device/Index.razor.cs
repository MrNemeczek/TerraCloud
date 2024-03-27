using Microsoft.AspNetCore.Components;

using TerraCloud.Application.DTOs.Device.Responses;
using TerraCloud.Client.Common;

namespace TerraCloud.Client.Pages.Device
{
    public class IndexBase : ComponentBase
    {
        protected IEnumerable<DeviceResponse> devices;

        [Inject]
        private IApiRequest _apiRequest { get; set; } = default!;

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            devices = await _apiRequest.GetAsync<IEnumerable<DeviceResponse>>("Device");
        }
    }
}

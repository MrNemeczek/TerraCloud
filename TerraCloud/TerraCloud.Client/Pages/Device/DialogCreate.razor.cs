using Microsoft.AspNetCore.Components;

using TerraCloud.Application.DTOs.Device.Requests;
using TerraCloud.Client.Common;

namespace TerraCloud.Client.Pages.Device
{
    public class DialogCreateBase : ComponentBase
    {
        protected AddDeviceRequest deviceRequest { get; set; } = new AddDeviceRequest();

        [Inject]
        private IApiRequest _apiRequest { get; set; } = default!;

        protected async Task OnDeviceAdd(AddDeviceRequest request)
        {
            
        }
    }
}

using Microsoft.AspNetCore.Components;

using TerraCloud.Application.DTOs.Animal.Responses;
using TerraCloud.Application.DTOs.Device.Responses;
using TerraCloud.Client.Common;

namespace TerraCloud.Client.Pages.UserDevice
{
    public class EditBase : ComponentBase
    {
        [Parameter]
        public string Id { get; set; } = null!;
        [Inject]
        private IApiRequest _apiRequest { get; set; } = default!;

        protected DeviceResponse device = null!;
        protected UserDeviceResponse userDevice = null!;
        protected IEnumerable<GetAnimalResponse> animals = null!;

        protected Guid animalId;

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            userDevice = await _apiRequest.GetAsync<UserDeviceResponse>($"Device/UserDevice/{Id}");
            device = await _apiRequest.GetAsync<DeviceResponse>($"Device/{userDevice.DeviceId}");
            animals = await _apiRequest.GetAsync<IEnumerable<GetAnimalResponse>>($"Animal");
        }
    }
}

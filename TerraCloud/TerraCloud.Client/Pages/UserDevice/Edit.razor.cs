using AutoMapper;
using AutoMapper.Internal;
using Microsoft.AspNetCore.Components;
using Radzen;
using TerraCloud.Application.DTOs.Animal.Responses;
using TerraCloud.Application.DTOs.Device.Requests;
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
        [Inject]
        private NavigationManager _navManager { get; set; } = default!;
        [Inject]
        private IMapper _mapper { get; set; } = default!;
        [Inject]
        NotificationService _notificationService { get; set; } = default!;

        protected DeviceResponse device = null!;
        protected UserDeviceResponse userDevice = null!;
        protected IEnumerable<GetUserAnimalResponse> animals = null!;

        protected UpdateUserDeviceRequest request { get; set; } = new();

        protected Guid? animalUserId;
        protected bool loaded = false;

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            userDevice = await _apiRequest.GetAsync<UserDeviceResponse>($"Device/UserDevice/{Id}");
            device = await _apiRequest.GetAsync<DeviceResponse>($"Device/{userDevice.DeviceId}");
            animals = await _apiRequest.GetAsync<IEnumerable<GetUserAnimalResponse>>($"Animal/UserAnimals");

            request = _mapper.Map(userDevice, request);
            request = _mapper.Map(device, request);
            
            loaded = true;
        }
        public void QuitClick()
        {
            _navManager.NavigateTo($"userdevice");
        }
        protected async Task SaveClick()
        {
            var result = await _apiRequest.OnlyPatchAsync("Device/UserDevice", request);
            if (result is not null)
            {
                _notificationService.Notify(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Error", Detail = result.Describe, Duration = 5000 });
            }
            else
            {
                _notificationService.Notify(new NotificationMessage { Severity = NotificationSeverity.Success, Summary = "Succes", Detail = "Device updated", Duration = 5000 });
                
                _navManager.NavigateTo($"userdevice");
            }
        }
    }
}

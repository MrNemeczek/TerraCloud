﻿using Microsoft.AspNetCore.Components;
using Radzen;

using TerraCloud.Application.DTOs.Device.Responses;
using TerraCloud.Application.DTOs.Error;
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
        [Inject]
        private NavigationManager _navManager { get; set; } = default!;
        [Inject]
        NotificationService _notificationService { get; set; } = default!;

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            devices = await _apiRequest.GetAsync<IEnumerable<DeviceResponse>>("Device/Device");
            _dialogService.OnClose += dialogService_OnClose;
        }

        public async Task AddDevice()
        {
            await _dialogService.OpenAsync<DialogCreate>(
                title: "Add Device",
                options: new DialogOptions() { Width = "700px", Height = "512px", Resizable = true, Draggable = true });
        }

        private void dialogService_OnClose(dynamic obj)
        {
            _navManager.NavigateTo(_navManager.Uri, true);
        }

        public async Task Delete(Guid deviceId)
        {
            ErrorResponse? result = await _apiRequest.DeleteAsync($"Device/Device/{deviceId}");
            if (result is not null)
            {
                _notificationService.Notify(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Error", Detail = result.Describe, Duration = 5000 });
            }
            else
            {
                _notificationService.Notify(new NotificationMessage { Severity = NotificationSeverity.Success, Summary = "Success", Detail = "Device deleted", Duration = 5000 });
                _navManager.NavigateTo(_navManager.Uri, true);
            }
        }
    }
}

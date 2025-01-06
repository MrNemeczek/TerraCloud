using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Globalization;

using TerraCloud.Application.DTOs.Device.Responses;
using TerraCloud.Client.Common;
using TerraCloud.Domain.Models.Device;

namespace TerraCloud.Client.Pages.UserDevice
{
    public class DetailsBase : ComponentBase
    {
        [Parameter]
        public string Id { get; set; } = null!;
        [Inject]
        private IApiRequest _apiRequest { get; set; } = default!;
        [Inject]
        private NavigationManager _navManager { get; set; } = default!;
        [Inject]
        private IJSRuntime JS { get; set; } = default!;

        protected DeviceResponse device = null!;
        protected DeviceMeasurementResponse deviceMeasurement = null!;

        protected bool isMobile;

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            device = await _apiRequest.GetAsync<DeviceResponse>($"Device/{Id}");
            deviceMeasurement = await _apiRequest.GetAsync<DeviceMeasurementResponse>($"Device/Measurement/{Id}");

            isMobile = await JS.InvokeAsync<bool>("isMobile");
        }

        protected string FormatAsCelsius(object value)
        {
            bool parseResult = Int32.TryParse(value.ToString(), out int celsiusValue);
            if (!parseResult)
            {
                throw new ArgumentException($"Incorrect argument {nameof(value)}: {value}");
            }

            return celsiusValue.ToString("N0", CultureInfo.InvariantCulture) + " °C";
        }

        protected string FormatAsDateTime(object value)
        {
            bool parseResult = DateTime.TryParse(value.ToString(), out DateTime dateTime);
            if (!parseResult)
            {
                throw new ArgumentException($"Incorrect argument {nameof(value)}: {value}");
            }

            return dateTime.ToString("dd.MM HH:mm", CultureInfo.InvariantCulture);
        }

        protected string FormatAsHumidity(object value)
        {
            bool parseResult = Int32.TryParse(value.ToString(), out int celsiusValue);
            if (!parseResult)
            {
                throw new ArgumentException($"Incorrect argument {nameof(value)}: {value}");
            }

            return celsiusValue.ToString("N0", CultureInfo.InvariantCulture) + " %";
        }

        protected void QuitClick()
        {
            _navManager.NavigateTo("userdevice");
        }
    }
}

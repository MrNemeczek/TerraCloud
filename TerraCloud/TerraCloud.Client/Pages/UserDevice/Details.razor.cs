using Microsoft.AspNetCore.Components;
using System.Globalization;

using TerraCloud.Application.DTOs.Device.Responses;
using TerraCloud.Client.Common;

namespace TerraCloud.Client.Pages.UserDevice
{
    public class DetailsBase : ComponentBase
    {
        [Parameter]
        public string Id { get; set; } = null!;
        [Inject]
        private IApiRequest _apiRequest { get; set; } = default!;

        protected DeviceResponse device = null!;
        protected DeviceMeasurementResponse deviceMeasurement = null!;

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            device = await _apiRequest.GetAsync<DeviceResponse>($"Device/{Id}");
            deviceMeasurement = await _apiRequest.GetAsync<DeviceMeasurementResponse>($"Device/Measurement/{Id}");
        }

        public string FormatAsCelsius(object value)
        {
            bool parseResult = Int32.TryParse(value.ToString(), out int celsiusValue);
            if (!parseResult)
            {
                throw new ArgumentException($"Incorrect argument {nameof(value)}: {value}");
            }

            return celsiusValue.ToString("N0", CultureInfo.InvariantCulture) + " °C";
        }

        public string FormatAsDateTime(object value)
        {
            bool parseResult = DateTime.TryParse(value.ToString(), out DateTime dateTime);
            if (!parseResult)
            {
                throw new ArgumentException($"Incorrect argument {nameof(value)}: {value}");
            }

            return dateTime.ToString("dd.MM HH:mm", CultureInfo.InvariantCulture);
        }

        public string FormatAsHumidity(object value)
        {
            bool parseResult = Int32.TryParse(value.ToString(), out int celsiusValue);
            if (!parseResult)
            {
                throw new ArgumentException($"Incorrect argument {nameof(value)}: {value}");
            }

            return celsiusValue.ToString("N0", CultureInfo.InvariantCulture) + " %";
        }
    }
}

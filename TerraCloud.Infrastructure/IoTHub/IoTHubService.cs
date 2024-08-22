using Microsoft.Azure.Devices.Shared;
using Microsoft.Azure.Devices;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Rest;

namespace TerraCloud.Infrastructure.IoTHub
{
    internal class IoTHubService : IIoTHubService
    {
        private readonly IoTHubOptions _iotHubOptions;
        private readonly ServiceClient _serviceClient;

        public IoTHubService(IOptions<IoTHubOptions> iotHubOptions)
        {
            _iotHubOptions = iotHubOptions.Value;
            _serviceClient = ServiceClient.CreateFromConnectionString(_iotHubOptions.ConnectionString);
        }

        public async Task SendCloudToDeviceMessageAsync(byte[] msg, string deviceUniqueCode)
        {
            var commandMessage = new Message(msg);
            await _serviceClient.SendAsync(deviceUniqueCode, commandMessage);
        }
    }
}

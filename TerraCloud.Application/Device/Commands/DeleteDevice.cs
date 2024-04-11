using TerraCloud.Application.Interfaces.Device;
using TerraCloud.Persistence.Interfaces.Repository.Device;

namespace TerraCloud.Application.Device.Commands
{
    internal class DeleteDevice : IDeleteDevice
    {
        private readonly IDeviceRepository _deviceRepository;

        public DeleteDevice(IDeviceRepository deviceRepository)
        {
            _deviceRepository = deviceRepository;
        }

        public async Task Execute(string deviceId)
        {
            try
            {
                await _deviceRepository.DeleteDevice(Guid.Parse(deviceId));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

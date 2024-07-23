using TerraCloud.Application.Interfaces.Device;
using TerraCloud.Persistence.Interfaces.Repository.Device;

namespace TerraCloud.Application.Device.Commands
{
    internal class DeleteUserDevice : IDeleteUserDevice
    {
        private readonly IDeviceRepository _deviceRepository;

        public DeleteUserDevice(IDeviceRepository deviceRepository)
        {
            _deviceRepository = deviceRepository;
        }

        public async Task Execute(string userDeviceId, Guid userId)
        {
            await _deviceRepository.DeleteUserDevice(userId, Guid.Parse(userDeviceId));            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerraCloud.Application.Interfaces.Device;
using TerraCloud.Persistence.Interfaces.Repository.Database;
using TerraCloud.Persistence.Interfaces.Repository.Device;

namespace TerraCloud.Application.Device.Commands
{
    internal class DeleteDevice : IDeleteDevice
    {
        private readonly IDeviceRepository _deviceRepository;
        private readonly IDatabaseRepository _databaseRepository;

        public DeleteDevice(IDeviceRepository deviceRepository, IDatabaseRepository databaseRepository)
        {
            _deviceRepository = deviceRepository;
            _databaseRepository = databaseRepository;
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

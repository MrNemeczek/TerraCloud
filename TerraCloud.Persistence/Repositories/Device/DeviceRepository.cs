using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerraCloud.Domain.Models.Device;
using TerraCloud.Persistence.Contexts;
using TerraCloud.Persistence.Interfaces.Repository.Device;

namespace TerraCloud.Persistence.Repositories.Device
{
    internal class DeviceRepository : IDeviceRepository
    {
        private readonly TerraCloudContext _context;

        public DeviceRepository(TerraCloudContext context)
        {
            _context = context;
        }

        public async Task<Domain.Models.Device.Device> GetDevice(Guid deviceId)
        {
            Domain.Models.Device.Device device = await _context.Devices.FirstOrDefaultAsync(d => d.Id == deviceId);

            return device;
        }

        public Task<IEnumerable<Domain.Models.Device.Device>> GetDevices()
        {
            throw new NotImplementedException();
        }
    }
}

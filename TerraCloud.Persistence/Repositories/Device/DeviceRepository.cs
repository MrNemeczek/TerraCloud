using Microsoft.EntityFrameworkCore;

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
            return await _context.Devices.SingleOrDefaultAsync(d => d.Id == deviceId);
        }

        public async Task<IEnumerable<Domain.Models.Device.Device>> GetDevices()
        {
            return await _context.Devices.ToListAsync();
        }
    }
}

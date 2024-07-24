using Microsoft.EntityFrameworkCore;
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

        public async Task AddDevice(Domain.Models.Device.Device device)
        {
            await _context.Devices.AddAsync(device);
        }

        public async Task AddDeviceMeasurment(DeviceMonitor deviceMonitor)
        {
            await _context.DeviceMonitors.AddAsync(deviceMonitor);
        }

        public async Task AddUserDevice(UserDevice device)
        {
            await _context.UserDevices.AddAsync(device);
        }

        public async Task DeleteDevice(Guid deviceId)
        {
            await _context.Devices.Where(d => d.Id == deviceId).ExecuteDeleteAsync();
        }

        public async Task DeleteUserDevice(Guid userId, Guid userDeviceId)
        {
            await _context.UserDevices.Where(ud => ud.Id == userDeviceId && ud.UserId == userId).ExecuteDeleteAsync();
        }

        public async Task<Domain.Models.Device.Device> GetDeviceById(Guid deviceId)
        {
            return await _context.Devices.SingleOrDefaultAsync(d => d.Id == deviceId);
        }

        public async Task<Domain.Models.Device.Device> GetDeviceById(Guid deviceId, Guid userId)
        {
            return await _context.Devices.SingleOrDefaultAsync(d => d.UserDevices.Any(ud => ud.DeviceId == deviceId && ud.UserId == userId));
        }

        public async Task<Domain.Models.Device.Device> GetDeviceByUniqueCode(string uniqueCode)
        {
            return await _context.Devices.SingleOrDefaultAsync(d => d.UniqueCode == uniqueCode);
        }

        public async Task<IEnumerable<DeviceMonitor>> GetDeviceMonitors(Guid deviceId)
        {
            return await _context.DeviceMonitors.Where(dm => dm.DeviceId == deviceId).ToListAsync();
        }

        public async Task<IEnumerable<Domain.Models.Device.Device>> GetDevices()
        {
            return await _context.Devices.ToListAsync();
        }

        public async Task<UserDevice> GetUserDeviceById(Guid userId, Guid userDeviceId)
        {
            return await _context.UserDevices.SingleOrDefaultAsync(ud => ud.Id == userDeviceId && ud.UserId == userId);
        }

        public async Task<IEnumerable<UserDevice>> GetUserDevices(Guid userId)
        {
            return await _context.UserDevices.Where(ud => ud.UserId == userId).ToListAsync();
        }

        public void UpdateDevice(Domain.Models.Device.Device device)
        {
            _context.Devices.Update(device);
        }

        public void UpdateUserDevice(UserDevice device)
        {
            _context.UserDevices.Update(device);
        }
    }
}

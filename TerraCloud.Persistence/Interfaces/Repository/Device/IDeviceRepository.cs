using TerraCloud.Domain.Models.Device;

namespace TerraCloud.Persistence.Interfaces.Repository.Device
{
    public interface IDeviceRepository
    {
        Task<Domain.Models.Device.Device> GetDeviceById(Guid deviceId);
        Task<Domain.Models.Device.Device> GetDeviceById(Guid deviceId, Guid userId);
        Task<Domain.Models.Device.Device> GetDeviceByUniqueCode(string uniqueCode);
        Task<IEnumerable<Domain.Models.Device.Device>> GetDevices();
        Task<IEnumerable<UserDevice>> GetUserDevices(Guid userId);
        Task<UserDevice> GetUserDeviceById(Guid userId, Guid userDeviceId);
        Task<IEnumerable<DeviceMonitor>> GetDeviceMonitors(Guid deviceId);
        Task AddDevice(Domain.Models.Device.Device device);
        Task AddUserDevice(UserDevice device);
        Task AddDeviceMeasurment(DeviceMonitor deviceMonitor);
        void UpdateUserDevice(UserDevice device);
        void UpdateDevice(Domain.Models.Device.Device device);
        Task DeleteDevice(Guid deviceId);
        Task DeleteUserDevice(Guid userId, Guid userDeviceId);
    }
}

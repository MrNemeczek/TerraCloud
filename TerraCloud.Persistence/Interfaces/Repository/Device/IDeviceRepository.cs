namespace TerraCloud.Persistence.Interfaces.Repository.Device
{
    public interface IDeviceRepository
    {
        Task<Domain.Models.Device.Device> GetDevice(Guid deviceId);
        Task<IEnumerable<Domain.Models.Device.Device>> GetDevices();
        Task AddDevice(Domain.Models.Device.Device device);
        Task DeleteDevice(Guid deviceId);
    }
}

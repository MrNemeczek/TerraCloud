namespace TerraCloud.Persistence.Interfaces.Repository.Device
{
    public interface IDeviceRepository
    {
        Task<Domain.Models.Device.Device> GetDevice(Guid deviceId);
        Task<IEnumerable<Domain.Models.Device.Device>> GetDevices();
    }
}

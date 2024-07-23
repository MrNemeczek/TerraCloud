using TerraCloud.Application.DTOs.Device.Requests;

namespace TerraCloud.Application.Interfaces.Device
{
    public interface IUpdateUserDevice
    {
        Task Execute(UpdateUserDeviceRequest request, Guid userId);
    }
}

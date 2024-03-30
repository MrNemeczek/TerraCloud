using TerraCloud.Application.DTOs.Device.Requests;

namespace TerraCloud.Application.Interfaces.Device
{
    public interface IAddDevice
    {
        Task Execute(AddDeviceRequest request);
    }
}

using TerraCloud.Application.DTOs.Device.Responses;

namespace TerraCloud.Application.Interfaces.Device
{
    public interface IGetDevices
    {
        Task<IEnumerable<DeviceResponse>> Execute();
    }
}

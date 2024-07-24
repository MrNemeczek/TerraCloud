using TerraCloud.Application.DTOs.Device.Responses;

namespace TerraCloud.Application.Interfaces.Device
{
    public interface IGetDeviceMeasurement
    {
        Task<DeviceMeasurementResponse> Execute(Guid deviceId, Guid userId);
    }
}

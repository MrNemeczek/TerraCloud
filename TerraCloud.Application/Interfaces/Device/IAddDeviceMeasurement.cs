using TerraCloud.Application.DTOs.Device.Requests;

namespace TerraCloud.Application.Interfaces.Device
{
    public interface IAddDeviceMeasurement
    {
        Task Execute(AddDeviceMeasurementRequest request, Guid userId);
    }
}

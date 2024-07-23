namespace TerraCloud.Application.DTOs.Device.Requests
{
    public class UpdateUserDeviceRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int MeasurementTime { get; set; }
    }
}

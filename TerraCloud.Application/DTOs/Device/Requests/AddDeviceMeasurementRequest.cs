namespace TerraCloud.Application.DTOs.Device.Requests
{
    public class AddDeviceMeasurementRequest
    {
        public Guid DeviceId { get; set; }
        public int Temperature { get; set; }
        public int Humidity { get; set; }
        public DateTime Time { get; set; }
    }
}

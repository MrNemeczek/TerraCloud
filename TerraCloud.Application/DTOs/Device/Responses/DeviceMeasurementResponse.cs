namespace TerraCloud.Application.DTOs.Device.Responses
{
    public class DeviceMeasurementResponse
    {
        public Guid DeviceId { get; set; }
        public string DeviceName { get; set; }
        public IEnumerable<DeviceSingleMeasurementResponse> deviceMeasurements { get; set; }
    }

    public class DeviceSingleMeasurementResponse
    {
        public Guid Id { get; set; }
        public DateTime Time { get; set; }
        public int? Humidity { get; set; }
        public int? Temperature { get; set; }
    }
}

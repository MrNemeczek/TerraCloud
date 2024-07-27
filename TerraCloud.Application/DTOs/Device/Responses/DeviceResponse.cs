namespace TerraCloud.Application.DTOs.Device.Responses
{
    public class DeviceResponse
    {
        public Guid Id { get; set; }
        public string UniqueCode { get; set; }
        public DateTime? LastMeasurement { get; set; }
        public int MeasurementTime { get; set; }
    }
}

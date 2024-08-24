namespace TerraCloud.Application.DTOs.Device.Requests
{
    public class AddDeviceMeasurementRequest
    {
        public string UniqueCode { get; set; } = null!;
        public int Temperature { get; set; }
        public int Humidity { get; set; }
        public DateTime Time { get; set; }
    }
}

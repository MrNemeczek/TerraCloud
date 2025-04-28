namespace TerraCloud.Application.DTOs.Device.Requests
{
    public class UpdateUserDeviceRequest
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public int? MeasurementTime { get; set; }
        public int? DayTemperature { get; set; }
        public int? DayHumidity { get; set; }
        public int? NightTemperature { get; set; }
        public int? NightHumidity { get; set; }
        public Guid? AnimalUserId { get; set; }
        public string? TimeStampTest { get; set; }
    }
}

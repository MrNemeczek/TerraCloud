namespace TerraCloud.Application.DTOs.Device.Responses
{
    public class UserDeviceResponse
    {
        public Guid Id { get; set; }
        public Guid DeviceId { get; set; }
        public Guid AnimalUserId { get; set; }
        public string Name { get; set; }
        public int? DayTemperature { get; set; }
        public int? DayHumidity { get; set; }
        public int? NightTemperature { get; set; }
        public int? NightHumidity { get; set; }
    }
}

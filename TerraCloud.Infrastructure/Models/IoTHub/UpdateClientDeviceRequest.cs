namespace TerraCloud.Infrastructure.Models.IoTHub
{
    public class UpdateClientDeviceRequest
    {
        /// <summary>
        /// Measurement time interval in minutes
        /// </summary>
        public int MeasurementTime { get; set; }
        public int? DayTemperature { get; set; }
        public int? DayHumidity { get; set; }
        public int? NightTemperature { get; set; }
        public int? NightHumidity { get; set; }
    }
}

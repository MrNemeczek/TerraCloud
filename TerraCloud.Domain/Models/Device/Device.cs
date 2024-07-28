namespace TerraCloud.Domain.Models.Device
{
    public class Device
    {
        public Guid Id { get; set; }
        public string UniqueCode { get; set; }
        /// <summary>
        /// Measurement time interval in minutes
        /// </summary>
        public int MeasurementTime { get; set; } = 60;
        public DateTime? LastMeasurement { get; set; }
        public int? DayTemperature { get; set; }
        public int? DayHumidity { get; set; }
        public int? NightTemperature { get; set; }
        public int? NightHumidity { get; set; }

        public Guid? AnimalUserId { get; set; }
        public virtual Animal.AnimalUser? AnimalUser { get; set; }
        
        public virtual ICollection<UserDevice>? UserDevices { get; }
        public virtual ICollection<DeviceMonitor>? DeviceMonitors { get; }
    }
}

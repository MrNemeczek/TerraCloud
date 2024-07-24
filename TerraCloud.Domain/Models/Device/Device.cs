namespace TerraCloud.Domain.Models.Device
{
    public class Device
    {
        public Guid Id { get; set; }
        public string UniqueCode { get; set; }
        /// <summary>
        /// Measurement time in minutes
        /// </summary>
        public int MeasurementTime { get; set; } = 60;
        public DateTime? LastMeasurement { get; set; }
        public virtual ICollection<UserDevice>? UserDevices { get; }
        public virtual ICollection<DeviceMonitor>? DeviceMonitors { get; }
    }
}

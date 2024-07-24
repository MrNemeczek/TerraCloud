namespace TerraCloud.Domain.Models.Device
{
    public class DeviceMonitor
    {
        public Guid Id { get; set; }
        public DateTime TimeStamp { get; private set; } = DateTime.UtcNow;
        public DateTime Time { get; set; }
        public int? Humidity { get; set; }
        public int? Temperature { get; set; }
        #region ForeignKeys
        public Guid DeviceId { get; set; }
        public virtual Device Device { get; set; } = null!;
        #endregion
    }
}

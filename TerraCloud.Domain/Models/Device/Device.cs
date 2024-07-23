namespace TerraCloud.Domain.Models.Device
{
    public class Device
    {
        public Guid Id { get; set; }
        public string UniqueCode { get; set; }

        public virtual ICollection<UserDevice>? UserDevices { get; }
        public virtual ICollection<DeviceMonitor>? DeviceMonitors { get; }
    }
}

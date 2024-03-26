namespace TerraCloud.Domain.Models.Device
{
    public class Device
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<UserDevice>? UserDevices { get; }
    }
}

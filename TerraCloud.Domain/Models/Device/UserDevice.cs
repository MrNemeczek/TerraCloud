namespace TerraCloud.Domain.Models.Device
{
    public class UserDevice
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        /// <summary>
        /// Measurement time in minutes
        /// </summary>
        public int MeasurementTime { get; set; } = 60;
        public DateTime? LastMeasurement { get; set; }

        public Guid UserId { get; set; }
        public virtual User.User User { get; set; } = null!;

        public Guid DeviceId { get; set; }
        public virtual Device Device { get; set; } = null!;
    }
}

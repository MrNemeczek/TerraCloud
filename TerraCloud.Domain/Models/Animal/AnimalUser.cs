namespace TerraCloud.Domain.Models.Animal
{
    public class AnimalUser
    {
        public Guid Id { get; set; }
        
        public Guid AnimalId { get; set; }
        public virtual Animal Animal { get; } = null!;

        public Guid UserId { get; set; }
        public virtual User.User User { get; } = null!;

        public virtual ICollection<Device.Device>? Devices { get; }

    }
}

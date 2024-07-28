using TerraCloud.Domain.Models.Animal;
using TerraCloud.Domain.Models.Device;

namespace TerraCloud.Domain.Models.User
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public string Email { get; set; }

        public virtual ICollection<UserDevice>? UserDevices { get; }
        public virtual ICollection<AnimalUser>? AnimalUsers { get; }
    }
}

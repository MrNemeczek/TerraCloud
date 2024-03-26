using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerraCloud.Domain.Models.Device
{
    public class UserDevice
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }
        public virtual User.User User { get; set; } = null!;

        public Guid DeviceId { get; set; }
        public virtual Device Device { get; set; } = null!;
    }
}

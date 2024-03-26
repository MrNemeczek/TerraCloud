using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerraCloud.Domain.Models.Device;

namespace TerraCloud.Persistence.Configurations.Device
{
    internal class UserDeviceConfiguration : IEntityTypeConfiguration<UserDevice>
    {
        public void Configure(EntityTypeBuilder<UserDevice> builder)
        {
            builder.ToTable("UserDevice");

            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.User)
                .WithMany(x => x.UserDevices)
                .HasForeignKey(x => x.UserId);

            builder.HasOne(x => x.Device)
                .WithMany(x => x.UserDevices)
                .HasForeignKey(x => x.DeviceId);
        }
    }
}

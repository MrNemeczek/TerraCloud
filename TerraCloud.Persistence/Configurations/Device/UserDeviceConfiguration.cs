using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using TerraCloud.Domain.Models.Device;

namespace TerraCloud.Persistence.Configurations.Device
{
    internal class UserDeviceConfiguration : IEntityTypeConfiguration<UserDevice>
    {
        public void Configure(EntityTypeBuilder<UserDevice> builder)
        {
            builder.ToTable("UserDevice");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasComment("Nazwa urządzenia dla konretnego użytkownika");

            builder.HasOne(x => x.User)
                .WithMany(x => x.UserDevices)
                .HasForeignKey(x => x.UserId);

            builder.HasOne(x => x.Device)
                .WithMany(x => x.UserDevices)
                .HasForeignKey(x => x.DeviceId);
        }
    }
}

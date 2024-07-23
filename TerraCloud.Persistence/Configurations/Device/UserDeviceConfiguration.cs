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

            builder.Property(x => x.MeasurementTime)
                .HasComment("Okres czasu co jaki urządzenie ma zbierać pomiary wyrażony w minutach");

            builder.Property(x => x.LastMeasurement)
                .HasComment("Ostatnia data pomiaru");

            builder.HasOne(x => x.User)
                .WithMany(x => x.UserDevices)
                .HasForeignKey(x => x.UserId);

            builder.HasOne(x => x.Device)
                .WithMany(x => x.UserDevices)
                .HasForeignKey(x => x.DeviceId);
        }
    }
}

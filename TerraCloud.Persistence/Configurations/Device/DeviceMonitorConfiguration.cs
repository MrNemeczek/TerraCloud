using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using TerraCloud.Domain.Models.Device;

namespace TerraCloud.Persistence.Configurations.Device
{
    public class DeviceMonitorConfiguration : IEntityTypeConfiguration<Domain.Models.Device.DeviceMonitor>
    {
        public void Configure(EntityTypeBuilder<DeviceMonitor> builder)
        {
            builder.ToTable("DeviceMonitor");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Humidity)
                .HasComment("Pomiar wilgotności");

            builder.Property(x => x.Temperature)
                .HasComment("Pomiar temperatury");

            builder.Property(x => x.TimeStamp)
                .HasComment("TimeStamp");

            builder.Property(x => x.Time)
                .HasComment("Czas pobrania pomiaru");

            builder.HasOne(x => x.Device)
                .WithMany(x => x.DeviceMonitors)
                .HasForeignKey(x => x.DeviceId);
        }
    }
}

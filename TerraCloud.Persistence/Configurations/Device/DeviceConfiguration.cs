using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TerraCloud.Persistence.Configurations.Device
{
    public class DeviceConfiguration : IEntityTypeConfiguration<Domain.Models.Device.Device>
    {
        public void Configure(EntityTypeBuilder<Domain.Models.Device.Device> builder)
        {
            builder.ToTable("Device");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.MeasurementTime)
                .HasComment("Okres czasu co jaki urządzenie ma zbierać pomiary wyrażony w minutach");

            builder.Property(x => x.LastMeasurement)
                .HasComment("Ostatnia data pomiaru");

            builder.Property(x => x.UniqueCode)
                .IsRequired()
                .HasComment("Unikalny kod urządzenia");

            builder.Property(x => x.DayTemperature)
                .HasComment("Temperatura w dzień");

            builder.Property(x => x.DayHumidity)
                .HasComment("Wilgotność w dzień");

            builder.Property(x => x.NightTemperature)
                .HasComment("Temperatura w nocy");

            builder.Property(x => x.NightHumidity)
                .HasComment("Wilgotność w nocy");

            builder.HasOne(x => x.AnimalUser)
                .WithMany(x => x.Devices)
                .HasForeignKey(x => x.AnimalUserId);
        }
    }
}

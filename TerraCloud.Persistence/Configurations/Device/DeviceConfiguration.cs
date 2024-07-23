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

            builder.Property(x => x.UniqueCode)
                .IsRequired()
                .HasComment("Unikalny kod urządzenia");
        }
    }
}

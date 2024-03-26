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
    public class DeviceConfiguration : IEntityTypeConfiguration<Domain.Models.Device.Device>
    {
        public void Configure(EntityTypeBuilder<Domain.Models.Device.Device> builder)
        {
            builder.ToTable("Device");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasComment("Nazwa urządzenia");
        }
    }
}

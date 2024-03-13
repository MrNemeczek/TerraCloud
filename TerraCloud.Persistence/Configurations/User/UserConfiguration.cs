using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerraCloud.Persistence.Configurations.User
{
    // TODO: zlikwidowac ten namespace (za pomoca using?)
    public class UserConfiguration : IEntityTypeConfiguration<Domain.Models.User.User>
    {
        public void Configure(EntityTypeBuilder<Domain.Models.User.User> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name);

            builder.Property(x => x.Lastname);

            builder.Property(x => x.Login);

            builder.Property(x => x.Password);

            builder.Property(x => x.Salt);

            builder.Property(x => x.Email);
        }
    }
}

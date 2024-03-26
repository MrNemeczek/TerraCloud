using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace TerraCloud.Persistence.Configurations.User
{
    public class UserConfiguration : IEntityTypeConfiguration<Domain.Models.User.User>
    {
        public void Configure(EntityTypeBuilder<Domain.Models.User.User> builder)
        {
            builder.ToTable("User");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasComment("Imię");

            builder.Property(x => x.Lastname)
                .HasComment("Nazwisko");

            builder.HasIndex(x => x.Login)
                .IsUnique(true);
            builder.Property(x => x.Login)
                .HasComment("Login");

            builder.Property(x => x.Password)
                .HasComment("Hasło");

            builder.Property(x => x.Salt)
                .HasComment("Sól do szyfrowania hasła");

            builder.HasIndex(x => x.Email)
                .IsUnique(true);
            builder.Property(x => x.Email)
                .HasComment("Email");
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using TerraCloud.Domain.Models.Animal;

namespace TerraCloud.Persistence.Configurations.Animal
{
    internal class AnimalUserConfiguration : IEntityTypeConfiguration<AnimalUser>
    {
        public void Configure(EntityTypeBuilder<AnimalUser> builder)
        {
            builder.ToTable("AnimalUser");

            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Animal)
                .WithMany(x => x.AnimalUsers)
                .HasForeignKey(x => x.AnimalId);

            builder.HasOne(x => x.User)
                .WithMany(x => x.AnimalUsers)
                .HasForeignKey(x => x.UserId);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TerraCloud.Persistence.Configurations.Animal
{
    internal class AnimalConfiguration : IEntityTypeConfiguration<Domain.Models.Animal.Animal>
    {
        public void Configure(EntityTypeBuilder<Domain.Models.Animal.Animal> builder)
        {
            builder.ToTable("Animal");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Species)
                .HasComment("Gatunek zwierzęcia");

            builder.Property(x => x.DayTemperature)
                .HasComment("Temperatura w dzień");

            builder.Property(x => x.DayHumidity)
                .HasComment("Wilgotność w dzień");

            builder.Property(x => x.NightTemperature)
                .HasComment("Temperatura w nocy");

            builder.Property(x => x.NightHumidity)
                .HasComment("Wilgotność w nocy");

            builder.Property(x => x.IsPublic)
                .HasComment("Czy gatunek jest dostępny publicznie");
        }
    }
}

using EventManagementAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventManagementAPI.Configurations;

public class LocationConfiguration : IEntityTypeConfiguration<Location>
{
    public void Configure(EntityTypeBuilder<Location> builder)
    {
        builder.HasKey(l => l.Id);
        builder.Property(l => l.Name).IsRequired().HasMaxLength(100);
        builder.Property(l => l.Address).HasMaxLength(200);

        builder.HasData(
            new Location
            {
                Id = 1,
                Name = "Palais des Congrès",
                Address = "2 Place de la Porte Maillot",
                City = "Paris"
            },
            new Location
            {
                Id = 2,
                Name = "Centre de Conférences Internationales",
                Address = "5 Avenue des Sciences",
                City = "Lyon"
            },
            new Location
            {
                Id = 3,
                Name = "Parc des Expositions",
                Address = "123 Boulevard des Événements",
                City = "Marseille"
            },
            new Location
            {
                Id = 4,
                Name = "Campus Numérique",
                Address = "45 Rue de l'Innovation",
                City = "Bordeaux"
            }
        );
    }
}
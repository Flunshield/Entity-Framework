using EventManagementAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventManagementAPI.Configurations;

public class SpeakerConfiguration : IEntityTypeConfiguration<Speaker>
{
    public void Configure(EntityTypeBuilder<Speaker> builder)
    {
        builder.HasKey(s => s.Id);
        builder.Property(s => s.FullName).IsRequired().HasMaxLength(100);
        builder.Property(s => s.Bio).HasMaxLength(500);
        builder.Property(s => s.FirstName).IsRequired().HasMaxLength(50);
        builder.Property(s => s.LastName).IsRequired().HasMaxLength(50);
        builder.Property(s => s.Email).IsRequired().HasMaxLength(100);
        builder.Property(s => s.Company).HasMaxLength(100);
    }
}
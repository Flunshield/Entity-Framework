using EventManagementAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventManagementAPI.Configurations;

public class ParticipantConfiguration : IEntityTypeConfiguration<Participant>
{
    public void Configure(EntityTypeBuilder<Participant> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.FullName).IsRequired().HasMaxLength(100);
        builder.Property(p => p.Email).IsRequired().HasMaxLength(100);
        builder.Property(p => p.Phone).IsRequired().HasMaxLength(15);
        builder.Property(p => p.Company).IsRequired().HasMaxLength(200);
        builder.Property(p => p.JobTitle).IsRequired().HasMaxLength(100);
        builder.Property(p => p.Role).IsRequired().HasMaxLength(200);
    }
}
using EventManagementAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventManagementAPI.Configurations;

public class SessionConfiguration : IEntityTypeConfiguration<Session>
{
    public void Configure(EntityTypeBuilder<Session> builder)
    {
        builder.HasKey(s => s.Id);
        builder.Property(s => s.Title).IsRequired().HasMaxLength(100);

        // One-to-Many: Speaker -> Sessions
        builder.HasOne(s => s.Speaker)
            .WithMany(sp => sp.Sessions)
            .HasForeignKey(s => s.SpeakerId);
    }
}
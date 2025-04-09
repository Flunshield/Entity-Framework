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

        // Many-to-Many: Session <-> Speaker
        builder.HasMany(s => s.Speakers)
            .WithMany(sp => sp.Sessions)
            .UsingEntity(j => j.ToTable("SessionSpeaker"));
        
    }
}
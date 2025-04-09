using EventManagementAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventManagementAPI.Configurations;

public class EventParticipantConfiguration
{
    
    public void Configure(EntityTypeBuilder<EventParticipant> builder)
    {
        builder.HasKey(ep => new { ep.EventId, ep.ParticipantId });
        
        builder
            .HasOne(ep => ep.Event)
            .WithMany()
            .HasForeignKey(ep => ep.EventId);
        
        builder
            .HasOne(ep => ep.Participant)
            .WithMany()
            .HasForeignKey(ep => ep.ParticipantId);
    }
}
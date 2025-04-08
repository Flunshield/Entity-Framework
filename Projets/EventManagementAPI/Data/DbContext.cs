using EventManagementAPI.Configurations;
using EventManagementAPI.Models;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Event> Events { get; set; }
    public DbSet<Participant> Participants { get; set; }
    public DbSet<Session> Sessions { get; set; }
    public DbSet<Speaker> Speakers { get; set; }
    public DbSet<Location> Locations { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new EventConfiguration());
        modelBuilder.ApplyConfiguration(new LocationConfiguration());
        modelBuilder.ApplyConfiguration(new SessionConfiguration());
        modelBuilder.ApplyConfiguration(new SpeakerConfiguration());
        modelBuilder.ApplyConfiguration(new ParticipantConfiguration());
    }
}
namespace EventManagementAPI.Models;

public class Event
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    // Relations
    public int LocationId { get; set; }
    public Location Location { get; set; } = null!;

    public List<Session> Sessions { get; set; } = new();
    public List<Participant> Participants { get; set; } = new();
}
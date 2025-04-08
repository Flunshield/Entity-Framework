namespace EventManagementAPI.Models;
public class Session
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }

    public int EventId { get; set; }
    public Event Event { get; set; } = null!;

    public int SpeakerId { get; set; }
    public Speaker Speaker { get; set; } = null!;
}
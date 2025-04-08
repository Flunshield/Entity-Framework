namespace EventManagementAPI.Models;

public class Rating
{
    public int Id { get; set; }
    public int SessionId { get; set; }
    public int ParticipantId { get; set; }
    public int Score { get; set; }
    public string? Comment { get; set; }
    
    // Navigation properties
    public Session Session { get; set; } = null!;
    public Participant Participant { get; set; } = null!;
}
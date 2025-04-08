using EventManagementAPI.Models;

namespace EventManagementAPI.Dtos;

public class SessionDto
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }

    public int EventId { get; set; }
    public ICollection<Speaker> SpeakerId { get; set; } = [];
}
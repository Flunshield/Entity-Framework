namespace EventManagementAPI.Models;

public class Participant
{
    public int Id { get; set; }
    public string FullName { get; set; } = null!;
    public string Email { get; set; } = null!;

    public List<Event> Events { get; set; } = new();
}
namespace EventManagementAPI.Models;

public class Participant
{
    public int Id { get; set; }
    public string FullName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string Company { get; set; } = null!;
    public string JobTitle { get; set; } = null!;
    public string Role  {get; set; } = "User";

    public List<Event> Events { get; set; } = new();
}
namespace EventManagementAPI.Models;

public class Location
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string City { get; set; } = null!;

    public List<Event> Events { get; set; } = new();
}
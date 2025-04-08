using EventManagementAPI.Models;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    
    // Navigation properties
    public ICollection<Event> Events { get; set; } = new List<Event>();
}
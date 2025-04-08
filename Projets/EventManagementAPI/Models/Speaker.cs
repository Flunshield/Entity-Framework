namespace EventManagementAPI.Models;
public class Speaker
{
    public int Id { get; set; }
    public string FullName { get; set; } = null!;
    public string Bio { get; set; } = null!;
    public string Email { get; set; } = null!;

    public List<Session> Sessions { get; set; } = new();
}
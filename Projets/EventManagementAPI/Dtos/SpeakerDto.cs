namespace EventManagementAPI.Dtos;

public class SpeakerDto
{
    public int Id { get; set; }
    public string FullName { get; set; } = null!;
    public string Bio { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Company { get; set; } = null!;
}
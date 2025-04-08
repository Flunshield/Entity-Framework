namespace EventManagementAPI.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int LocationId { get; set; }
        public int CategoryId { get; set; } // Ajout de la propriété CategoryId
        
        // Navigation properties
        public Location Location { get; set; } = null!;
        public Category Category { get; set; } = null!; // Ajout de la propriété Category
        public ICollection<Session> Sessions { get; set; } = new List<Session>();
        public ICollection<EventParticipant> Participants { get; set; } = new List<EventParticipant>(); // Ajout de la collection
    }
}
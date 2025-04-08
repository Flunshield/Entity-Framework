namespace EventManagementAPI.Models
{
    public class Session
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int EventId { get; set; }
        public int? RoomId { get; set; } // Ajout référence Room
        
        // Navigation properties
        public Event Event { get; set; } = null!;
        public Room? Room { get; set; }
        public ICollection<Speaker> Speakers { get; set; } = new List<Speaker>();
        public ICollection<Rating> Ratings { get; set; } = new List<Rating>();
    }
}
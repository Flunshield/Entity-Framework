// Models/EventParticipant.cs
using System;

namespace EventManagementAPI.Models
{
    public class EventParticipant
    {
        public int EventId { get; set; }
        public int ParticipantId { get; set; }
        public DateTime RegistrationDate { get; set; } = DateTime.UtcNow;
        public string AttendanceStatus { get; set; } = "Registered"; // Registered, Attended, Cancelled

        // Navigation properties
        public Event Event { get; set; } = null!;
        public Participant Participant { get; set; } = null!;
    }
}
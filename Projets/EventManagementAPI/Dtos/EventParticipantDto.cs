using System.ComponentModel.DataAnnotations;

namespace EventManagementAPI.Dtos
{
    public class EventParticipantDto
    {
        [Required]
        public int EventId { get; set; }
        
        [Required]
        public int ParticipantId { get; set; }
    }
}
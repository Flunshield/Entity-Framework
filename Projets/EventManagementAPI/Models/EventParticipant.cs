namespace EventManagementAPI.Models
{
    /// <summary>
    /// Représente l'inscription d'un participant à un événement.
    /// </summary>
    public class EventParticipant
    {
        /// <summary>
        /// Identifiant de l'événement auquel le participant est inscrit.
        /// </summary>
        public int EventId { get; set; }

        /// <summary>
        /// Identifiant du participant inscrit à l'événement.
        /// </summary>
        public int ParticipantId { get; set; }

        /// <summary>
        /// Date et heure de l'inscription du participant à l'événement.
        /// </summary>
        public DateTime RegistrationDate { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Statut de présence du participant pour l'événement.
        /// Par défaut, il est "Registered" (inscrit).
        /// </summary>
        public string AttendanceStatus { get; set; } = "Registered";

        /// <summary>
        /// Événement auquel le participant est inscrit.
        /// </summary>
        public Event Event { get; set; } = null!;

        /// <summary>
        /// Participant inscrit à l'événement.
        /// </summary>
        public Participant Participant { get; set; } = null!;
    }
}
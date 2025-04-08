namespace EventManagementAPI.Models
{
    /// <summary>
    /// Représente un événement dans le système de gestion d'événements.
    /// </summary>
    public class Event
    {
        /// <summary>
        /// Identifiant unique de l'événement.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nom de l'événement.
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// Description détaillée de l'événement.
        /// </summary>
        public string Description { get; set; } = null!;

        /// <summary>
        /// Date et heure de début de l'événement.
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Date et heure de fin de l'événement.
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Identifiant de la localisation où se déroule l'événement.
        /// </summary>
        public int LocationId { get; set; }

        /// <summary>
        /// Identifiant de la catégorie de l'événement.
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// Localisation de l'événement.
        /// </summary>
        public Location Location { get; set; } = null!;

        /// <summary>
        /// Catégorie de l'événement.
        /// </summary>
        public Category Category { get; set; } = null!;

        /// <summary>
        /// Liste des sessions associées à cet événement.
        /// </summary>
        public ICollection<Session> Sessions { get; set; } = new List<Session>();

        /// <summary>
        /// Liste des participants inscrits à cet événement.
        /// </summary>
        public ICollection<EventParticipant> Participants { get; set; } = new List<EventParticipant>();
    }
}
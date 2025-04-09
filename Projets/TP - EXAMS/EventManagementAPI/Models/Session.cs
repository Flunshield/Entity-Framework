namespace EventManagementAPI.Models
{
    /// <summary>
    /// Représente une session d'un événement. Chaque session a un titre, une description, une heure de début et de fin, 
    /// et peut être associée à une salle et à des intervenants.
    /// </summary>
    public class Session
    {
        /// <summary>
        /// Identifiant unique de la session.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Titre de la session.
        /// </summary>
        public string Title { get; set; } = null!;

        /// <summary>
        /// Description détaillée de la session.
        /// </summary>
        public string Description { get; set; } = null!;

        /// <summary>
        /// Heure de début de la session.
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// Heure de fin de la session.
        /// </summary>
        public DateTime EndTime { get; set; }

        /// <summary>
        /// Identifiant de l'événement auquel appartient cette session.
        /// </summary>
        public int EventId { get; set; }

        /// <summary>
        /// Identifiant de la salle où se déroule cette session (peut être null si aucune salle n'est assignée).
        /// </summary>
        public int? RoomId { get; set; }

        /// <summary>
        /// L'événement auquel cette session est associée.
        /// </summary>
        public Event Event { get; set; } = null!;

        /// <summary>
        /// La salle où se déroule la session (si elle est assignée).
        /// </summary>
        public Room? Room { get; set; }

        /// <summary>
        /// Liste des intervenants (orateurs) pour cette session.
        /// </summary>
        public ICollection<Speaker> Speakers { get; set; } = new List<Speaker>();

        /// <summary>
        /// Liste des évaluations (notes) attribuées à cette session par les participants.
        /// </summary>
        public ICollection<Rating> Ratings { get; set; } = new List<Rating>();
    }
}

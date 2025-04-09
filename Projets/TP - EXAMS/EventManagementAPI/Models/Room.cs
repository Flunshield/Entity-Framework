namespace EventManagementAPI.Models
{
    /// <summary>
    /// Représente une salle dans un lieu où les sessions d'événements peuvent se dérouler.
    /// </summary>
    public class Room
    {
        /// <summary>
        /// Identifiant unique de la salle.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nom de la salle.
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// Capacité maximale de la salle (le nombre de participants qu'elle peut accueillir).
        /// </summary>
        public int Capacity { get; set; }

        /// <summary>
        /// Identifiant du lieu auquel appartient la salle.
        /// </summary>
        public int LocationId { get; set; }

        /// <summary>
        /// Lieu où se trouve la salle.
        /// </summary>
        public Location Location { get; set; } = null!;

        /// <summary>
        /// Liste des sessions qui se dérouleront dans cette salle.
        /// </summary>
        public ICollection<Session> Sessions { get; set; } = new List<Session>();
    }
}
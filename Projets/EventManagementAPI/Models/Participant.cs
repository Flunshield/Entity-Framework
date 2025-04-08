namespace EventManagementAPI.Models
{
    /// <summary>
    /// Représente un participant à un ou plusieurs événements.
    /// </summary>
    public class Participant
    {
        /// <summary>
        /// Identifiant unique du participant.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Prénom du participant.
        /// </summary>
        public string FirstName { get; set; } = null!;

        /// <summary>
        /// Nom de famille du participant.
        /// </summary>
        public string LastName { get; set; } = null!;

        /// <summary>
        /// Adresse e-mail du participant.
        /// </summary>
        public string Email { get; set; } = null!;

        /// <summary>
        /// Numéro de téléphone du participant.
        /// </summary>
        public string Phone { get; set; } = null!;

        /// <summary>
        /// Nom de l'entreprise du participant.
        /// </summary>
        public string Company { get; set; } = null!;

        /// <summary>
        /// Titre du poste du participant.
        /// </summary>
        public string JobTitle { get; set; } = null!;

        /// <summary>
        /// Rôle du participant dans l'événement (par défaut "User").
        /// </summary>
        public string Role { get; set; } = "User";

        /// <summary>
        /// Liste des événements auxquels ce participant est inscrit.
        /// </summary>
        public List<Event> Events { get; set; } = [];
    }
}
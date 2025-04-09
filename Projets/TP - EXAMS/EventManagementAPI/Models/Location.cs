namespace EventManagementAPI.Models
{
    /// <summary>
    /// Représente une localisation d'événements.
    /// </summary>
    public class Location
    {
        /// <summary>
        /// Identifiant unique de la localisation.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nom de la localisation.
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// Adresse de la localisation.
        /// </summary>
        public string Address { get; set; } = null!;

        /// <summary>
        /// Ville où se situe la localisation.
        /// </summary>
        public string City { get; set; } = null!;

        /// <summary>
        /// Liste des événements qui se déroulent dans cette localisation.
        /// </summary>
        public List<Event> Events { get; set; } = [];
    }
}
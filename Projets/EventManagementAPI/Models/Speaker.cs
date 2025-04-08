namespace EventManagementAPI.Models
{
    /// <summary>
    /// Représente un intervenant (orateur) d'une ou plusieurs sessions. Un intervenant a un nom complet, une biographie, 
    /// un email, une entreprise, et un rôle associé à ses sessions.
    /// </summary>
    public class Speaker
    {
        /// <summary>
        /// Identifiant unique de l'intervenant.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nom complet de l'intervenant, composé du prénom et du nom.
        /// </summary>
        public string FullName { get; set; } = null!;

        /// <summary>
        /// Prénom de l'intervenant.
        /// </summary>
        public string FirstName { get; set; } = null!;

        /// <summary>
        /// Nom de famille de l'intervenant.
        /// </summary>
        public string LastName { get; set; } = null!;

        /// <summary>
        /// Biographie de l'intervenant, décrivant ses qualifications et son expérience.
        /// </summary>
        public string Bio { get; set; } = null!;

        /// <summary>
        /// Adresse e-mail de l'intervenant pour le contacter.
        /// </summary>
        public string Email { get; set; } = null!;

        /// <summary>
        /// Nom de l'entreprise ou organisation de l'intervenant.
        /// </summary>
        public string Company { get; set; } = null!;

        /// <summary>
        /// Rôle de l'intervenant dans l'événement (par défaut, "Speaker").
        /// </summary>
        public string Role { get; set; } = "Speaker";

        /// <summary>
        /// Liste des sessions auxquelles cet intervenant est assigné.
        /// </summary>
        public List<Session> Sessions { get; set; } = new();
    }
}
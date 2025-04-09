namespace EventManagementAPI.Models
{
    /// <summary>
    /// Représente une évaluation donnée par un participant à une session.
    /// </summary>
    public class Rating
    {
        /// <summary>
        /// Identifiant unique de l'évaluation.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Identifiant de la session évaluée.
        /// </summary>
        public int SessionId { get; set; }

        /// <summary>
        /// Identifiant du participant qui a donné l'évaluation.
        /// </summary>
        public int ParticipantId { get; set; }

        /// <summary>
        /// Score de l'évaluation (généralement sur une échelle de 1 à 5).
        /// </summary>
        public int Score { get; set; }

        /// <summary>
        /// Commentaire ajouté par le participant concernant la session.
        /// </summary>
        public string? Comment { get; set; }

        /// <summary>
        /// La session qui a été évaluée.
        /// </summary>
        public Session Session { get; set; } = null!;

        /// <summary>
        /// Le participant qui a donné l'évaluation.
        /// </summary>
        public Participant Participant { get; set; } = null!;
    }
}
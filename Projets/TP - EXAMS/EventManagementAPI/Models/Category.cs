namespace EventManagementAPI.Models;

/// <summary>
/// Représente une catégorie d'événements.
/// </summary>
public class Category
{
    /// <summary>
    /// Identifiant unique de la catégorie.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Nom de la catégorie.
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Description de la catégorie.
    /// </summary>
    public string Description { get; set; } = null!;

    /// <summary>
    /// Liste des événements associés à cette catégorie.
    /// </summary>
    public ICollection<Event> Events { get; set; } = new List<Event>();
}
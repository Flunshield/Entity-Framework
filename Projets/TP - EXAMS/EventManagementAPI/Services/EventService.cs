using EventManagementAPI.Data;
using EventManagementAPI.Dtos;
using EventManagementAPI.Interfaces;
using EventManagementAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EventManagementAPI.Services;

public class EventService : IEventService
{
    private readonly AppDbContext _context;

    public EventService(AppDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Récupère tous les événements disponibles.
    /// </summary>
    /// <returns>
    /// Une tâche représentant l'opération asynchrone. 
    /// Le résultat de la tâche contient une collection de <see cref="EventDto"/> représentant tous les événements.
    /// </returns>
    /// <remarks>
    /// Cette méthode interroge la base de données pour obtenir tous les événements,
    /// puis effectue un mappage manuel des entités vers des objets de transfert de données (DTO).
    /// </remarks>
    public async Task<IEnumerable<EventDto>> GetAllAsync()
    {
        return await _context.Events
            .Select(e => new EventDto
            {
                Id = e.Id,
                Name = e.Name,
                Description = e.Description,
                StartDate = e.StartDate,
                EndDate = e.EndDate,
                LocationId = e.LocationId,
                CategoryId = e.CategoryId
            })
            .ToListAsync();
    }

    /// <summary>
    /// Récupère un événement par son identifiant unique.
    /// </summary>
    /// <param name="id">L'identifiant de l'événement à récupérer.</param>
    /// <returns>
    /// Une tâche représentant l'opération asynchrone.
    /// Le résultat de la tâche contient un <see cref="EventDto"/> correspondant à l'identifiant fourni,
    /// ou <c>null</c> si aucun événement n'est trouvé.
    /// </returns>
    /// <remarks>
    /// Cette méthode utilise la recherche par clé primaire pour retrouver l'événement.
    /// Si l'événement est trouvé, il est mappé manuellement vers un DTO.
    /// </remarks>
    public async Task<EventDto?> GetByIdAsync(int id)
    {
        var e = await _context.Events.FindAsync(id);
        if (e == null) return null;

        return new EventDto
        {
            Id = e.Id,
            Name = e.Name,
            Description = e.Description,
            StartDate = e.StartDate,
            EndDate = e.EndDate,
            LocationId = e.LocationId,
            CategoryId = e.CategoryId
        };
    }

    /// <summary>
    /// Crée un nouvel événement dans la base de données.
    /// </summary>
    /// <param name="eventDto">L'objet <see cref="EventDto"/> contenant les informations de l'événement à créer.</param>
    /// <returns>
    /// Une tâche représentant l'opération asynchrone.
    /// Le résultat de la tâche contient le <see cref="EventDto"/> de l'événement créé,
    /// incluant l'identifiant généré par la base de données.
    /// </returns>
    /// <remarks>
    /// Les données du DTO sont mappées manuellement vers l'entité de la base.
    /// Après l'enregistrement, l'identifiant généré est affecté au DTO retourné.
    /// </remarks>
    public async Task<EventDto> CreateAsync(EventDto eventDto)
    {
        var entity = new Event
        {
            Name = eventDto.Name,
            Description = eventDto.Description,
            StartDate = eventDto.StartDate,
            EndDate = eventDto.EndDate,
            LocationId = eventDto.LocationId,
            CategoryId = eventDto.CategoryId
        };

        _context.Events.Add(entity);
        await _context.SaveChangesAsync();

        eventDto.Id = entity.Id;
        return eventDto;
    }

    /// <summary>
    /// Met à jour un événement existant dans la base de données.
    /// </summary>
    /// <param name="id">L'identifiant de l'événement à mettre à jour.</param>
    /// <param name="eventDto">L'objet <see cref="EventDto"/> contenant les nouvelles informations de l'événement.</param>
    /// <returns>
    /// Une tâche représentant l'opération asynchrone.
    /// Le résultat de la tâche est un booléen indiquant si la mise à jour a réussi.
    /// Retourne <c>false</c> si aucun événement correspondant n'a été trouvé.
    /// </returns>
    /// <remarks>
    /// Si l'événement est trouvé, ses propriétés sont mises à jour avec les valeurs du DTO,
    /// puis les modifications sont sauvegardées dans la base de données.
    /// </remarks>
    public async Task<bool> UpdateAsync(int id, EventDto eventDto)
    {
        var entity = await _context.Events.FindAsync(id);
        if (entity == null) return false;

        entity.Name = eventDto.Name;
        entity.Description = eventDto.Description;
        entity.StartDate = eventDto.StartDate;
        entity.EndDate = eventDto.EndDate;
        entity.LocationId = eventDto.LocationId;
        entity.CategoryId = eventDto.CategoryId;

        await _context.SaveChangesAsync();
        return true;
    }

    /// <summary>
    /// Supprime un événement existant de la base de données.
    /// </summary>
    /// <param name="id">L'identifiant de l'événement à supprimer.</param>
    /// <returns>
    /// Une tâche représentant l'opération asynchrone.
    /// Le résultat de la tâche est un booléen indiquant si la suppression a réussi.
    /// Retourne <c>false</c> si aucun événement correspondant n'a été trouvé.
    /// </returns>
    /// <remarks>
    /// Si l'événement est trouvé, il est supprimé de la base de données,
    /// et les changements sont sauvegardés.
    /// </remarks>
    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await _context.Events.FindAsync(id);
        if (entity == null) return false;

        _context.Events.Remove(entity);
        await _context.SaveChangesAsync();
        return true;
    }

    /// <summary>
    /// Récupère une liste paginée d'événements filtrés selon les critères spécifiés.
    /// </summary>
    /// <param name="startDate">Date de début minimale de l'événement (optionnelle).</param>
    /// <param name="endDate">Date de fin maximale de l'événement (optionnelle).</param>
    /// <param name="locationId">Identifiant de l'emplacement pour filtrer les événements (optionnel).</param>
    /// <param name="categoryId">Identifiant de la catégorie pour filtrer les événements (optionnel).</param>
    /// <param name="page">Numéro de la page pour la pagination (valeur par défaut : 1).</param>
    /// <param name="pageSize">Nombre d'éléments par page pour la pagination (valeur par défaut : 10).</param>
    /// <returns>
    /// Une tâche asynchrone qui retourne un tuple contenant :
    /// <list type="bullet">
    /// <item><description>Items : la liste des événements correspondant aux filtres et à la pagination.</description></item>
    /// <item><description>TotalCount : le nombre total d'événements correspondant aux filtres.</description></item>
    /// <item><description>TotalPages : le nombre total de pages selon la taille de page spécifiée.</description></item>
    /// </list>
    /// </returns>
    /// <remarks>
    /// Les filtres sont appliqués uniquement si les paramètres correspondants sont renseignés.
    /// La pagination est calculée en fonction du nombre total d'éléments et de la taille de page spécifiée.
    /// </remarks>
    public async Task<(IEnumerable<EventDto> Items, int TotalCount, int TotalPages)> GetFilteredAsync(
        DateTime? startDate = null,
        DateTime? endDate = null,
        int? locationId = null,
        int? categoryId = null,
        int page = 1,
        int pageSize = 10)
    {
        var query = _context.Events.AsQueryable();

        if (startDate.HasValue)
            query = query.Where(e => e.StartDate >= startDate.Value);

        if (endDate.HasValue)
            query = query.Where(e => e.EndDate <= endDate.Value);

        if (locationId.HasValue)
            query = query.Where(e => e.LocationId == locationId.Value);
            
        if (categoryId.HasValue)
            query = query.Where(e => e.CategoryId == categoryId.Value);

        // Calculer les métadonnées de pagination
        var totalCount = await query.CountAsync();
        var totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

        var events = await query
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .Select(e => new EventDto
            {
                Id = e.Id,
                Name = e.Name,
                Description = e.Description,
                StartDate = e.StartDate,
                EndDate = e.EndDate,
                LocationId = e.LocationId,
                CategoryId = e.CategoryId
            })
            .ToListAsync();

        return (events, totalCount, totalPages);
    }
    
    /// <summary>
    /// Enregistre un participant à un événement spécifique.
    /// </summary>
    /// <param name="eventId">L'identifiant de l'événement auquel le participant souhaite s'inscrire.</param>
    /// <param name="participantId">L'identifiant du participant à inscrire.</param>
    /// <returns>
    /// Une tâche asynchrone qui retourne un booléen :
    /// <list type="bullet">
    /// <item><description><c>true</c> si l'inscription a été réussie.</description></item>
    /// <item><description><c>false</c> si le participant est déjà inscrit à cet événement.</description></item>
    /// </list>
    /// </returns>
    /// <remarks>
    /// La méthode vérifie d'abord si le participant est déjà inscrit à l'événement.
    /// Si ce n'est pas le cas, elle crée une nouvelle inscription avec la date d'inscription actuelle et un statut de présence "Registered".
    /// </remarks>
    public async Task<bool> RegisterParticipantAsync(int eventId, int participantId)
    {
        // Vérifier si l'inscription existe déjà
        var existingRegistration = await _context.EventParticipants
            .FirstOrDefaultAsync(ep => ep.EventId == eventId && ep.ParticipantId == participantId);

        if (existingRegistration != null)
            return false; // Déjà inscrit

        // Créer une nouvelle inscription
        var registration = new EventParticipant
        {
            EventId = eventId,
            ParticipantId = participantId,
            RegistrationDate = DateTime.UtcNow,
            AttendanceStatus = "Registered"
        };

        _context.EventParticipants.Add(registration);
        await _context.SaveChangesAsync();
        return true;
    }
    
    /// <summary>
    /// Récupère la liste des événements auxquels un participant est inscrit.
    /// </summary>
    /// <param name="participantId">L'identifiant du participant pour lequel récupérer les événements.</param>
    /// <returns>
    /// Une tâche asynchrone qui retourne une collection d'objets <see cref="EventDto"/> représentant les événements
    /// auxquels le participant spécifié est inscrit.
    /// </returns>
    /// <remarks>
    /// La méthode filtre les événements en fonction de l'identifiant du participant et retourne une liste d'événements
    /// avec les informations pertinentes, telles que le nom, la description, les dates de début et de fin, ainsi que
    /// l'état de la présence du participant à chaque événement.
    /// </remarks>
    public async Task<IEnumerable<EventDto>> GetParticipantEventsAsync(int participantId)
    {
        return await _context.EventParticipants
            .Where(ep => ep.ParticipantId == participantId)
            .Select(ep => new EventDto
            {
                Id = ep.Event.Id,
                Name = ep.Event.Name,
                Description = ep.Event.Description,
                StartDate = ep.Event.StartDate,
                EndDate = ep.Event.EndDate,
                LocationId = ep.Event.LocationId,
                CategoryId = ep.Event.CategoryId,
                RegistrationDate = ep.RegistrationDate,
                AttendanceStatus = ep.AttendanceStatus
            })
            .ToListAsync();
    }

    /// <summary>
    /// Récupère la liste des catégories d'événements disponibles.
    /// </summary>
    /// <returns></returns>
    public async Task<object?> GetCategoriesAsync()
    {
        return await _context.Category
            .Select(c => new CategoryDto
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description
            })
            .ToListAsync();
    }
}
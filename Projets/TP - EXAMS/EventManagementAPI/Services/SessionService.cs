using EventManagementAPI.Data;
using EventManagementAPI.Dtos;
using EventManagementAPI.Interfaces;
using EventManagementAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EventManagementAPI.Services;

public class SessionService(AppDbContext context) : ISessionService
{
    /// <summary>
    /// Récupère toutes les sessions.
    /// </summary>
    /// <returns>
    /// Une tâche asynchrone qui retourne une liste de <see cref="SessionDto"/> contenant les informations de toutes les sessions.
    /// </returns>
    /// <remarks>
    /// La méthode récupère toutes les sessions présentes dans la base de données et les transforme en une liste d'objets DTO
    /// <see cref="SessionDto"/> pour simplifier la manipulation des données dans l'application.
    /// </remarks>
    public async Task<IEnumerable<SessionDto>> GetAllAsync()
    {
        return await context.Sessions
            .Select(s => new SessionDto
            {
                Id = s.Id,
                Title = s.Title,
                StartTime = s.StartTime,
                EndTime = s.EndTime,
                EventId = s.EventId,
                SpeakerId = s.Speakers
            })
            .ToListAsync();
    }

    /// <summary>
    /// Récupère une session par son identifiant.
    /// </summary>
    /// <param name="id">L'identifiant de la session à récupérer.</param>
    /// <returns>
    /// Une tâche asynchrone qui retourne un objet <see cref="SessionDto"/> contenant les informations de la session, 
    /// ou <c>null</c> si aucune session n'a été trouvée avec l'identifiant donné.
    /// </returns>
    /// <remarks>
    /// Cette méthode permet de récupérer une session dans la base de données en fonction de son identifiant. 
    /// Si la session est trouvée, ses informations sont retournées sous forme d'un objet <see cref="SessionDto"/>. 
    /// Sinon, <c>null</c> est retourné.
    /// </remarks>
    public async Task<SessionDto?> GetByIdAsync(int id)
    {
        var session = await context.Sessions.FindAsync(id);
        if (session == null) return null;

        return new SessionDto
        {
            Id = session.Id,
            Title = session.Title,
            StartTime = session.StartTime,
            EndTime = session.EndTime,
            EventId = session.EventId,
            SpeakerId = session.Speakers
        };
    }

    /// <summary>
    /// Crée une nouvelle session.
    /// </summary>
    /// <param name="sessionDto">L'objet DTO contenant les informations de la session à créer.</param>
    /// <returns>
    /// Une tâche asynchrone qui retourne l'objet <see cref="SessionDto"/> avec l'ID de la session généré après création.
    /// </returns>
    /// <remarks>
    /// Cette méthode permet de créer une nouvelle session dans la base de données en utilisant les informations fournies dans le DTO. 
    /// Après la création de la session, l'ID généré est attribué au DTO et renvoyé.
    /// </remarks>
    public async Task<SessionDto> CreateAsync(SessionDto sessionDto)
    {
        var entity = new Session
        {
            Title = sessionDto.Title,
            StartTime = sessionDto.StartTime,
            EndTime = sessionDto.EndTime,
            EventId = sessionDto.EventId,
            Speakers = sessionDto.SpeakerId
        };

        context.Sessions.Add(entity);
        await context.SaveChangesAsync();

        sessionDto.Id = entity.Id;
        return sessionDto;
    }

    /// <summary>
    /// Met à jour une session existante.
    /// </summary>
    /// <param name="id">L'identifiant de la session à mettre à jour.</param>
    /// <param name="sessionDto">L'objet DTO contenant les nouvelles informations de la session.</param>
    /// <returns>
    /// Une tâche asynchrone qui retourne <c>true</c> si la mise à jour a réussi, <c>false</c> si la session n'a pas été trouvée.
    /// </returns>
    /// <remarks>
    /// Cette méthode permet de mettre à jour les informations d'une session existante dans la base de données.
    /// Si la session avec l'identifiant spécifié n'existe pas, la méthode retourne <c>false</c>.
    /// </remarks>
    public async Task<bool> UpdateAsync(int id, SessionDto sessionDto)
    {
        var entity = await context.Sessions.FindAsync(id);
        if (entity == null) return false;

        entity.Title = sessionDto.Title;
        entity.StartTime = sessionDto.StartTime;
        entity.EndTime = sessionDto.EndTime;
        entity.EventId = sessionDto.EventId;
        entity.Speakers = sessionDto.SpeakerId;

        await context.SaveChangesAsync();
        return true;
    }

    /// <summary>
    /// Supprime une session existante.
    /// </summary>
    /// <param name="id">L'identifiant de la session à supprimer.</param>
    /// <returns>
    /// Une tâche asynchrone qui retourne <c>true</c> si la suppression a réussi, <c>false</c> si la session n'a pas été trouvée.
    /// </returns>
    /// <remarks>
    /// Cette méthode permet de supprimer une session existante de la base de données.
    /// Si la session avec l'identifiant spécifié n'existe pas, la méthode retourne <c>false</c>.
    /// </remarks>
    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await context.Sessions.FindAsync(id);
        if (entity == null) return false;

        context.Sessions.Remove(entity);
        await context.SaveChangesAsync();
        return true;
    }
}
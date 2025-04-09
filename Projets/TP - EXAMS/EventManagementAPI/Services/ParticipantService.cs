using EventManagementAPI.Data;
using EventManagementAPI.Dtos;
using EventManagementAPI.Interfaces;
using EventManagementAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EventManagementAPI.Services;

public class ParticipantService(AppDbContext context) : IParticipantService
{
    
    /// <summary>
    /// Récupère la liste de tous les participants.
    /// </summary>
    /// <returns>
    /// Une tâche asynchrone qui retourne une collection d'objets <see cref="ParticipantDto"/> représentant tous les participants.
    /// </returns>
    /// <remarks>
    /// La méthode retourne une liste de participants avec les informations essentielles telles que le prénom, le nom, l'email,
    /// l'entreprise, le poste, et le rôle de chaque participant.
    /// </remarks>
    public async Task<IEnumerable<ParticipantDto>> GetAllAsync()
    {
        return await context.Participants
            .Select(p => new ParticipantDto
            {
                Id = p.Id,
                FirstName = p.FirstName,
                LastName = p.LastName,
                Email = p.Email,
                Company = p.Company,
                JobTitle = p.JobTitle,
                Role = p.Role
            })
            .ToListAsync();
    }

    /// <summary>
    /// Récupère un participant par son identifiant.
    /// </summary>
    /// <param name="id">L'identifiant du participant à récupérer.</param>
    /// <returns>
    /// Une tâche asynchrone qui retourne un objet <see cref="ParticipantDto"/> représentant le participant avec l'identifiant
    /// spécifié, ou <c>null</c> si le participant n'a pas été trouvé.
    /// </returns>
    /// <remarks>
    /// La méthode cherche le participant dans la base de données en fonction de l'identifiant donné.
    /// Si un participant est trouvé, un <see cref="ParticipantDto"/> est retourné avec les informations essentielles.
    /// Sinon, <c>null</c> est retourné pour indiquer que le participant n'existe pas.
    /// </remarks>
    public async Task<ParticipantDto?> GetByIdAsync(int id)
    {
        var participant = await context.Participants.FindAsync(id);
        if (participant == null) return null;

        return new ParticipantDto
        {
            Id = participant.Id,
            Email = participant.Email,
            Company = participant.Company,
            JobTitle = participant.JobTitle,
            Role = participant.Role
        };
    }

    /// <summary>
    /// Crée un nouveau participant.
    /// </summary>
    /// <param name="participantDto">L'objet <see cref="ParticipantDto"/> contenant les informations du participant à créer.</param>
    /// <returns>
    /// Une tâche asynchrone qui retourne un objet <see cref="ParticipantDto"/> avec l'identifiant généré du participant créé.
    /// </returns>
    /// <remarks>
    /// La méthode crée un nouvel enregistrement de participant dans la base de données à partir des informations contenues dans
    /// le DTO. Après la création, l'identifiant généré du participant est ajouté au DTO, qui est ensuite retourné.
    /// </remarks>
    public async Task<ParticipantDto> CreateAsync(ParticipantDto participantDto)
    {
        var entity = new Participant
        {
            FirstName = participantDto.FirstName,
            LastName = participantDto.LastName,
            Email = participantDto.Email,
            Company = participantDto.Company,
            Phone = participantDto.Phone,
            JobTitle = participantDto.JobTitle
            
        };

        context.Participants.Add(entity);
        await context.SaveChangesAsync();

        participantDto.Id = entity.Id;
        return participantDto;
    }

    /// <summary>
    /// Met à jour un participant existant.
    /// </summary>
    /// <param name="id">L'identifiant du participant à mettre à jour.</param>
    /// <param name="participantDto">L'objet <see cref="ParticipantDto"/> contenant les nouvelles informations du participant.</param>
    /// <returns>
    /// Une tâche asynchrone qui retourne <c>true</c> si la mise à jour a réussi, ou <c>false</c> si le participant n'a pas été trouvé.
    /// </returns>
    /// <remarks>
    /// La méthode met à jour les informations du participant spécifié par son identifiant.
    /// Si un participant avec l'identifiant donné est trouvé, ses informations sont mises à jour avec celles contenues dans le DTO.
    /// Si le participant n'existe pas, <c>false</c> est retourné pour indiquer l'échec de la mise à jour.
    /// </remarks>
    public async Task<bool> UpdateAsync(int id, ParticipantDto participantDto)
    {
        var entity = await context.Participants.FindAsync(id);
        if (entity == null) return false;

        entity.Email = participantDto.Email;

        await context.SaveChangesAsync();
        return true;
    }

    /// <summary>
    /// Supprime un participant existant.
    /// </summary>
    /// <param name="id">L'identifiant du participant à supprimer.</param>
    /// <returns>
    /// Une tâche asynchrone qui retourne <c>true</c> si la suppression a réussi, ou <c>false</c> si le participant n'a pas été trouvé.
    /// </returns>
    /// <remarks>
    /// La méthode supprime le participant spécifié par son identifiant. Si un participant avec l'identifiant donné est trouvé,
    /// il est supprimé de la base de données. Si le participant n'existe pas, <c>false</c> est retourné pour indiquer l'échec de la suppression.
    /// </remarks>
    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await context.Participants.FindAsync(id);
        if (entity == null) return false;

        context.Participants.Remove(entity);
        await context.SaveChangesAsync();
        return true;
    }
}
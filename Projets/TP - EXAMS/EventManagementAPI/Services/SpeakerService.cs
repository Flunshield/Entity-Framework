using EventManagementAPI.Data;
using EventManagementAPI.Dtos;
using EventManagementAPI.Interfaces;
using EventManagementAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EventManagementAPI.Services;

public class SpeakerService(AppDbContext context) : ISpeakerService
{
    /// <summary>
    /// Récupère la liste de tous les intervenants (speakers).
    /// </summary>
    /// <returns>
    /// Une tâche asynchrone qui retourne une collection d'objets <see cref="SpeakerDto"/> contenant les informations de tous les intervenants.
    /// </returns>
    /// <remarks>
    /// Cette méthode permet de récupérer l'ensemble des intervenants enregistrés dans la base de données.
    /// Chaque intervenant est retourné avec ses informations, incluant son prénom, nom, email, biographie, entreprise et rôle.
    /// </remarks>
    public async Task<IEnumerable<SpeakerDto>> GetAllAsync()
    {
        return await context.Speakers
            .Select(s => new SpeakerDto
            {
                Id = s.Id,
                FirstName = s.FirstName,
                LastName = s.LastName,
                Email = s.Email,
                Bio = s.Bio,
                FullName = $"{s.FirstName} {s.LastName}",
                Company = s.Company,
                Role = s.Role
            })
            .ToListAsync();
    }

    /// <summary>
    /// Récupère un intervenant par son identifiant.
    /// </summary>
    /// <param name="id">L'identifiant de l'intervenant à récupérer.</param>
    /// <returns>
    /// Une tâche asynchrone qui retourne un objet <see cref="SpeakerDto"/> si l'intervenant est trouvé, sinon retourne <c>null</c>.
    /// </returns>
    /// <remarks>
    /// Cette méthode permet de récupérer un intervenant spécifique à partir de son identifiant unique.
    /// Si l'intervenant n'existe pas, la méthode retourne <c>null</c>.
    /// </remarks>
    public async Task<SpeakerDto?> GetByIdAsync(int id)
    {
        var speaker = await context.Speakers.FindAsync(id);
        if (speaker == null) return null;

        return new SpeakerDto
        {
            Id = speaker.Id,
            FirstName = speaker.FirstName,
            LastName = speaker.LastName,
            Email = speaker.Email,
            Bio = speaker.Bio,
            FullName = $"{speaker.FirstName} {speaker.LastName}",
            Company = speaker.Company,
            Role = speaker.Role
        };
    }

    /// <summary>
    /// Crée un nouvel intervenant.
    /// </summary>
    /// <param name="speakerDto">L'objet <see cref="SpeakerDto"/> contenant les informations de l'intervenant à créer.</param>
    /// <returns>
    /// Une tâche asynchrone qui retourne l'objet <see cref="SpeakerDto"/> avec l'ID attribué à l'intervenant créé.
    /// </returns>
    /// <remarks>
    /// Cette méthode permet de créer un nouvel intervenant dans la base de données.
    /// Si l'opération réussit, l'ID de l'intervenant est mis à jour dans l'objet DTO passé en paramètre.
    /// </remarks>
    public async Task<SpeakerDto> CreateAsync(SpeakerDto speakerDto)
    {
        var entity = new Speaker
        {
            FirstName = speakerDto.FirstName,
            LastName = speakerDto.LastName,
            Email = speakerDto.Email,
            Bio = speakerDto.Bio
        };

        context.Speakers.Add(entity);
        await context.SaveChangesAsync();

        speakerDto.Id = entity.Id;
        return speakerDto;
    }

    /// <summary>
    /// Met à jour les informations d'un intervenant existant.
    /// </summary>
    /// <param name="id">L'identifiant de l'intervenant à mettre à jour.</param>
    /// <param name="speakerDto">L'objet <see cref="SpeakerDto"/> contenant les nouvelles informations de l'intervenant.</param>
    /// <returns>
    /// Une tâche asynchrone qui retourne un booléen indiquant si la mise à jour a réussi ou non.
    /// </returns>
    /// <remarks>
    /// Cette méthode permet de mettre à jour les informations d'un intervenant existant dans la base de données.
    /// Si l'intervenant est trouvé et que les informations sont mises à jour avec succès, la méthode retourne <c>true</c>, sinon <c>false</c>.
    /// </remarks>
    public async Task<bool> UpdateAsync(int id, SpeakerDto speakerDto)
    {
        var entity = await context.Speakers.FindAsync(id);
        if (entity == null) return false;

        entity.FirstName = speakerDto.FirstName;
        entity.LastName = speakerDto.LastName;
        entity.Email = speakerDto.Email;
        entity.Bio = speakerDto.Bio;

        await context.SaveChangesAsync();
        return true;
    }

    /// <summary>
    /// Supprime un intervenant de la base de données.
    /// </summary>
    /// <param name="id">L'identifiant de l'intervenant à supprimer.</param>
    /// <returns>
    /// Une tâche asynchrone qui retourne un booléen indiquant si la suppression a réussi ou non.
    /// </returns>
    /// <remarks>
    /// Cette méthode permet de supprimer un intervenant de la base de données.
    /// Si l'intervenant est trouvé et supprimé avec succès, la méthode retourne <c>true</c>, sinon <c>false</c>.
    /// </remarks>
    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await context.Speakers.FindAsync(id);
        if (entity == null) return false;

        context.Speakers.Remove(entity);
        await context.SaveChangesAsync();
        return true;
    }
}
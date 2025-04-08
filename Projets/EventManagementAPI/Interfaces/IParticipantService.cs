using EventManagementAPI.Dtos;

namespace EventManagementAPI.Interfaces;

public interface IParticipantService
{
    Task<IEnumerable<ParticipantDto>> GetAllAsync();
    Task<ParticipantDto?> GetByIdAsync(int id);
    Task<ParticipantDto> CreateAsync(ParticipantDto participantDto);
    Task<bool> UpdateAsync(int id, ParticipantDto participantDto);
    Task<bool> DeleteAsync(int id);
}
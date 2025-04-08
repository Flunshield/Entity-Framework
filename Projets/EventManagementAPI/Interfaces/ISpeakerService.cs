using EventManagementAPI.Dtos;

namespace EventManagementAPI.Interfaces;

public interface ISpeakerService
{
    Task<IEnumerable<SpeakerDto>> GetAllAsync();
    Task<SpeakerDto?> GetByIdAsync(int id);
    Task<SpeakerDto> CreateAsync(SpeakerDto speakerDto);
    Task<bool> UpdateAsync(int id, SpeakerDto speakerDto);
    Task<bool> DeleteAsync(int id);
}
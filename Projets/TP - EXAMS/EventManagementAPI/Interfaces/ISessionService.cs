using EventManagementAPI.Dtos;

namespace EventManagementAPI.Interfaces;

public interface ISessionService
{
    Task<IEnumerable<SessionDto>> GetAllAsync();
    Task<SessionDto?> GetByIdAsync(int id);
    Task<SessionDto> CreateAsync(SessionDto sessionDto);
    Task<bool> UpdateAsync(int id, SessionDto sessionDto);
    Task<bool> DeleteAsync(int id);
}
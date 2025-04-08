using EventManagementAPI.Dtos;

namespace EventManagementAPI.Interfaces;

public interface IEventService
{
    Task<IEnumerable<EventDto>> GetAllAsync();
    Task<EventDto?> GetByIdAsync(int id);
    Task<EventDto> CreateAsync(EventDto eventDto);
    Task<bool> UpdateAsync(int id, EventDto eventDto);
    Task<bool> DeleteAsync(int id);
}
using EventManagementAPI.Dtos;

namespace EventManagementAPI.Interfaces;

public interface IEventService
{
    Task<IEnumerable<EventDto>> GetAllAsync();
    Task<EventDto?> GetByIdAsync(int id);
    Task<EventDto> CreateAsync(EventDto eventDto);
    Task<bool> UpdateAsync(int id, EventDto eventDto);
    Task<bool> DeleteAsync(int id);
    Task<(IEnumerable<EventDto> Items, int TotalCount, int TotalPages)> GetFilteredAsync(
        DateTime? startDate = null,
        DateTime? endDate = null,
        int? locationId = null,
        int? categoryId = null,
        int page = 1,
        int pageSize = 10);
    Task<bool> RegisterParticipantAsync(int eventId, int participantId);
    Task<IEnumerable<EventDto>> GetParticipantEventsAsync(int participantId);
    Task<object?> GetCategoriesAsync();
}
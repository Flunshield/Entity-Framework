using EventManagementAPI.Dtos;

namespace EventManagementAPI.Interfaces;

public interface ILocationService
{
    Task<IEnumerable<LocationDto>> GetAllAsync();
    Task<LocationDto?> GetByIdAsync(int id);
    Task<LocationDto> CreateAsync(LocationDto locationDto);
    Task<bool> UpdateAsync(int id, LocationDto locationDto);
    Task<bool> DeleteAsync(int id);
}
using EventManagementAPI.Dtos;

namespace EventManagementAPI.Interfaces
{
    public interface ILocationService
    {
        Task<IEnumerable<LocationDto>> GetAllLocationsAsync();
        Task<LocationDto?> GetLocationByIdAsync(int id);
        Task<LocationDto> CreateLocationAsync(LocationDto locationDto);
        Task<bool> UpdateLocationAsync(int id, LocationDto locationDto);
        Task<bool> DeleteLocationAsync(int id);
    }
}
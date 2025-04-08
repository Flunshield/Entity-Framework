using EventManagementAPI.Dtos;
using EventManagementAPI.Interfaces;
using EventManagementAPI.Models;

namespace EventManagementAPI.Services
{
    public class LocationService : ILocationService
    {
        private readonly ILocationRepository _locationRepository;
        // Consider adding ILogger for logging

        public LocationService(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository ?? throw new ArgumentNullException(nameof(locationRepository));
        }

        public async Task<IEnumerable<LocationDto>> GetAllLocationsAsync()
        {
            var locations = await _locationRepository.GetAllAsync();
            // Manual mapping (Consider AutoMapper for larger projects)
            return locations.Select(l => new LocationDto
            {
                Id = l.Id,
                Name = l.Name,
                Address = l.Address
            });
        }

        public async Task<LocationDto?> GetLocationByIdAsync(int id)
        {
            var location = await _locationRepository.GetByIdAsync(id);
            if (location == null)
            {
                return null;
            }

            // Manual mapping
            return new LocationDto
            {
                Id = location.Id,
                Name = location.Name,
                Address = location.Address
            };
        }

        public async Task<LocationDto> CreateLocationAsync(LocationDto locationDto)
        {
            // Basic validation example (move to dedicated validator later)
            if (string.IsNullOrWhiteSpace(locationDto.Name))
            {
                throw new ArgumentException("Location name cannot be empty.", nameof(locationDto.Name));
            }

            // Manual mapping
            var location = new Location
            {
                Name = locationDto.Name,
                Address = locationDto.Address
            };

            await _locationRepository.AddAsync(location);
            await _locationRepository.SaveChangesAsync(); // Assuming SaveChanges is called here

            // Update DTO with generated ID and return
            locationDto.Id = location.Id;
            return locationDto;
        }

        public async Task<bool> UpdateLocationAsync(int id, LocationDto locationDto)
        {
            var location = await _locationRepository.GetByIdAsync(id);
            if (location == null)
            {
                return false; // Indicate not found
            }

            // Basic validation
            if (string.IsNullOrWhiteSpace(locationDto.Name))
            {
                throw new ArgumentException("Location name cannot be empty.", nameof(locationDto.Name));
            }

            // Manual mapping
            location.Name = locationDto.Name;
            location.Address = locationDto.Address;

            // The Repository doesn't have an Update method in this setup.
            // EF Core tracks changes, so SaveChangesAsync is enough.
            await _locationRepository.SaveChangesAsync();
            return true; // Indicate success
        }

        public async Task<bool> DeleteLocationAsync(int id)
        {
            var location = await _locationRepository.GetByIdAsync(id);
            if (location == null)
            {
                return false; // Indicate not found
            }

            _locationRepository.Remove(location);
            await _locationRepository.SaveChangesAsync();
            return true; // Indicate success
        }
    }
}
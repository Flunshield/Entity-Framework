using EventManagementAPI.Data;
using EventManagementAPI.Interfaces;
using EventManagementAPI.Models;

namespace EventManagementAPI.Repositories
{
    public class LocationRepository : Repository<Location>, ILocationRepository
    {
        public LocationRepository(AppDbContext context) : base(context)
        {
        }

        // Implement location-specific methods here if they were defined in ILocationRepository
        // Example:
        // public async Task<IEnumerable<Location>> GetLocationsByCityAsync(string city)
        // {
        //     return await _dbSet.Where(l => l.City == city).ToListAsync();
        // }
    }
}
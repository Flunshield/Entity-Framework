using EventManagementAPI.Data;
using EventManagementAPI.Interfaces;
using EventManagementAPI.Models;
using EventManagementAPI.Repository;

namespace EventManagementAPI.Repositories
{
    public class LocationRepository : Repository<Location>, ILocationRepository
    {
        public LocationRepository(AppDbContext context) : base(context)
        {
        }
    }
}
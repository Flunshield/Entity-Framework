using EventManagementAPI.Data;
using EventManagementAPI.Interfaces;
using EventManagementAPI.Models;

namespace EventManagementAPI.Repositories
{
    public class LocationRepository(AppDbContext context) : Repository<Location>(context), ILocationRepository;
}
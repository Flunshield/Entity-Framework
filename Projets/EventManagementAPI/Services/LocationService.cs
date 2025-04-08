using EventManagementAPI.Data;
using EventManagementAPI.Dtos;
using EventManagementAPI.Interfaces;
using EventManagementAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EventManagementAPI.Services;

public class LocationService : ILocationService
{
    private readonly AppDbContext _context;

    public LocationService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<LocationDto>> GetAllAsync()
    {
        return await _context.Locations
            .Select(l => new LocationDto
            {
                Id = l.Id,
                Name = l.Name,
                Address = l.Address,
            })
            .ToListAsync();
    }

    public async Task<LocationDto?> GetByIdAsync(int id)
    {
        var location = await _context.Locations.FindAsync(id);
        if (location == null) return null;

        return new LocationDto
        {
            Id = location.Id,
            Name = location.Name,
            Address = location.Address,
        };
    }

    public async Task<LocationDto> CreateAsync(LocationDto locationDto)
    {
        var entity = new Location
        {
            Name = locationDto.Name,
            Address = locationDto.Address,
        };

        _context.Locations.Add(entity);
        await _context.SaveChangesAsync();

        locationDto.Id = entity.Id;
        return locationDto;
    }

    public async Task<bool> UpdateAsync(int id, LocationDto locationDto)
    {
        var entity = await _context.Locations.FindAsync(id);
        if (entity == null) return false;

        entity.Name = locationDto.Name;
        entity.Address = locationDto.Address;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await _context.Locations.FindAsync(id);
        if (entity == null) return false;

        _context.Locations.Remove(entity);
        await _context.SaveChangesAsync();
        return true;
    }
}
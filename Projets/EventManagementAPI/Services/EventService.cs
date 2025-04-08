using EventManagementAPI.Data;
using EventManagementAPI.Dtos;
using EventManagementAPI.Interfaces;
using EventManagementAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EventManagementAPI.Services;

public class EventService : IEventService
{
    private readonly AppDbContext _context;

    public EventService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<EventDto>> GetAllAsync()
    {
        return await _context.Events
            .Select(e => new EventDto
            {
                Id = e.Id,
                Name = e.Name,
                Description = e.Description,
                StartDate = e.StartDate,
                EndDate = e.EndDate,
                LocationId = e.LocationId
            })
            .ToListAsync();
    }

    public async Task<EventDto?> GetByIdAsync(int id)
    {
        var e = await _context.Events.FindAsync(id);
        if (e == null) return null;

        return new EventDto
        {
            Id = e.Id,
            Name = e.Name,
            Description = e.Description,
            StartDate = e.StartDate,
            EndDate = e.EndDate,
            LocationId = e.LocationId
        };
    }

    public async Task<EventDto> CreateAsync(EventDto eventDto)
    {
        var entity = new Event
        {
            Name = eventDto.Name,
            Description = eventDto.Description,
            StartDate = eventDto.StartDate,
            EndDate = eventDto.EndDate,
            LocationId = eventDto.LocationId
        };

        _context.Events.Add(entity);
        await _context.SaveChangesAsync();

        eventDto.Id = entity.Id;
        return eventDto;
    }

    public async Task<bool> UpdateAsync(int id, EventDto eventDto)
    {
        var entity = await _context.Events.FindAsync(id);
        if (entity == null) return false;

        entity.Name = eventDto.Name;
        entity.Description = eventDto.Description;
        entity.StartDate = eventDto.StartDate;
        entity.EndDate = eventDto.EndDate;
        entity.LocationId = eventDto.LocationId;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await _context.Events.FindAsync(id);
        if (entity == null) return false;

        _context.Events.Remove(entity);
        await _context.SaveChangesAsync();
        return true;
    }
}
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
                LocationId = e.LocationId,
                CategoryId = e.CategoryId
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
            LocationId = e.LocationId,
            CategoryId = e.CategoryId
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
            LocationId = eventDto.LocationId,
            CategoryId = eventDto.CategoryId
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
        entity.CategoryId = eventDto.CategoryId;

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

    public async Task<(IEnumerable<EventDto> Items, int TotalCount, int TotalPages)> GetFilteredAsync(
        DateTime? startDate = null,
        DateTime? endDate = null,
        int? locationId = null,
        int? categoryId = null,
        int page = 1,
        int pageSize = 10)
    {
        var query = _context.Events.AsQueryable();

        if (startDate.HasValue)
            query = query.Where(e => e.StartDate >= startDate.Value);

        if (endDate.HasValue)
            query = query.Where(e => e.EndDate <= endDate.Value);

        if (locationId.HasValue)
            query = query.Where(e => e.LocationId == locationId.Value);
            
        if (categoryId.HasValue)
            query = query.Where(e => e.CategoryId == categoryId.Value);

        // Calculer les métadonnées de pagination
        var totalCount = await query.CountAsync();
        var totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

        var events = await query
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .Select(e => new EventDto
            {
                Id = e.Id,
                Name = e.Name,
                Description = e.Description,
                StartDate = e.StartDate,
                EndDate = e.EndDate,
                LocationId = e.LocationId,
                CategoryId = e.CategoryId
            })
            .ToListAsync();

        return (events, totalCount, totalPages);
    }
    
    public async Task<bool> RegisterParticipantAsync(int eventId, int participantId)
    {
        // Vérifier si l'inscription existe déjà
        var existingRegistration = await _context.EventParticipants
            .FirstOrDefaultAsync(ep => ep.EventId == eventId && ep.ParticipantId == participantId);

        if (existingRegistration != null)
            return false; // Déjà inscrit

        // Créer une nouvelle inscription
        var registration = new EventParticipant
        {
            EventId = eventId,
            ParticipantId = participantId,
            RegistrationDate = DateTime.UtcNow,
            AttendanceStatus = "Registered"
        };

        _context.EventParticipants.Add(registration);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<EventDto>> GetParticipantEventsAsync(int participantId)
    {
        return await _context.EventParticipants
            .Where(ep => ep.ParticipantId == participantId)
            .Select(ep => new EventDto
            {
                Id = ep.Event.Id,
                Name = ep.Event.Name,
                Description = ep.Event.Description,
                StartDate = ep.Event.StartDate,
                EndDate = ep.Event.EndDate,
                LocationId = ep.Event.LocationId,
                CategoryId = ep.Event.CategoryId,
                RegistrationDate = ep.RegistrationDate,
                AttendanceStatus = ep.AttendanceStatus
            })
            .ToListAsync();
    }
}
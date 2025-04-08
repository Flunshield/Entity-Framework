using EventManagementAPI.Data;
using EventManagementAPI.Dtos;
using EventManagementAPI.Interfaces;
using EventManagementAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EventManagementAPI.Services;

public class SessionService : ISessionService
{
    private readonly AppDbContext _context;

    public SessionService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<SessionDto>> GetAllAsync()
    {
        return await _context.Sessions
            .Select(s => new SessionDto
            {
                Id = s.Id,
                Title = s.Title,
                StartTime = s.StartTime,
                EndTime = s.EndTime,
                EventId = s.EventId,
                SpeakerId = s.Speakers
            })
            .ToListAsync();
    }

    public async Task<SessionDto?> GetByIdAsync(int id)
    {
        var session = await _context.Sessions.FindAsync(id);
        if (session == null) return null;

        return new SessionDto
        {
            Id = session.Id,
            Title = session.Title,
            StartTime = session.StartTime,
            EndTime = session.EndTime,
            EventId = session.EventId,
            SpeakerId = session.Speakers
        };
    }

    public async Task<SessionDto> CreateAsync(SessionDto sessionDto)
    {
        var entity = new Session
        {
            Title = sessionDto.Title,
            StartTime = sessionDto.StartTime,
            EndTime = sessionDto.EndTime,
            EventId = sessionDto.EventId,
            Speakers = sessionDto.SpeakerId
        };

        _context.Sessions.Add(entity);
        await _context.SaveChangesAsync();

        sessionDto.Id = entity.Id;
        return sessionDto;
    }

    public async Task<bool> UpdateAsync(int id, SessionDto sessionDto)
    {
        var entity = await _context.Sessions.FindAsync(id);
        if (entity == null) return false;

        entity.Title = sessionDto.Title;
        entity.StartTime = sessionDto.StartTime;
        entity.EndTime = sessionDto.EndTime;
        entity.EventId = sessionDto.EventId;
        entity.Speakers = sessionDto.SpeakerId;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await _context.Sessions.FindAsync(id);
        if (entity == null) return false;

        _context.Sessions.Remove(entity);
        await _context.SaveChangesAsync();
        return true;
    }
}
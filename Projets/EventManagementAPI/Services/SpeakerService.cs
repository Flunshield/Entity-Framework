using EventManagementAPI.Data;
using EventManagementAPI.Dtos;
using EventManagementAPI.Interfaces;
using EventManagementAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EventManagementAPI.Services;

public class SpeakerService : ISpeakerService
{
    private readonly AppDbContext _context;

    public SpeakerService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<SpeakerDto>> GetAllAsync()
    {
        return await _context.Speakers
            .Select(s => new SpeakerDto
            {
                Id = s.Id,
                FirstName = s.FirstName,
                LastName = s.LastName,
                Email = s.Email,
                Bio = s.Bio
            })
            .ToListAsync();
    }

    public async Task<SpeakerDto?> GetByIdAsync(int id)
    {
        var speaker = await _context.Speakers.FindAsync(id);
        if (speaker == null) return null;

        return new SpeakerDto
        {
            Id = speaker.Id,
            FirstName = speaker.FirstName,
            LastName = speaker.LastName,
            Email = speaker.Email,
            Bio = speaker.Bio
        };
    }

    public async Task<SpeakerDto> CreateAsync(SpeakerDto speakerDto)
    {
        var entity = new Speaker
        {
            FirstName = speakerDto.FirstName,
            LastName = speakerDto.LastName,
            Email = speakerDto.Email,
            Bio = speakerDto.Bio
        };

        _context.Speakers.Add(entity);
        await _context.SaveChangesAsync();

        speakerDto.Id = entity.Id;
        return speakerDto;
    }

    public async Task<bool> UpdateAsync(int id, SpeakerDto speakerDto)
    {
        var entity = await _context.Speakers.FindAsync(id);
        if (entity == null) return false;

        entity.FirstName = speakerDto.FirstName;
        entity.LastName = speakerDto.LastName;
        entity.Email = speakerDto.Email;
        entity.Bio = speakerDto.Bio;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await _context.Speakers.FindAsync(id);
        if (entity == null) return false;

        _context.Speakers.Remove(entity);
        await _context.SaveChangesAsync();
        return true;
    }
}
﻿using EventManagementAPI.Data;
using EventManagementAPI.Dtos;
using EventManagementAPI.Interfaces;
using EventManagementAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EventManagementAPI.Services;

public class ParticipantService : IParticipantService
{
    private readonly AppDbContext _context;

    public ParticipantService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ParticipantDto>> GetAllAsync()
    {
        return await _context.Participants
            .Select(p => new ParticipantDto
            {
                Id = p.Id,
                FirstName = p.FirstName,
                LastName = p.LastName,
                Email = p.Email,
                Company = p.Company,
                JobTitle = p.JobTitle,
                Role = p.Role
            })
            .ToListAsync();
    }

    public async Task<ParticipantDto?> GetByIdAsync(int id)
    {
        var participant = await _context.Participants.FindAsync(id);
        if (participant == null) return null;

        return new ParticipantDto
        {
            Id = participant.Id,
            Email = participant.Email,
            Company = participant.Company,
            JobTitle = participant.JobTitle,
            Role = participant.Role
        };
    }

    public async Task<ParticipantDto> CreateAsync(ParticipantDto participantDto)
    {
        var entity = new Participant
        {
            Email = participantDto.Email
        };

        _context.Participants.Add(entity);
        await _context.SaveChangesAsync();

        participantDto.Id = entity.Id;
        return participantDto;
    }

    public async Task<bool> UpdateAsync(int id, ParticipantDto participantDto)
    {
        var entity = await _context.Participants.FindAsync(id);
        if (entity == null) return false;

        entity.Email = participantDto.Email;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await _context.Participants.FindAsync(id);
        if (entity == null) return false;

        _context.Participants.Remove(entity);
        await _context.SaveChangesAsync();
        return true;
    }
}
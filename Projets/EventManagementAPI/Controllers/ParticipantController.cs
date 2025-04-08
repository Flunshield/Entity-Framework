using EventManagementAPI.Dtos;
using EventManagementAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ParticipantController(IParticipantService participantService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ParticipantDto>>> GetParticipants()
    {
        var participants = await participantService.GetAllAsync();
        return Ok(participants);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ParticipantDto>> GetParticipant(int id)
    {
        var participantDto = await participantService.GetByIdAsync(id);
        if (participantDto == null) return NotFound();

        return Ok(participantDto);
    }

    [HttpPost]
    public async Task<ActionResult<ParticipantDto>> CreateParticipant(ParticipantDto participantDto)
    {
        var createdParticipant = await participantService.CreateAsync(participantDto);
        return CreatedAtAction(nameof(GetParticipant), new { id = createdParticipant.Id }, createdParticipant);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateParticipant(int id, ParticipantDto participantDto)
    {
        if (id != participantDto.Id) return BadRequest();

        var success = await participantService.UpdateAsync(id, participantDto);
        if (!success) return NotFound();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteParticipant(int id)
    {
        var success = await participantService.DeleteAsync(id);
        if (!success) return NotFound();

        return NoContent();
    }
}
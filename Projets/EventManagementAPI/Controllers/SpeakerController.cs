using EventManagementAPI.Dtos;
using EventManagementAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SpeakerController : ControllerBase
{
    private readonly ISpeakerService _speakerService;

    public SpeakerController(ISpeakerService speakerService)
    {
        _speakerService = speakerService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<SpeakerDto>>> GetSpeakers()
    {
        var speakers = await _speakerService.GetAllAsync();
        return Ok(speakers);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<SpeakerDto>> GetSpeaker(int id)
    {
        var speakerDto = await _speakerService.GetByIdAsync(id);
        if (speakerDto == null) return NotFound();

        return Ok(speakerDto);
    }

    [HttpPost]
    public async Task<ActionResult<SpeakerDto>> CreateSpeaker(SpeakerDto speakerDto)
    {
        var createdSpeaker = await _speakerService.CreateAsync(speakerDto);
        return CreatedAtAction(nameof(GetSpeaker), new { id = createdSpeaker.Id }, createdSpeaker);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateSpeaker(int id, SpeakerDto speakerDto)
    {
        if (id != speakerDto.Id) return BadRequest();

        var success = await _speakerService.UpdateAsync(id, speakerDto);
        if (!success) return NotFound();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSpeaker(int id)
    {
        var success = await _speakerService.DeleteAsync(id);
        if (!success) return NotFound();

        return NoContent();
    }
}
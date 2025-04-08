using EventManagementAPI.Dtos;
using EventManagementAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EventController(IEventService eventService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<EventDto>>> GetEvents()
    {
        var events = await eventService.GetAllAsync();
        return Ok(events);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<EventDto>> GetEvent(int id)
    {
        var eventDto = await eventService.GetByIdAsync(id);
        if (eventDto == null) return NotFound();
        
        return Ok(eventDto);
    }

    [HttpPost]
    public async Task<ActionResult<EventDto>> CreateEvent(EventDto eventDto)
    {
        var createdEvent = await eventService.CreateAsync(eventDto);
        return CreatedAtAction(nameof(GetEvent), new { id = createdEvent.Id }, createdEvent);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateEvent(int id, EventDto eventDto)
    {
        if (id != eventDto.Id) return BadRequest();

        var success = await eventService.UpdateAsync(id, eventDto);
        if (!success) return NotFound();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEvent(int id)
    {
        var success = await eventService.DeleteAsync(id);
        if (!success) return NotFound();

        return NoContent();
    }
}
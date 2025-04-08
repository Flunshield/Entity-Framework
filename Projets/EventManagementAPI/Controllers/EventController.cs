using EventManagementAPI.Dtos;
using EventManagementAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EventController : ControllerBase
{
    private readonly IEventService _eventService;

    public EventController(IEventService eventService)
    {
        _eventService = eventService;
    }

    /// <summary>
    /// Récupère tous les événements
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<EventDto>>> GetEvents()
    {
        var events = await _eventService.GetAllAsync();
        return Ok(events);
    }

    /// <summary>
    /// Récupère un événement par son ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<EventDto>> GetEvent(int id)
    {
        var eventDto = await _eventService.GetByIdAsync(id);
        if (eventDto == null) return NotFound();

        return Ok(eventDto);
    }

    /// <summary>
    /// Crée un nouvel événement
    /// </summary>
    /// <param name="eventDto"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult<EventDto>> CreateEvent(EventDto eventDto)
    {
        var createdEvent = await _eventService.CreateAsync(eventDto);
        return CreatedAtAction(nameof(GetEvent), new { id = createdEvent.Id }, createdEvent);
    }

    /// <summary>
    /// Met à jour un événement existant
    /// </summary>
    /// <param name="id"></param>
    /// <param name="eventDto"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateEvent(int id, EventDto eventDto)
    {
        if (id != eventDto.Id) return BadRequest();

        var success = await _eventService.UpdateAsync(id, eventDto);
        if (!success) return NotFound();

        return NoContent();
    }

    /// <summary>
    /// Supprime un événement
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEvent(int id)
    {
        var success = await _eventService.DeleteAsync(id);
        if (!success) return NotFound();

        return NoContent();
    }
    
    /// <summary>
    /// Récupère les événements filtrés par date, emplacement et catégorie
    /// </summary>
    /// <param name="startDate"></param>
    /// <param name="endDate"></param>
    /// <param name="locationId"></param>
    /// <param name="categoryId"></param>
    /// <param name="page"></param>
    /// <param name="pageSize"></param>
    /// <returns></returns>
    [HttpGet("filter")]
    public async Task<ActionResult<IEnumerable<EventDto>>> GetFilteredEvents(
        [FromQuery] DateTime? startDate = null,
        [FromQuery] DateTime? endDate = null,
        [FromQuery] int? locationId = null,
        [FromQuery] int? categoryId = null,
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 10)
    {
        var (events, totalCount, totalPages) = await _eventService.GetFilteredAsync(
            startDate, endDate, locationId, categoryId, page, pageSize);
            
        Response.Headers.Append("X-Total-Count", totalCount.ToString());
        Response.Headers.Append("X-Total-Pages", totalPages.ToString());
            
        return Ok(events);
    }
}
using EventManagementAPI.Dtos;
using EventManagementAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementAPI.Controllers;

[ApiController]
[Route("api/registrations")]
public class RegistrationController : ControllerBase
{
    private readonly IEventService _eventService;

    public RegistrationController(IEventService eventService)
    {
        _eventService = eventService;
    }

    /// <summary>
    /// Inscrit un participant à un événement
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> RegisterParticipant(EventParticipantDto registrationDto)
    {
        var success = await _eventService.RegisterParticipantAsync(
            registrationDto.EventId,
            registrationDto.ParticipantId);

        if (!success)
            return BadRequest("Le participant est déjà inscrit ou les données sont invalides.");

        return Ok();
    }

    /// <summary>
    /// Récupère tous les événements auxquels un participant est inscrit
    /// </summary>
    [HttpGet("participants/{participantId}/events")]
    public async Task<ActionResult<IEnumerable<EventDto>>> GetParticipantEvents(int participantId)
    {
        var events = await _eventService.GetParticipantEventsAsync(participantId);

        if (!events.Any())
            return NotFound($"Aucun événement trouvé pour le participant {participantId}");

        return Ok(events);
    }
}
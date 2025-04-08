using EventManagementAPI.Dtos;
using EventManagementAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SessionController : ControllerBase
{
    private readonly ISessionService _sessionService;

    public SessionController(ISessionService sessionService)
    {
        _sessionService = sessionService;
    }

    /// <summary>
    /// Récupère toutes les sessions
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<SessionDto>>> GetSessions()
    {
        var sessions = await _sessionService.GetAllAsync();
        return Ok(sessions);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<SessionDto>> GetSession(int id)
    {
        var sessionDto = await _sessionService.GetByIdAsync(id);
        if (sessionDto == null) return NotFound();

        return Ok(sessionDto);
    }

    /// <summary>
    /// Crée une nouvelle session
    /// </summary>
    /// <param name="sessionDto"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult<SessionDto>> CreateSession(SessionDto sessionDto)
    {
        var createdSession = await _sessionService.CreateAsync(sessionDto);
        return CreatedAtAction(nameof(GetSession), new { id = createdSession.Id }, createdSession);
    }

    /// <summary>
    /// Met à jour une session existante
    /// </summary>
    /// <param name="id"></param>
    /// <param name="sessionDto"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateSession(int id, SessionDto sessionDto)
    {
        if (id != sessionDto.Id) return BadRequest();

        var success = await _sessionService.UpdateAsync(id, sessionDto);
        if (!success) return NotFound();

        return NoContent();
    }

    /// <summary>
    /// Supprime une session
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSession(int id)
    {
        var success = await _sessionService.DeleteAsync(id);
        if (!success) return NotFound();

        return NoContent();
    }
}
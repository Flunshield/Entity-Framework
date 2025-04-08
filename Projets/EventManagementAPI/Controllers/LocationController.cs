using EventManagementAPI.Dtos;
using EventManagementAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LocationController(ILocationService locationService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<LocationDto>>> GetLocations()
    {
        var locations = await locationService.GetAllAsync();
        return Ok(locations);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<LocationDto>> GetLocation(int id)
    {
        var locationDto = await locationService.GetByIdAsync(id);
        if (locationDto == null) return NotFound();

        return Ok(locationDto);
    }

    [HttpPost]
    public async Task<ActionResult<LocationDto>> CreateLocation(LocationDto locationDto)
    {
        var createdLocation = await locationService.CreateAsync(locationDto);
        return CreatedAtAction(nameof(GetLocation), new { id = createdLocation.Id }, createdLocation);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateLocation(int id, LocationDto locationDto)
    {
        if (id != locationDto.Id) return BadRequest();

        var success = await locationService.UpdateAsync(id, locationDto);
        if (!success) return NotFound();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteLocation(int id)
    {
        var success = await locationService.DeleteAsync(id);
        if (!success) return NotFound();

        return NoContent();
    }
}
using EventManagementAPI.Controllers;
using EventManagementAPI.Dtos;
using EventManagementAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace EventManagementAPI.EventManagementAPI.Tests;

public class EventControllerTests
{
    private readonly Mock<IEventService> _eventServiceMock;
    private readonly EventController _controller;

    public EventControllerTests()
    {
        _eventServiceMock = new Mock<IEventService>();
        _controller = new EventController(_eventServiceMock.Object);
    }

    [Fact]
    public async Task GetEvents_ReturnsOkResult_WithListOfEvents()
    {
        // Arrange
        var events = new List<EventDto> { new EventDto { Id = 1, Name = "Test Event" } };
        _eventServiceMock.Setup(service => service.GetAllAsync())
            .ReturnsAsync(events);

        // Act
        var result = await _controller.GetEvents();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnValue = Assert.IsAssignableFrom<IEnumerable<EventDto>>(okResult.Value);
        Assert.Single(returnValue);
    }

    [Fact]
    public async Task GetEvent_ReturnsOkResult_WhenEventExists()
    {
        // Arrange
        var eventDto = new EventDto { Id = 1, Name = "Test Event" };
        _eventServiceMock.Setup(service => service.GetByIdAsync(1))
            .ReturnsAsync(eventDto);

        // Act
        var result = await _controller.GetEvent(1);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnValue = Assert.IsType<EventDto>(okResult.Value);
        Assert.Equal(1, returnValue.Id);
    }

    [Fact]
    public async Task GetEvent_ReturnsNotFound_WhenEventDoesNotExist()
    {
        // Arrange
        _eventServiceMock.Setup(service => service.GetByIdAsync(1))
            .ReturnsAsync((EventDto)null);

        // Act
        var result = await _controller.GetEvent(1);

        // Assert
        Assert.IsType<NotFoundResult>(result.Result);
    }

    [Fact]
    public async Task CreateEvent_ReturnsCreatedAtActionResult()
    {
        // Arrange
        var eventDto = new EventDto { Id = 1, Name = "New Event" };
        _eventServiceMock.Setup(service => service.CreateAsync(eventDto))
            .ReturnsAsync(eventDto);

        // Act
        var result = await _controller.CreateEvent(eventDto);

        // Assert
        var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result.Result);
        var returnValue = Assert.IsType<EventDto>(createdAtActionResult.Value);
        Assert.Equal(1, returnValue.Id);
    }

    [Fact]
    public async Task UpdateEvent_ReturnsBadRequest_WhenIdMismatch()
    {
        // Arrange
        var eventDto = new EventDto { Id = 2, Name = "Event" };

        // Act
        var result = await _controller.UpdateEvent(1, eventDto);

        // Assert
        Assert.IsType<BadRequestResult>(result);
    }

    [Fact]
    public async Task UpdateEvent_ReturnsNotFound_WhenEventDoesNotExist()
    {
        // Arrange
        var eventDto = new EventDto { Id = 1, Name = "Event" };
        _eventServiceMock.Setup(service => service.UpdateAsync(1, eventDto))
            .ReturnsAsync(false);

        // Act
        var result = await _controller.UpdateEvent(1, eventDto);

        // Assert
        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public async Task UpdateEvent_ReturnsNoContent_WhenSuccessful()
    {
        // Arrange
        var eventDto = new EventDto { Id = 1, Name = "Event" };
        _eventServiceMock.Setup(service => service.UpdateAsync(1, eventDto))
            .ReturnsAsync(true);

        // Act
        var result = await _controller.UpdateEvent(1, eventDto);

        // Assert
        Assert.IsType<NoContentResult>(result);
    }

    [Fact]
    public async Task DeleteEvent_ReturnsNotFound_WhenEventDoesNotExist()
    {
        // Arrange
        _eventServiceMock.Setup(service => service.DeleteAsync(1))
            .ReturnsAsync(false);

        // Act
        var result = await _controller.DeleteEvent(1);

        // Assert
        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public async Task DeleteEvent_ReturnsNoContent_WhenSuccessful()
    {
        // Arrange
        _eventServiceMock.Setup(service => service.DeleteAsync(1))
            .ReturnsAsync(true);

        // Act
        var result = await _controller.DeleteEvent(1);

        // Assert
        Assert.IsType<NoContentResult>(result);
    }
}
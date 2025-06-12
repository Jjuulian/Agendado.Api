using AgendadoApi.DTOs;
using AgendadoApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AgendadoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventsController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventsController(IEventService eventService)
        {
            _eventService = eventService;
        }

        private int GetUserId() => int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetAll(int userId)
        {
            var events = await _eventService.GetEventsAsync(userId);
            return Ok(events);
        }

        [HttpPost]
        public async Task<IActionResult> Create(EventDto dto)
        {
            var created = await _eventService.CreateEventAsync(dto);
            return Ok(created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int userId,int id, [FromBody] EventDto dto)
        {
            var updated = await _eventService.UpdateEventAsync(id, dto);
            if (updated == null)
                return NotFound();

            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _eventService.DeleteEventAsync(id);
            if (!success)
                return NotFound();

            return NoContent();
        }

        [HttpPost("filter")]
        public async Task<IActionResult> Filter(int userId,[FromBody] EventFilterDto filter)
        {
            var Id = userId;
            var events = await _eventService.FilterEventsAsync(Id, filter);
            return Ok(events);
        }
    }
}

using AgendadoApi.DTOs;
using AgendadoApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AgendadoApi.Controllers
{
    public class EventsController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventsController(IEventService eventService)
        {
            _eventService = eventService;
        }

        private int GetUserId() => int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var userId = GetUserId();
            var events = await _eventService.GetEventsAsync(userId);
            return Ok(events);
        }

        [HttpPost]
        public async Task<IActionResult> Create(EventDto dto)
        {
            var userId = GetUserId();
            var created = await _eventService.CreateEventAsync(userId, dto);
            return Ok(created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, EventDto dto)
        {
            var userId = GetUserId();
            var updated = await _eventService.UpdateEventAsync(userId, id, dto);
            if (updated == null)
                return NotFound();

            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var userId = GetUserId();
            var success = await _eventService.DeleteEventAsync(userId, id);
            if (!success)
                return NotFound();

            return NoContent();
        }
    }
}

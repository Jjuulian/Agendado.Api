using AgendadoApi.Data;
using AgendadoApi.DTOs;
using AgendadoApi.Models;
using AgendadoApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AgendadoApi.Services.Implementations
{
    public class EventService : IEventService
    {
        private readonly AgendaDbContext _context;

        public EventService(AgendaDbContext context)
        {
            _context = context;
        }

        public async Task<List<Event>> GetEventsAsync(int userId)
        {
            return await _context.Events
                .Where(e => e.UserId == userId)
                .ToListAsync();
        }

        public async Task<Event> CreateEventAsync(int userId, EventDto dto)
        {
            var newEvent = new Event
            {
                UserId = userId,
                Title = dto.Title,
                Description = dto.Description,
                StartEventDate = dto.StartEventDate,
                EndEventDate = dto.EndEventDate,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            _context.Events.Add(newEvent);
            await _context.SaveChangesAsync();
            return newEvent;
        }

        public async Task<Event?> UpdateEventAsync(int userId, int eventId, EventDto dto)
        {
            var ev = await _context.Events.FirstOrDefaultAsync(e => e.Id == eventId && e.UserId == userId);
            if (ev == null) return null;

            ev.Title = dto.Title;
            ev.Description = dto.Description;
            ev.StartEventDate = dto.StartEventDate;
            ev.EndEventDate = dto.EndEventDate;
            ev.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return ev;
        }

        public async Task<bool> DeleteEventAsync(int userId, int eventId)
        {
            var ev = await _context.Events.FirstOrDefaultAsync(e => e.Id == eventId && e.UserId == userId);
            if (ev == null) return false;

            _context.Events.Remove(ev);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

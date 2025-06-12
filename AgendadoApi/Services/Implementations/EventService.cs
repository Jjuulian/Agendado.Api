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

        public async Task<Event> CreateEventAsync(EventDto dto)
        {
            var newEvent = new Event
            {
                UserId = dto.UserId,
                Title = dto.Title,
                Description = dto.Description,
                StartEventDate = dto.StartEventDate,
                EndEventDate = dto.EndEventDate,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Priority = dto.Priority,
                Status = dto.Status,
                Category = dto.Category

            };

            _context.Events.Add(newEvent);
            await _context.SaveChangesAsync();
            return newEvent;
        }

        public async Task<Event?> UpdateEventAsync(int EventId, EventDto Dto)
        {
            var ev = await _context.Events.FirstOrDefaultAsync(e => e.Id == EventId);
            if (ev == null) return null;

            ev.Title = Dto.Title;
            ev.Description = Dto.Description;
            ev.StartEventDate = Dto.StartEventDate;
            ev.EndEventDate = Dto.EndEventDate;
            ev.UpdatedAt = DateTime.UtcNow;
            ev.Priority = Dto.Priority;
            ev.Status = Dto.Status;
            ev.Category = Dto.Category;

            await _context.SaveChangesAsync();
            return ev;
        }

        public async Task<bool> DeleteEventAsync(int eventId)
        {
            var ev = await _context.Events.FirstOrDefaultAsync(e => e.Id == eventId);
            if (ev == null) return false;

            _context.Events.Remove(ev);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Event>> FilterEventsAsync(int userId, EventFilterDto filter)
        {
            var query = _context.Events.AsQueryable();

            query = query.Where(e => e.UserId == userId);

            if (filter.StartDate.HasValue)
            {
                var date = filter.StartDate.Value.Date;
                query = query.Where(e =>
                    e.StartEventDate.Date <= date &&
                    e.EndEventDate.Date >= date
                );
            }

            if (filter.Category.HasValue)
                query = query.Where(e => e.Category == filter.Category.Value);

            if (filter.Status.HasValue)
                query = query.Where(e => e.Status == filter.Status.Value);

            if (filter.Priority.HasValue)
                query = query.Where(e => e.Priority == filter.Priority.Value);

            return await query.ToListAsync();
        }
    }
}

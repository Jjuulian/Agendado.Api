using AgendadoApi.DTOs;
using AgendadoApi.Models;

namespace AgendadoApi.Services.Interfaces
{
    public interface IEventService
    {
        Task<List<Event>> GetEventsAsync(int userId);
        Task<Event> CreateEventAsync(EventDto dto);
        Task<Event?> UpdateEventAsync(int eventId, EventDto dto);
        Task<bool> DeleteEventAsync(int eventId);
        Task<List<Event>> FilterEventsAsync(int userId, EventFilterDto filter);
    }
}

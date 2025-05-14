using AgendadoApi.DTOs;
using AgendadoApi.Models;

namespace AgendadoApi.Services.Interfaces
{
    public interface IEventService
    {
        Task<List<Event>> GetEventsAsync(int userId);
        Task<Event> CreateEventAsync(int userId, EventDto dto);
        Task<Event?> UpdateEventAsync(int userId, int eventId, EventDto dto);
        Task<bool> DeleteEventAsync(int userId, int eventId);
    }
}

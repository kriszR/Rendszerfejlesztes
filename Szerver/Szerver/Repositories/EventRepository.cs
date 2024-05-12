using Microsoft.EntityFrameworkCore;
using Szerver.Models;

namespace Szerver.Repositories
{
    public interface IEventRepository
    {
        Task<IEnumerable<Event>> GetEvents();
    }
    public class EventRepository : IEventRepository
    {
        private readonly MoodleContext _context;

        public EventRepository(MoodleContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Event>> GetEvents()
        {
            return await _context.Events.ToListAsync();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Szerver.Models;

namespace Szerver.Repositories
{
    public class EventsRepository : IEventsRepository
    {
        private readonly MoodleContext _context;

        public EventsRepository(MoodleContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Events>> GetEvents()
        {
            return await _context.Events.ToListAsync();
        }
    }
}

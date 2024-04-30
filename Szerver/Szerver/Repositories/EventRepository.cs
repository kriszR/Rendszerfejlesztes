using Microsoft.EntityFrameworkCore;
using Szerver.Models;

namespace Szerver.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly MoodleContext _context;

        public EventRepository(MoodleContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Events>> GetEvents()
        {
            return await _context.Events.ToListAsync();
        }
    }
}

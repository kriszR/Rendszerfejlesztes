using Microsoft.EntityFrameworkCore;
using Szerver.Models;

namespace Szerver.Repositories
{
    public class MyCoursesRepository : IMyCoursesRepository
    {
        private readonly MoodleContext _context;

        public MyCoursesRepository(MoodleContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Mycourses>> GetMycourses()
        {
            return await _context.Mycourses.ToListAsync();
        }
    }
}

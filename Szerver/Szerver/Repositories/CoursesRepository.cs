using Microsoft.EntityFrameworkCore;
using Szerver.Models;

namespace Szerver.Repositories
{
    public class CoursesRepository : ICoursesRepository
    {
        private readonly MoodleContext _context;

        public CoursesRepository(MoodleContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Courses>> GetCourses()
        {
            return await _context.Courses.ToListAsync();
        }
    }
}

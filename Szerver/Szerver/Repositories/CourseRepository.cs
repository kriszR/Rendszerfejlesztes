using Microsoft.EntityFrameworkCore;
using Szerver.Models;

namespace Szerver.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly MoodleContext _context;

        public CourseRepository(MoodleContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Courses>> GetCourses()
        {
            return await _context.Courses.ToListAsync();
        }
    }
}

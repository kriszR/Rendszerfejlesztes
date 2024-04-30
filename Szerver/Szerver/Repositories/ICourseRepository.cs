using Szerver.Models;

namespace Szerver.Repositories
{
    public interface ICourseRepository
    {
        Task<IEnumerable<Courses>> GetCourses();
    }
}

using Microsoft.EntityFrameworkCore;
using Szerver.Models;
using Szerver.Models.DtoFolder;
using Szerver.Models.UserFolder;

namespace Szerver.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> Get();
        Task<User> Get(int id);
        Task<IEnumerable<Course>> GetCoursesForUser(int userId);
        Task<User> Create(User student);
        Task Update(User student);
        Task Delete(int id);
        Task<ServiceResponse<List<GetCourseDto>>> AddCourseToUser(AddCourseToUserDto request);
    }
    public class UserRepository : IUserRepository
    {
        private readonly MoodleContext _context;

        public UserRepository(MoodleContext context)
        {
            _context = context;
        }
        public async Task<User> Create(User student)
        {
            _context.Users.Add(student);
            await _context.SaveChangesAsync();

            return student;
        }

        public async Task Delete(int id)
        {
            var studentToDelete = await _context.Users.FindAsync(id);
            _context.Users.Remove(studentToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> Get()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> Get(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task Update(User student)
        {
            _context.Entry(student).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<Course>> GetCoursesForUser(int userId)
        {
            return await _context.Mycourses
                .Where(uc => uc.UserId == userId)
                .Select(uc => uc.Course)
                .ToListAsync();
        }

        /*public async Task<ServiceResponse<List<GetCourseDto>>> AddCourseToUser(AddCourseToUserDto request)
        {
            var user = await _context.Mycourses.Include(x => x.User)
                .ThenInclude(x => x.Courses)
                .FirstOrDefaultAsync(x => x.Id == requestObject.UserId);
            var course = await _context.Courses.Include(x => x.Degrees).FirstOrDefaultAsync(x => x.Id == requestObject.CourseId);
            if (!course.Degrees.Contains(user.Degree)) // Requested course is not allowed for the user's degree
            {
                return new ServiceResponse<List<GetCourseDto>>
                {
                    Success = false,
                    Message = ResponseMessages.SubscriptionToCourseRejected,
                    Data = null
                };
            }
            if (user.Courses == null)
            {
                user.Courses = new List<Course>();
            }
            if (user.Courses.Any(c => c.Id == course.Id)) //The user is already subscribed to the course
            {
                return new ServiceResponse<List<GetCourseDto>>
                {
                    Success = false,
                    Message = ResponseMessages.AlreadySubcribed,
                    Data = null
                };
            }
            else
            { // The user is allowed to subscribe to the course and is not subscribed yet
                user.Courses.Add(course);
                await _context.SaveChangesAsync();
                return new ServiceResponse<List<GetCourseDto>>
                {
                    Success = true,
                    Message = ResponseMessages.CourseAddedToUser,
                    Data = GetCoursesByUser(user.Id).Result.Data
                };
            }*/

        public async Task<ServiceResponse<List<GetCourseDto>>> AddCourseToUser(AddCourseToUserDto request)
        {
            var user = await _context.Users.Include(x => x.Degree).FirstOrDefaultAsync(x => x.Id == request.UserId);
            var course = await _context.Courses.FirstOrDefaultAsync(x => x.Id == request.CourseId);

            if (user == null || course == null)
            {
                return new ServiceResponse<List<GetCourseDto>>
                {
                    Success = false,
                    Message = "Felhasználó vagy kurzus nem található",
                    Data = null
                };
            }

            if (user.Degree == null)
            {
                return new ServiceResponse<List<GetCourseDto>>
                {
                    Success = false,
                    Message = "A felhasználóhoz nincs hozzárendelve szak",
                    Data = null
                };
            }

            var allowedDegreesForCourse = await _context.ApprovedDegrees
                .Where(cd => cd.CourseId == course.Id)
                .Select(cd => cd.DegreeId)
                .ToListAsync();

            if (!allowedDegreesForCourse.Contains(user.DegreeId))
            {
                return new ServiceResponse<List<GetCourseDto>>
                {
                    Success = false,
                    Message = "A felhasználó szakja nem engedélyezett a kurzushoz",
                    Data = null
                };
            }

            // Egyéb ellenőrzések (pl. feliratkozás már megtörtént-e)

            // Ha minden ellenőrzés sikeres, akkor hozzáadjuk a kurzust a felhasználóhoz
            // user.Courses.Add(course);
            // await _context.SaveChangesAsync();

            var myCourse = new MyCourse
            {
                UserId = user.Id,
                CourseId = course.Id
            };

            _context.Mycourses.Add(myCourse);
            await _context.SaveChangesAsync();

            return new ServiceResponse<List<GetCourseDto>>
            {
                Success = true,
                Message = "A kurzus sikeresen hozzá lett adva a felhasználóhoz",
                Data = null // Itt érdemes lehet visszaadni a felhasználóhoz tartozó kurzusok listáját
            };
        }
    }
}

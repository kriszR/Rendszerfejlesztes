using Microsoft.EntityFrameworkCore;
using Szerver.Models;

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

    }
}

using Microsoft.EntityFrameworkCore;
using Szerver.Models;

namespace Szerver.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly MoodleContext _context;

        public UserRepository(MoodleContext context)
        {
            _context = context;
        }
        public async Task<Users> Create(Users student)
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

        public async Task<IEnumerable<Users>> Get()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<Users> Get(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task Update(Users student)
        {
            _context.Entry(student).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}

using Microsoft.EntityFrameworkCore;

namespace Szerver.Models
{
    public class MoodleDbContext : DbContext
    {
        public MoodleDbContext(DbContextOptions<MoodleDbContext> options) : base(options) 
        { 
            Database.EnsureCreated();
        }
        public DbSet<Users> Users { get; set; }
        public DbSet<Degrees> Degrees { get; set; }
        public DbSet<Mycourses> Mycourses { get; set; }
        public DbSet<Events> Events { get; set; }
        public DbSet<Courses> Courses { get; set; }
        public DbSet<Approved_degrees> Approved_degrees { get; set; }

    }
}

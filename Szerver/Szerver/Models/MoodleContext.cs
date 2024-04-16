using Microsoft.EntityFrameworkCore;

namespace Szerver.Models
{
    public class MoodleContext : DbContext
    {
        public MoodleContext(DbContextOptions<MoodleContext> options) : base(options) 
        { 
            Database.EnsureCreated();
        }
        public DbSet<Users> Users { get; set; }
        public DbSet<Degrees> Degrees { get; set; }
        public DbSet<Mycourses> Mycourses { get; set; }
        public DbSet<ApprovedDegrees> ApprovedDegrees { get; set; }
        public DbSet<Courses> Courses { get; set; }
        public DbSet<Events> Events { get; set; }

    }
}

using Microsoft.EntityFrameworkCore;

namespace Szerver.Models
{
    public class MoodleContext : DbContext
    {
        public MoodleContext(DbContextOptions<MoodleContext> options) : base(options) 
        { 
            Database.EnsureCreated();
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Degree> Degrees { get; set; }
        public DbSet<MyCourse> Mycourses { get; set; }
        public DbSet<ApprovedDegree> ApprovedDegrees { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRole>().HasKey(ur => new { ur.UserId, ur.RoleId });
        }

    }
}

namespace Szerver.Models
{
    public class Mycourses
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        //public Users User { get; set; }
        public int CourseId { get; set; }
        public Courses Course { get; set; }
    }
}

namespace Szerver.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public int [] Degrees { get; set; } = [];
        public string [] MyCourses { get; set; } = [];
    }
}

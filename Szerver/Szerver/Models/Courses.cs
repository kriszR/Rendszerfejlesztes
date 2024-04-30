namespace Szerver.Models
{
    public class Courses
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public int Credit { get; set; }
    }
}

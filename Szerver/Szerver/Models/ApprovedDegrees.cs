namespace Szerver.Models
{
    public class ApprovedDegrees
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public Courses Course { get; set; }
        public int DegreeId { get; set; }
        public Degrees Degree { get; set; }
    }
}

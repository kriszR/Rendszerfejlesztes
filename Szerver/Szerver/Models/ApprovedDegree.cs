using System.Text.Json.Serialization;

namespace Szerver.Models
{
    public class ApprovedDegree
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        [JsonIgnore]
        public Course Course { get; set; }
        public int DegreeId { get; set; }
        [JsonIgnore]
        public Degree Degree { get; set; }
    }
}
